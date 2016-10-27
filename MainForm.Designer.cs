namespace MoveMaster
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.ComCombo = new System.Windows.Forms.ComboBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.leftWaist = new System.Windows.Forms.Button();
            this.rigthWaist = new System.Windows.Forms.Button();
            this.leftShoulder = new System.Windows.Forms.Button();
            this.rightShoulder = new System.Windows.Forms.Button();
            this.yPos = new System.Windows.Forms.Button();
            this.yNeg = new System.Windows.Forms.Button();
            this.initialPos = new System.Windows.Forms.Button();
            this.androidConnect = new System.Windows.Forms.Button();
            this.rstbtn = new System.Windows.Forms.Button();
            this.sendCommandBtn = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.loopBoxTxtbox = new System.Windows.Forms.TextBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(199, 15);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 31);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "2. Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(305, 15);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(100, 31);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // serialPort
            // 
            this.serialPort.Parity = System.IO.Ports.Parity.Even;
            this.serialPort.StopBits = System.IO.Ports.StopBits.Two;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // ComCombo
            // 
            this.ComCombo.FormattingEnabled = true;
            this.ComCombo.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.ComCombo.Location = new System.Drawing.Point(16, 18);
            this.ComCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ComCombo.Name = "ComCombo";
            this.ComCombo.Size = new System.Drawing.Size(160, 24);
            this.ComCombo.TabIndex = 0;
            this.ComCombo.Text = "1. Serial Port";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(117, 7);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(125, 31);
            this.connectBtn.TabIndex = 2;
            this.connectBtn.Text = "3. Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // leftWaist
            // 
            this.leftWaist.Location = new System.Drawing.Point(61, 10);
            this.leftWaist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leftWaist.Name = "leftWaist";
            this.leftWaist.Size = new System.Drawing.Size(119, 31);
            this.leftWaist.TabIndex = 7;
            this.leftWaist.Text = "<- waist";
            this.leftWaist.UseVisualStyleBackColor = true;
            this.leftWaist.Click += new System.EventHandler(this.leftWaist_Click);
            // 
            // rigthWaist
            // 
            this.rigthWaist.Location = new System.Drawing.Point(185, 10);
            this.rigthWaist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rigthWaist.Name = "rigthWaist";
            this.rigthWaist.Size = new System.Drawing.Size(120, 31);
            this.rigthWaist.TabIndex = 8;
            this.rigthWaist.Text = "waist ->";
            this.rigthWaist.UseVisualStyleBackColor = true;
            this.rigthWaist.Click += new System.EventHandler(this.rigthWaist_Click);
            // 
            // leftShoulder
            // 
            this.leftShoulder.Location = new System.Drawing.Point(61, 47);
            this.leftShoulder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leftShoulder.Name = "leftShoulder";
            this.leftShoulder.Size = new System.Drawing.Size(119, 31);
            this.leftShoulder.TabIndex = 9;
            this.leftShoulder.Text = "<- shoulder";
            this.leftShoulder.UseVisualStyleBackColor = true;
            this.leftShoulder.Click += new System.EventHandler(this.leftShoulder_Click);
            // 
            // rightShoulder
            // 
            this.rightShoulder.Location = new System.Drawing.Point(185, 46);
            this.rightShoulder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rightShoulder.Name = "rightShoulder";
            this.rightShoulder.Size = new System.Drawing.Size(120, 31);
            this.rightShoulder.TabIndex = 10;
            this.rightShoulder.Text = "shoulder ->";
            this.rightShoulder.UseVisualStyleBackColor = true;
            this.rightShoulder.Click += new System.EventHandler(this.rightShoulder_Click);
            // 
            // yPos
            // 
            this.yPos.Location = new System.Drawing.Point(61, 84);
            this.yPos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.yPos.Name = "yPos";
            this.yPos.Size = new System.Drawing.Size(119, 31);
            this.yPos.TabIndex = 11;
            this.yPos.Text = "<- elbow";
            this.yPos.UseVisualStyleBackColor = true;
            this.yPos.Click += new System.EventHandler(this.yPos_Click);
            // 
            // yNeg
            // 
            this.yNeg.Location = new System.Drawing.Point(185, 84);
            this.yNeg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.yNeg.Name = "yNeg";
            this.yNeg.Size = new System.Drawing.Size(120, 31);
            this.yNeg.TabIndex = 12;
            this.yNeg.Text = "elbow ->";
            this.yNeg.UseVisualStyleBackColor = true;
            this.yNeg.Click += new System.EventHandler(this.yNeg_Click);
            // 
            // initialPos
            // 
            this.initialPos.Location = new System.Drawing.Point(117, 46);
            this.initialPos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.initialPos.Name = "initialPos";
            this.initialPos.Size = new System.Drawing.Size(125, 31);
            this.initialPos.TabIndex = 3;
            this.initialPos.Text = "4. initialPos";
            this.initialPos.UseVisualStyleBackColor = true;
            this.initialPos.Click += new System.EventHandler(this.initialPos_Click);
            // 
            // androidConnect
            // 
            this.androidConnect.Location = new System.Drawing.Point(117, 84);
            this.androidConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.androidConnect.Name = "androidConnect";
            this.androidConnect.Size = new System.Drawing.Size(125, 28);
            this.androidConnect.TabIndex = 4;
            this.androidConnect.Text = "5. Listen UDP";
            this.androidConnect.UseVisualStyleBackColor = true;
            this.androidConnect.Click += new System.EventHandler(this.androidConnect_Click);
            // 
            // rstbtn
            // 
            this.rstbtn.Location = new System.Drawing.Point(117, 119);
            this.rstbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rstbtn.Name = "rstbtn";
            this.rstbtn.Size = new System.Drawing.Size(125, 28);
            this.rstbtn.TabIndex = 19;
            this.rstbtn.Text = "Reset";
            this.rstbtn.UseVisualStyleBackColor = true;
            this.rstbtn.Click += new System.EventHandler(this.rstbtn_Click);
            // 
            // sendCommandBtn
            // 
            this.sendCommandBtn.Location = new System.Drawing.Point(271, 123);
            this.sendCommandBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendCommandBtn.Name = "sendCommandBtn";
            this.sendCommandBtn.Size = new System.Drawing.Size(100, 31);
            this.sendCommandBtn.TabIndex = 5;
            this.sendCommandBtn.Text = "Send Command";
            this.sendCommandBtn.UseVisualStyleBackColor = true;
            this.sendCommandBtn.Click += new System.EventHandler(this.sendCommandBtn_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(16, 245);
            this.textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(383, 164);
            this.textBox.TabIndex = 5;
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnTextboxKeyPress);
            // 
            // loopBoxTxtbox
            // 
            this.loopBoxTxtbox.AcceptsReturn = true;
            this.loopBoxTxtbox.Location = new System.Drawing.Point(4, 9);
            this.loopBoxTxtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loopBoxTxtbox.Multiline = true;
            this.loopBoxTxtbox.Name = "loopBoxTxtbox";
            this.loopBoxTxtbox.ReadOnly = true;
            this.loopBoxTxtbox.Size = new System.Drawing.Size(365, 110);
            this.loopBoxTxtbox.TabIndex = 4;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.Location = new System.Drawing.Point(16, 57);
            this.tabs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(389, 186);
            this.tabs.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.connectBtn);
            this.tabPage1.Controls.Add(this.rstbtn);
            this.tabPage1.Controls.Add(this.initialPos);
            this.tabPage1.Controls.Add(this.androidConnect);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(381, 157);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.yNeg);
            this.tabPage2.Controls.Add(this.leftWaist);
            this.tabPage2.Controls.Add(this.yPos);
            this.tabPage2.Controls.Add(this.rigthWaist);
            this.tabPage2.Controls.Add(this.rightShoulder);
            this.tabPage2.Controls.Add(this.leftShoulder);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(381, 157);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manual Control";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.sendCommandBtn);
            this.tabPage3.Controls.Add(this.loopBoxTxtbox);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(381, 157);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Console";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 427);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.ComCombo);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "RoboVision";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox ComCombo;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button leftWaist;
        private System.Windows.Forms.Button rigthWaist;
        private System.Windows.Forms.Button leftShoulder;
        private System.Windows.Forms.Button rightShoulder;
        private System.Windows.Forms.Button yPos;
        private System.Windows.Forms.Button yNeg;
        private System.Windows.Forms.Button initialPos;
        private System.Windows.Forms.Button androidConnect;
        private System.Windows.Forms.Button rstbtn;
        private System.Windows.Forms.Button sendCommandBtn;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TextBox loopBoxTxtbox;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}

