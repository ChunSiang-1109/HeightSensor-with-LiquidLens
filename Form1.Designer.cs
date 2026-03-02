using System.Windows.Forms;

namespace HeightSensor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BaslerImage = new System.Windows.Forms.PictureBox();
            this.LiquidLens = new System.Windows.Forms.GroupBox();
            this.gearsetting = new System.Windows.Forms.GroupBox();
            this.txtGear = new System.Windows.Forms.TextBox();
            this.lblCurrentGear = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveGear = new System.Windows.Forms.Button();
            this.btnF5 = new System.Windows.Forms.Button();
            this.btnF2 = new System.Windows.Forms.Button();
            this.btnF3 = new System.Windows.Forms.Button();
            this.btnF4 = new System.Windows.Forms.Button();
            this.btnF1 = new System.Windows.Forms.Button();
            this.manualfocus = new System.Windows.Forms.GroupBox();
            this.lblFocus = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.hScrollBarFocus = new System.Windows.Forms.HScrollBar();
            this.btnaddfocus = new System.Windows.Forms.Button();
            this.btnminusfocus = new System.Windows.Forms.Button();
            this.txtFocus = new System.Windows.Forms.TextBox();
            this.SerialPort = new System.Windows.Forms.GroupBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.btn_connectport = new System.Windows.Forms.Button();
            this.portoption = new System.Windows.Forms.ComboBox();
            this.btnStartCamera = new System.Windows.Forms.Button();
            this.heightsensor = new System.Windows.Forms.GroupBox();
            this.SerialPort2 = new System.Windows.Forms.GroupBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblCurrentHeight = new System.Windows.Forms.Label();
            this.lblPort1 = new System.Windows.Forms.Label();
            this.btn_connectport1 = new System.Windows.Forms.Button();
            this.portoption1 = new System.Windows.Forms.ComboBox();
            this.lblexposure = new System.Windows.Forms.Label();
            this.txtexposure = new System.Windows.Forms.TextBox();
            this.btnApplyExposure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BaslerImage)).BeginInit();
            this.LiquidLens.SuspendLayout();
            this.gearsetting.SuspendLayout();
            this.manualfocus.SuspendLayout();
            this.SerialPort.SuspendLayout();
            this.heightsensor.SuspendLayout();
            this.SerialPort2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaslerImage
            // 
            this.BaslerImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BaslerImage.Location = new System.Drawing.Point(46, 151);
            this.BaslerImage.Name = "BaslerImage";
            this.BaslerImage.Size = new System.Drawing.Size(487, 337);
            this.BaslerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BaslerImage.TabIndex = 0;
            this.BaslerImage.TabStop = false;
            // 
            // LiquidLens
            // 
            this.LiquidLens.Controls.Add(this.gearsetting);
            this.LiquidLens.Controls.Add(this.manualfocus);
            this.LiquidLens.Controls.Add(this.SerialPort);
            this.LiquidLens.Enabled = false;
            this.LiquidLens.Location = new System.Drawing.Point(587, 9);
            this.LiquidLens.Name = "LiquidLens";
            this.LiquidLens.Size = new System.Drawing.Size(390, 424);
            this.LiquidLens.TabIndex = 1;
            this.LiquidLens.TabStop = false;
            this.LiquidLens.Text = "LiquidLens";
            // 
            // gearsetting
            // 
            this.gearsetting.Controls.Add(this.txtGear);
            this.gearsetting.Controls.Add(this.lblCurrentGear);
            this.gearsetting.Controls.Add(this.label1);
            this.gearsetting.Controls.Add(this.btnSaveGear);
            this.gearsetting.Controls.Add(this.btnF5);
            this.gearsetting.Controls.Add(this.btnF2);
            this.gearsetting.Controls.Add(this.btnF3);
            this.gearsetting.Controls.Add(this.btnF4);
            this.gearsetting.Controls.Add(this.btnF1);
            this.gearsetting.Enabled = false;
            this.gearsetting.Location = new System.Drawing.Point(22, 279);
            this.gearsetting.Name = "gearsetting";
            this.gearsetting.Size = new System.Drawing.Size(356, 134);
            this.gearsetting.TabIndex = 2;
            this.gearsetting.TabStop = false;
            this.gearsetting.Text = "Gear Setting";
            // 
            // txtGear
            // 
            this.txtGear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGear.Enabled = false;
            this.txtGear.Location = new System.Drawing.Point(176, 89);
            this.txtGear.Name = "txtGear";
            this.txtGear.ReadOnly = true;
            this.txtGear.Size = new System.Drawing.Size(110, 20);
            this.txtGear.TabIndex = 67;
            this.txtGear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCurrentGear
            // 
            this.lblCurrentGear.AutoSize = true;
            this.lblCurrentGear.Location = new System.Drawing.Point(123, 91);
            this.lblCurrentGear.Name = "lblCurrentGear";
            this.lblCurrentGear.Size = new System.Drawing.Size(47, 13);
            this.lblCurrentGear.TabIndex = 66;
            this.lblCurrentGear.Text = "Current :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // btnSaveGear
            // 
            this.btnSaveGear.Location = new System.Drawing.Point(282, 32);
            this.btnSaveGear.Name = "btnSaveGear";
            this.btnSaveGear.Size = new System.Drawing.Size(59, 30);
            this.btnSaveGear.TabIndex = 5;
            this.btnSaveGear.Text = "Save";
            this.btnSaveGear.UseVisualStyleBackColor = true;
            this.btnSaveGear.Click += new System.EventHandler(this.btnSaveGear_Click);
            // 
            // btnF5
            // 
            this.btnF5.Location = new System.Drawing.Point(226, 32);
            this.btnF5.Name = "btnF5";
            this.btnF5.Size = new System.Drawing.Size(38, 30);
            this.btnF5.TabIndex = 4;
            this.btnF5.Text = "F5";
            this.btnF5.UseVisualStyleBackColor = true;
            this.btnF5.Click += new System.EventHandler(this.btnF5_Click);
            // 
            // btnF2
            // 
            this.btnF2.Location = new System.Drawing.Point(76, 32);
            this.btnF2.Name = "btnF2";
            this.btnF2.Size = new System.Drawing.Size(38, 30);
            this.btnF2.TabIndex = 3;
            this.btnF2.Text = "F2";
            this.btnF2.UseVisualStyleBackColor = true;
            this.btnF2.Click += new System.EventHandler(this.btnF2_Click);
            // 
            // btnF3
            // 
            this.btnF3.Location = new System.Drawing.Point(126, 32);
            this.btnF3.Name = "btnF3";
            this.btnF3.Size = new System.Drawing.Size(38, 30);
            this.btnF3.TabIndex = 2;
            this.btnF3.Text = "F3";
            this.btnF3.UseVisualStyleBackColor = true;
            this.btnF3.Click += new System.EventHandler(this.btnF3_Click);
            // 
            // btnF4
            // 
            this.btnF4.Location = new System.Drawing.Point(176, 32);
            this.btnF4.Name = "btnF4";
            this.btnF4.Size = new System.Drawing.Size(38, 30);
            this.btnF4.TabIndex = 1;
            this.btnF4.Text = "F4";
            this.btnF4.UseVisualStyleBackColor = true;
            this.btnF4.Click += new System.EventHandler(this.btnF4_Click);
            // 
            // btnF1
            // 
            this.btnF1.Location = new System.Drawing.Point(26, 32);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(38, 30);
            this.btnF1.TabIndex = 0;
            this.btnF1.Text = "F1";
            this.btnF1.UseVisualStyleBackColor = true;
            this.btnF1.Click += new System.EventHandler(this.btnF1_Click);
            // 
            // manualfocus
            // 
            this.manualfocus.Controls.Add(this.lblFocus);
            this.manualfocus.Controls.Add(this.btnChange);
            this.manualfocus.Controls.Add(this.hScrollBarFocus);
            this.manualfocus.Controls.Add(this.btnaddfocus);
            this.manualfocus.Controls.Add(this.btnminusfocus);
            this.manualfocus.Controls.Add(this.txtFocus);
            this.manualfocus.Enabled = false;
            this.manualfocus.Location = new System.Drawing.Point(22, 142);
            this.manualfocus.Name = "manualfocus";
            this.manualfocus.Size = new System.Drawing.Size(356, 131);
            this.manualfocus.TabIndex = 1;
            this.manualfocus.TabStop = false;
            this.manualfocus.Text = "Manual Focus";
            // 
            // lblFocus
            // 
            this.lblFocus.AutoSize = true;
            this.lblFocus.ForeColor = System.Drawing.Color.Black;
            this.lblFocus.Location = new System.Drawing.Point(153, 85);
            this.lblFocus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFocus.Name = "lblFocus";
            this.lblFocus.Size = new System.Drawing.Size(49, 13);
            this.lblFocus.TabIndex = 3;
            this.lblFocus.Text = "Status :  ";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(219, 27);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(67, 23);
            this.btnChange.TabIndex = 67;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // hScrollBarFocus
            // 
            this.hScrollBarFocus.LargeChange = 1;
            this.hScrollBarFocus.Location = new System.Drawing.Point(7, 62);
            this.hScrollBarFocus.Maximum = 1024;
            this.hScrollBarFocus.Name = "hScrollBarFocus";
            this.hScrollBarFocus.Size = new System.Drawing.Size(346, 21);
            this.hScrollBarFocus.TabIndex = 64;
            this.hScrollBarFocus.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarFocus_Scroll);
            // 
            // btnaddfocus
            // 
            this.btnaddfocus.Location = new System.Drawing.Point(188, 29);
            this.btnaddfocus.Name = "btnaddfocus";
            this.btnaddfocus.Size = new System.Drawing.Size(26, 22);
            this.btnaddfocus.TabIndex = 2;
            this.btnaddfocus.Text = ">";
            this.btnaddfocus.UseVisualStyleBackColor = true;
            this.btnaddfocus.Click += new System.EventHandler(this.btnaddfocus_Click);
            // 
            // btnminusfocus
            // 
            this.btnminusfocus.Location = new System.Drawing.Point(99, 29);
            this.btnminusfocus.Name = "btnminusfocus";
            this.btnminusfocus.Size = new System.Drawing.Size(26, 22);
            this.btnminusfocus.TabIndex = 1;
            this.btnminusfocus.Text = "<";
            this.btnminusfocus.UseVisualStyleBackColor = true;
            this.btnminusfocus.Click += new System.EventHandler(this.btnminusfocus_Click);
            // 
            // txtFocus
            // 
            this.txtFocus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFocus.Location = new System.Drawing.Point(130, 32);
            this.txtFocus.Name = "txtFocus";
            this.txtFocus.Size = new System.Drawing.Size(51, 20);
            this.txtFocus.TabIndex = 0;
            this.txtFocus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SerialPort
            // 
            this.SerialPort.Controls.Add(this.lblPort);
            this.SerialPort.Controls.Add(this.btn_connectport);
            this.SerialPort.Controls.Add(this.portoption);
            this.SerialPort.Location = new System.Drawing.Point(22, 39);
            this.SerialPort.Name = "SerialPort";
            this.SerialPort.Size = new System.Drawing.Size(356, 84);
            this.SerialPort.TabIndex = 0;
            this.SerialPort.TabStop = false;
            this.SerialPort.Text = "Choose Serial Port";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.ForeColor = System.Drawing.Color.Red;
            this.lblPort.Location = new System.Drawing.Point(153, 58);
            this.lblPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(79, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Status :  Offline";
            // 
            // btn_connectport
            // 
            this.btn_connectport.Location = new System.Drawing.Point(206, 27);
            this.btn_connectport.Name = "btn_connectport";
            this.btn_connectport.Size = new System.Drawing.Size(75, 23);
            this.btn_connectport.TabIndex = 1;
            this.btn_connectport.Text = "Connect";
            this.btn_connectport.UseVisualStyleBackColor = true;
            this.btn_connectport.Click += new System.EventHandler(this.btn_connectport_Click);
            // 
            // portoption
            // 
            this.portoption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portoption.FormattingEnabled = true;
            this.portoption.Location = new System.Drawing.Point(73, 29);
            this.portoption.Name = "portoption";
            this.portoption.Size = new System.Drawing.Size(121, 21);
            this.portoption.TabIndex = 0;
            this.portoption.SelectedIndexChanged += new System.EventHandler(this.portoption_SelectedIndexChanged);
            // 
            // btnStartCamera
            // 
            this.btnStartCamera.Location = new System.Drawing.Point(218, 504);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Size = new System.Drawing.Size(103, 29);
            this.btnStartCamera.TabIndex = 2;
            this.btnStartCamera.Text = "Start";
            this.btnStartCamera.UseVisualStyleBackColor = true;
            this.btnStartCamera.Click += new System.EventHandler(this.btnStartCamera_Click);
            // 
            // heightsensor
            // 
            this.heightsensor.Controls.Add(this.SerialPort2);
            this.heightsensor.Enabled = false;
            this.heightsensor.Location = new System.Drawing.Point(587, 450);
            this.heightsensor.Name = "heightsensor";
            this.heightsensor.Size = new System.Drawing.Size(390, 216);
            this.heightsensor.TabIndex = 3;
            this.heightsensor.TabStop = false;
            this.heightsensor.Text = "Height Sensor";
            // 
            // SerialPort2
            // 
            this.SerialPort2.Controls.Add(this.txtHeight);
            this.SerialPort2.Controls.Add(this.lblCurrentHeight);
            this.SerialPort2.Controls.Add(this.lblPort1);
            this.SerialPort2.Controls.Add(this.btn_connectport1);
            this.SerialPort2.Controls.Add(this.portoption1);
            this.SerialPort2.Location = new System.Drawing.Point(22, 30);
            this.SerialPort2.Name = "SerialPort2";
            this.SerialPort2.Size = new System.Drawing.Size(356, 166);
            this.SerialPort2.TabIndex = 1;
            this.SerialPort2.TabStop = false;
            this.SerialPort2.Text = "Choose Serial Port";
            // 
            // txtHeight
            // 
            this.txtHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeight.Enabled = false;
            this.txtHeight.Location = new System.Drawing.Point(176, 98);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(110, 20);
            this.txtHeight.TabIndex = 69;
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCurrentHeight
            // 
            this.lblCurrentHeight.AutoSize = true;
            this.lblCurrentHeight.Location = new System.Drawing.Point(123, 100);
            this.lblCurrentHeight.Name = "lblCurrentHeight";
            this.lblCurrentHeight.Size = new System.Drawing.Size(47, 13);
            this.lblCurrentHeight.TabIndex = 68;
            this.lblCurrentHeight.Text = "Current :";
            // 
            // lblPort1
            // 
            this.lblPort1.AutoSize = true;
            this.lblPort1.ForeColor = System.Drawing.Color.Red;
            this.lblPort1.Location = new System.Drawing.Point(153, 73);
            this.lblPort1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort1.Name = "lblPort1";
            this.lblPort1.Size = new System.Drawing.Size(79, 13);
            this.lblPort1.TabIndex = 2;
            this.lblPort1.Text = "Status :  Offline";
            // 
            // btn_connectport1
            // 
            this.btn_connectport1.Location = new System.Drawing.Point(206, 42);
            this.btn_connectport1.Name = "btn_connectport1";
            this.btn_connectport1.Size = new System.Drawing.Size(75, 23);
            this.btn_connectport1.TabIndex = 1;
            this.btn_connectport1.Text = "Connect";
            this.btn_connectport1.UseVisualStyleBackColor = true;
            this.btn_connectport1.Click += new System.EventHandler(this.btn_connectport1_Click);
            // 
            // portoption1
            // 
            this.portoption1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portoption1.FormattingEnabled = true;
            this.portoption1.Location = new System.Drawing.Point(73, 44);
            this.portoption1.Name = "portoption1";
            this.portoption1.Size = new System.Drawing.Size(121, 21);
            this.portoption1.TabIndex = 0;
            // 
            // lblexposure
            // 
            this.lblexposure.AutoSize = true;
            this.lblexposure.Location = new System.Drawing.Point(61, 75);
            this.lblexposure.Name = "lblexposure";
            this.lblexposure.Size = new System.Drawing.Size(99, 13);
            this.lblexposure.TabIndex = 4;
            this.lblexposure.Text = "Camera Exposure : ";
            // 
            // txtexposure
            // 
            this.txtexposure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtexposure.Location = new System.Drawing.Point(167, 75);
            this.txtexposure.Name = "txtexposure";
            this.txtexposure.Size = new System.Drawing.Size(100, 20);
            this.txtexposure.TabIndex = 5;
            this.txtexposure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnApplyExposure
            // 
            this.btnApplyExposure.Location = new System.Drawing.Point(294, 71);
            this.btnApplyExposure.Name = "btnApplyExposure";
            this.btnApplyExposure.Size = new System.Drawing.Size(75, 23);
            this.btnApplyExposure.TabIndex = 6;
            this.btnApplyExposure.Text = "Apply";
            this.btnApplyExposure.UseVisualStyleBackColor = true;
            this.btnApplyExposure.Click += new System.EventHandler(this.btnApplyExposure_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 678);
            this.Controls.Add(this.btnApplyExposure);
            this.Controls.Add(this.txtexposure);
            this.Controls.Add(this.lblexposure);
            this.Controls.Add(this.heightsensor);
            this.Controls.Add(this.btnStartCamera);
            this.Controls.Add(this.LiquidLens);
            this.Controls.Add(this.BaslerImage);
            this.Name = "Form1";
            this.Text = "Height Sensor";
            ((System.ComponentModel.ISupportInitialize)(this.BaslerImage)).EndInit();
            this.LiquidLens.ResumeLayout(false);
            this.gearsetting.ResumeLayout(false);
            this.gearsetting.PerformLayout();
            this.manualfocus.ResumeLayout(false);
            this.manualfocus.PerformLayout();
            this.SerialPort.ResumeLayout(false);
            this.SerialPort.PerformLayout();
            this.heightsensor.ResumeLayout(false);
            this.SerialPort2.ResumeLayout(false);
            this.SerialPort2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BaslerImage;
        private System.Windows.Forms.GroupBox LiquidLens;
        private System.Windows.Forms.GroupBox SerialPort;
        private System.Windows.Forms.ComboBox portoption;
        private System.Windows.Forms.Button btn_connectport;
        private System.Windows.Forms.GroupBox manualfocus;
        private System.Windows.Forms.HScrollBar hScrollBarFocus;
        private System.Windows.Forms.Button btnaddfocus;
        private System.Windows.Forms.Button btnminusfocus;
        private System.Windows.Forms.TextBox txtFocus;
        private System.Windows.Forms.GroupBox gearsetting;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnF5;
        private System.Windows.Forms.Button btnF2;
        private System.Windows.Forms.Button btnF3;
        private System.Windows.Forms.Button btnF4;
        private System.Windows.Forms.Button btnF1;
        private System.Windows.Forms.TextBox txtGear;
        private System.Windows.Forms.Label lblCurrentGear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveGear;
        private System.Windows.Forms.Button btnStartCamera;
        private Label lblPort;
        private Label lblFocus;
        private GroupBox heightsensor;
        private GroupBox SerialPort2;
        private TextBox txtHeight;
        private Label lblCurrentHeight;
        private Label lblPort1;
        private Button btn_connectport1;
        private ComboBox portoption1;
        private Label lblexposure;
        private TextBox txtexposure;
        private Button btnApplyExposure;
    }
}

