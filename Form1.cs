using Basler.Pylon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeightSensor
{
    public partial class Form1 : Form
    {
        // Camera Variables
        Camera camera;
        PixelDataConverter converter = new PixelDataConverter();
        bool isGrabbing = false;

        // Serial Port Variables
        SerialPort mySerialPort = new SerialPort();
        SerialPort mySerialPort1 = new SerialPort();

        // Store focus values for each preset (initialized to 0)
        private string configPath = AppDomain.CurrentDomain.BaseDirectory + "lens_config.txt";
        int f1Value, f2Value, f3Value, f4Value, f5Value;
        Button activePresetButton = null; // Tracks which F-button is currently selected
        public Form1()
        {
            InitializeComponent();
            LoadAvailablePorts();

            LoadFromFile();

            // Set default label text
            lblPort.Text = "Status : Offline";
            lblFocus.Text = "Current Focus: 0";
            hScrollBarFocus.Minimum = 0;
            hScrollBarFocus.Maximum = 1024;
            hScrollBarFocus.SmallChange = 1;
            hScrollBarFocus.LargeChange = 10;

            
        }

        private void LoadAvailablePorts()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            portoption.Items.Clear();
            portoption.Items.AddRange(ports);

            portoption1.Items.Clear();
            portoption1.Items.AddRange(ports);

            if (portoption.Items.Count > 0)
            {
                portoption.SelectedIndex = 0;
            }
            if (portoption1.Items.Count > 0)
            {
                portoption1.SelectedIndex = 0;
            }
        }

        #region Camera Logic
        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            try
            {
                if (camera == null)
                {
                    camera = new Camera(CameraFinder.Enumerate().First());
                    camera.Open();
                    camera.Parameters[PLCamera.ExposureAuto].SetValue(PLCamera.ExposureAuto.Off);
                    camera.Parameters[PLCamera.PixelFormat].SetValue(PLCamera.PixelFormat.Mono8);
                    camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.Continuous);
                    camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;

                }

                if (!isGrabbing)
                {
                    camera.StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);
                    isGrabbing = true;
                    LiquidLens.Enabled = true;
                    heightsensor.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Camera Error: " + ex.Message);
            }
        }

        private void btnApplyExposure_Click(object sender, EventArgs e)
        {
            UpdateCameraExposure();
        }

        private void UpdateCameraExposure()
        {
            try
            {
                if (camera != null && camera.IsOpen)
                {
                    // 1. Parse the input from the textbox
                    if (double.TryParse(txtexposure.Text, out double exposureValue))
                    {
                        // 2. Access the ExposureTime parameter
                        // Note: We use the 'long' cast here to satisfy the API requirements
                        double min = camera.Parameters[PLCamera.ExposureTime].GetMinimum();
                        double max = camera.Parameters[PLCamera.ExposureTime].GetMaximum();

                        // 3. Clamp the value so it doesn't crash if the user types 9999999
                        if (exposureValue < min) exposureValue = min;
                        if (exposureValue > max) exposureValue = max;

                        // 4. Set the value with the explicit cast
                        camera.Parameters[PLCamera.ExposureTime].SetValue((double)exposureValue);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exposure Error: " + ex.Message);
            }
        }

        private void OnImageGrabbed(object sender, ImageGrabbedEventArgs e)
        {
            try
            {
                IGrabResult grabResult = e.GrabResult;
                if (grabResult.GrabSucceeded)
                {
                    // Use PixelFormat.Format8bppIndexed for Mono8 cameras
                    Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format8bppIndexed);

                    // Set the palette to Grayscale (otherwise it looks like random colors)
                    ColorPalette pal = bitmap.Palette;
                    for (int i = 0; i <= 255; i++) pal.Entries[i] = Color.FromArgb(i, i, i);
                    bitmap.Palette = pal;

                    BitmapData bmpData = bitmap.LockBits(
                        new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        ImageLockMode.WriteOnly,
                        bitmap.PixelFormat);

                    try
                    {
                        // We use the 'ptr' directly from the grab result to avoid extra conversion
                        // For Mono8, the OutputPixelFormat should match the camera
                        converter.OutputPixelFormat = PixelType.Mono8;
                        converter.Convert(bmpData.Scan0, bmpData.Stride * bitmap.Height, grabResult);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bmpData);
                    }

                    BaslerImage.Invoke(new Action(() =>
                    {
                        BaslerImage.Image?.Dispose();
                        BaslerImage.Image = (Bitmap)bitmap.Clone();
                    }));

                    bitmap.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Grab Error: " + ex.Message);
            }
            finally
            {
                e.DisposeGrabResultIfClone();
            }
        }
        #endregion

        #region Serial Port Connection
        private void portoption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen) mySerialPort.Close();
            mySerialPort.PortName = portoption.SelectedItem.ToString();
        }

        private void btn_connectport_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            {
                try
                {
                    mySerialPort.Close();
                    lblPort.Text = "Status : Offline";
                    lblPort.ForeColor = Color.Red;
                    btn_connectport.Text = "Connect";

                    // Disable controls on disconnect
                    manualfocus.Enabled = false;
                    gearsetting.Enabled = false;
                    portoption.Enabled = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                if (portoption.SelectedItem == null) return;
                try
                {
                    mySerialPort.BaudRate = 9600;
                    mySerialPort.DataBits = 8;
                    mySerialPort.StopBits = StopBits.One;
                    mySerialPort.Parity = Parity.None;
                    mySerialPort.Open();

                    lblPort.Text = $"Status : Connected ({mySerialPort.PortName})";
                    lblPort.ForeColor = Color.DarkGreen;
                    btn_connectport.Text = "Disconnect";

                    manualfocus.Enabled = true;
                    gearsetting.Enabled = true;
                    heightsensor.Enabled = true;
                    portoption.Enabled = false;
                }
                catch (Exception ex) { MessageBox.Show("Connection Error: " + ex.Message); }
            }
        }

        #endregion

        #region Height Sensor (JY-DAM0222) Logic
        private Timer sensorPollTimer;

        private void InitSensorTimer()
        {
            sensorPollTimer = new Timer();
            sensorPollTimer.Interval = 200; // Poll every 200ms
            sensorPollTimer.Tick += (s, e) => SendSensorRequest();
        }

        private void SendSensorRequest()
        {
            if (mySerialPort1 != null && mySerialPort1.IsOpen)
            {
                try
                {
                    // Standard Modbus RTU Read Input Registers (0x04) or Holding (0x03)
                    // JY-DAM0222 Channel 1 is usually at address 0x0000 or 0x0001
                    byte[] request = new byte[] { 0x01, 0x04, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };

                    // Calculate and inject CRC
                    ushort crc = CalculateCRC(request, 6);
                    request[6] = (byte)(crc & 0xFF);        // CRC Low
                    request[7] = (byte)((crc >> 8) & 0xFF); // CRC High

                    mySerialPort1.Write(request, 0, request.Length);
                }
                catch { /* Handle Port Errors */ }
            }
        }

        private void btn_connectport1_Click(object sender, EventArgs e)
        {
            if (mySerialPort1.IsOpen)
            {
                sensorPollTimer.Stop();
                mySerialPort1.Close();
                lblPort1.Text = "Status : Offline";
                lblPort1.ForeColor = Color.Red;
                btn_connectport1.Text = "Connect";
            }
            else
            {
                try
                {
                    if (portoption1.SelectedItem == null) return;

                    mySerialPort1.PortName = portoption1.SelectedItem.ToString();
                    mySerialPort1.BaudRate = 9600;
                    mySerialPort1.DataBits = 8;
                    mySerialPort1.Parity = Parity.None;
                    mySerialPort1.StopBits = StopBits.One;

                    mySerialPort1.DataReceived -= MySerialPort1_DataReceived;
                    mySerialPort1.DataReceived += MySerialPort1_DataReceived;

                    mySerialPort1.Open();

                    if (sensorPollTimer == null) InitSensorTimer();
                    sensorPollTimer.Start();

                    lblPort1.Text = $"Status : Connected ({mySerialPort1.PortName})";
                    lblPort1.ForeColor = Color.DarkGreen;
                    btn_connectport1.Text = "Disconnect";
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void ApplyAutomaticFocus(int focusValue, string rangeName)
        {
            // Update the UI so the user knows why the focus changed
            txtGear.Text =  rangeName;
            txtFocus.Text = focusValue.ToString();

            // Send the command to the lens
            // Note: Calling btnChange_Click(this, null) is a quick way to reuse your serial logic
            btnChange_Click(this, null);
        }

        private void MySerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(50);
                int bytesToRead = mySerialPort1.BytesToRead;
                if (bytesToRead < 7) return;

                byte[] buffer = new byte[bytesToRead];
                mySerialPort1.Read(buffer, 0, bytesToRead);

                if (buffer.Length >= 7 && buffer[1] == 0x04)
                {
                    int rawValue = (buffer[3] << 8) | buffer[4];

                    this.BeginInvoke(new Action(() =>
                    {
                        // Convert to CM (assuming 0.01 scaling from your previous code)
                        double currentInCm = rawValue * 0.01;

                        // Assuming 120.0 was your offset constant
                        double finalHeight = currentInCm - 120.0;
                        txtHeight.Text = finalHeight.ToString("F2") + " cm";

                        // --- AUTOMATIC FOCUS LOGIC ---
                        // Range 0 - 10cm -> Use F1
                        if (finalHeight >= 0 && finalHeight <= 10)
                        {
                            ApplyAutomaticFocus(f1Value, "F1 (0-10cm)");
                        }
                        // Range 15 - 30cm -> Use F2
                        else if (finalHeight >= 15 && finalHeight <= 30)
                        {
                            ApplyAutomaticFocus(f2Value, "F2 (15-30cm)");
                        }
                        // Range 45 - 55cm -> Use F3
                        else if (finalHeight >= 55 && finalHeight <= 80)
                        {
                            ApplyAutomaticFocus(f3Value, "F3 (55-80cm)");
                        }
                    }));
                }
            }
            catch (Exception ) { /* Debug.WriteLine(ex.Message); */ }
        }

        // Modbus CRC16 Calculation
        private ushort CalculateCRC(byte[] data, int length)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < length; i++)
            {
                crc ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x0001) != 0)
                        crc = (ushort)((crc >> 1) ^ 0xA001);
                    else
                        crc >>= 1;
                }
            }
            return crc;
        }
        #endregion
        

        #region Focus Control Logic

        // Prevents non-numeric typing
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (mySerialPort != null && mySerialPort.IsOpen)
            {
                try
                {
                    // 1. Convert input text to an integer
                    if (!int.TryParse(txtFocus.Text, out int focusValue))
                    {
                        MessageBox.Show("Please enter a valid number.");
                        return;
                    }
                    if (focusValue < 0) focusValue = 0;
                    if (focusValue > 1024) focusValue = 1024;
                    txtFocus.Text = focusValue.ToString();

                    // Update scrollbar position
                    hScrollBarFocus.Value = focusValue;
                    // 2. Prepare the 8-byte packet
                    byte[] packet = new byte[8];

                    // Fixed Header
                    packet[0] = 0x53; // 'S'
                    packet[1] = 0x31; // '1'
                    packet[2] = 0x01;
                    packet[3] = 0x02;

                    // 3. Dynamic Value: Split integer into High Byte (AA) and Low Byte (BB)
                    // Example: 629 (0x0275) -> AA=0x02, BB=0x75
                    packet[4] = (byte)(focusValue & 0xFF);        // BB
                    packet[5] = (byte)((focusValue >> 8) & 0xFF); // AA

                    // 4. Calculate Checksum (CC)
                    // Most devices use the sum of all bytes before the checksum
                    int sum = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        sum += packet[i];
                    }
                    packet[6] = (byte)(sum & 0xFF); // CC (Keep only the lower byte of the sum)

                    // Fixed Footer
                    packet[7] = 0x3E; // '>'

                    // 5. Send the raw bytes
                    mySerialPort.Write(packet, 0, packet.Length);

                    // UI Feedback
                    lblFocus.Text = $"Current Focus: {focusValue}";
                    txtFocus.BackColor = Color.LightBlue;

                    // Optional: Print to console for debugging
                    Console.WriteLine("Sent Hex: " + BitConverter.ToString(packet));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Send Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please connect the COM port first!");
            }
        }
        #endregion

        #region Focus Control Logic (Buttons and Scrollbar)

        private void btnaddfocus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFocus.Text, out int val))
            {
                txtFocus.Text = (val + 1).ToString();
                btnChange_Click(this, null); // Send the updated value
            }
        }

        private void btnminusfocus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFocus.Text, out int val))
            {
                txtFocus.Text = Math.Max(0, val - 1).ToString();
                btnChange_Click(this, null); // Send the updated value
            }
        }

        private void hScrollBarFocus_Scroll(object sender, ScrollEventArgs e)
        {
            // SYNC: Update text box as user slides
            txtFocus.Text = hScrollBarFocus.Value.ToString();
            btnChange_Click(this, null); // Real-time update
        }

        private void SaveToFile()
        {
            try
            {
                // Write values separated by commas
                string data = $"{f1Value},{f2Value},{f3Value},{f4Value},{f5Value}";
                System.IO.File.WriteAllText(configPath, data);
            }
            catch (Exception ex) { Console.WriteLine("Save Error: " + ex.Message); }
        }

        private void LoadFromFile()
        {
            try
            {
                if (System.IO.File.Exists(configPath))
                {
                    string content = System.IO.File.ReadAllText(configPath);
                    string[] values = content.Split(',');

                    if (values.Length == 5)
                    {
                        f1Value = int.Parse(values[0]);
                        f2Value = int.Parse(values[1]);
                        f3Value = int.Parse(values[2]);
                        f4Value = int.Parse(values[3]);
                        f5Value = int.Parse(values[4]);
                    }
                }
            }
            catch { /* Use default 0s if file is corrupted */ }
        }

        #endregion

        private void SetGearButtonsEnabled(bool enabled)
        {
            btnF1.Enabled = enabled;
            btnF2.Enabled = enabled;
            btnF3.Enabled = enabled;
            btnF4.Enabled = enabled;
            btnF5.Enabled = enabled;
        }

        private void HandlePresetClick(object sender)
        {
            activePresetButton = (Button)sender;

            // 1. Update the Gear display
            txtGear.Text = activePresetButton.Text;

            // 2. LOAD the saved value back into the UI
            int valueToLoad = 0;
            if (activePresetButton == btnF1) valueToLoad = f1Value;
            else if (activePresetButton == btnF2) valueToLoad = f2Value;
            else if (activePresetButton == btnF3) valueToLoad = f3Value;
            else if (activePresetButton == btnF4) valueToLoad = f4Value;
            else if (activePresetButton == btnF5) valueToLoad = f5Value;

            // 3. Apply the value to the Textbox
            txtFocus.Text = valueToLoad.ToString();

            // 4. TRIGGER the camera/lens update 
            // This calls your existing serial port logic to actually move the lens
            btnChange_Click(this, null);

            // 5. Lock UI logic
            SetGearButtonsEnabled(false);
            activePresetButton.Enabled = true;
            activePresetButton.BackColor = Color.Gold;
        }

        private void btnF1_Click(object sender, EventArgs e) => HandlePresetClick(sender);
        private void btnF2_Click(object sender, EventArgs e) => HandlePresetClick(sender);
        private void btnF3_Click(object sender, EventArgs e) => HandlePresetClick(sender);
        private void btnF4_Click(object sender, EventArgs e) => HandlePresetClick(sender);
        private void btnF5_Click(object sender, EventArgs e) => HandlePresetClick(sender);

        private void btnSaveGear_Click(object sender, EventArgs e)
        {
            // Check if a gear was actually selected
            if (activePresetButton == null)
            {
                MessageBox.Show("Please select F1-F5 first!");
                return;
            }

            // Try to get the focus value from the txtFocus textbox
            if (int.TryParse(txtFocus.Text, out int currentFocus))
            {
                // Save to the specific variable
                if (activePresetButton == btnF1) f1Value = currentFocus;
                else if (activePresetButton == btnF2) f2Value = currentFocus;
                else if (activePresetButton == btnF3) f3Value = currentFocus;
                else if (activePresetButton == btnF4) f4Value = currentFocus;
                else if (activePresetButton == btnF5) f5Value = currentFocus;

                SaveToFile();

                // Reset UI
                activePresetButton.BackColor = SystemColors.Control;
                activePresetButton = null;
                txtGear.Text = ""; // Clear the gear text after saving
                SetGearButtonsEnabled(true);
            }
            else
            {
                MessageBox.Show("Invalid Focus Value in txtFocus.");
            }
        }
    }
}