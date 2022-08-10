namespace Controls_1
{
    partial class WebCamCtrl_1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebCamCtrl_1));
            this.comboBoxCameras = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.trackBrightness = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.trackContrast = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.chkGrayScale = new System.Windows.Forms.CheckBox();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.lblZoomingFactor = new System.Windows.Forms.Label();
            this.btnStartRecording = new System.Windows.Forms.Button();
            this.btnStopRecording = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnStream = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackContrast)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.Location = new System.Drawing.Point(167, 7);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(153, 21);
            this.comboBoxCameras.TabIndex = 16;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(86, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(5, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // trackBrightness
            // 
            this.trackBrightness.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trackBrightness.LargeChange = 1;
            this.trackBrightness.Location = new System.Drawing.Point(3, 44);
            this.trackBrightness.Name = "trackBrightness";
            this.trackBrightness.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBrightness.Size = new System.Drawing.Size(45, 104);
            this.trackBrightness.TabIndex = 18;
            this.trackBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBrightness.Value = 5;
            this.trackBrightness.Visible = false;
            this.trackBrightness.Scroll += new System.EventHandler(this.trackBrightness_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 10);
            this.label1.TabIndex = 19;
            this.label1.Tag = "Brightness";
            this.label1.Text = "Brightness";
            this.label1.Visible = false;
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.BackColor = System.Drawing.Color.Black;
            this.pictureBoxDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxDisplay.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(445, 262);
            this.pictureBoxDisplay.TabIndex = 17;
            this.pictureBoxDisplay.TabStop = false;
            this.pictureBoxDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDisplay_Paint);
            // 
            // trackContrast
            // 
            this.trackContrast.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.trackContrast.LargeChange = 1;
            this.trackContrast.Location = new System.Drawing.Point(55, 62);
            this.trackContrast.Name = "trackContrast";
            this.trackContrast.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackContrast.Size = new System.Drawing.Size(45, 104);
            this.trackContrast.TabIndex = 24;
            this.trackContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackContrast.Value = 5;
            this.trackContrast.Visible = false;
            this.trackContrast.Scroll += new System.EventHandler(this.trackContrast_Scroll);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 10);
            this.label2.TabIndex = 25;
            this.label2.Tag = "Contrast";
            this.label2.Text = "Contrast";
            this.label2.Visible = false;
            // 
            // chkGrayScale
            // 
            this.chkGrayScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkGrayScale.AutoSize = true;
            this.chkGrayScale.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGrayScale.Location = new System.Drawing.Point(12, 181);
            this.chkGrayScale.Name = "chkGrayScale";
            this.chkGrayScale.Size = new System.Drawing.Size(74, 17);
            this.chkGrayScale.TabIndex = 26;
            this.chkGrayScale.Text = "GrayScale";
            this.chkGrayScale.UseVisualStyleBackColor = true;
            this.chkGrayScale.Visible = false;
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSnapshot.Enabled = false;
            this.btnSnapshot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnapshot.Location = new System.Drawing.Point(395, 101);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(45, 23);
            this.btnSnapshot.TabIndex = 27;
            this.btnSnapshot.Text = "Snap";
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Visible = false;
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
            // 
            // lblZoomingFactor
            // 
            this.lblZoomingFactor.AutoSize = true;
            this.lblZoomingFactor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZoomingFactor.Location = new System.Drawing.Point(52, 44);
            this.lblZoomingFactor.Name = "lblZoomingFactor";
            this.lblZoomingFactor.Size = new System.Drawing.Size(58, 13);
            this.lblZoomingFactor.TabIndex = 29;
            this.lblZoomingFactor.Text = "Zoom: 100";
            this.lblZoomingFactor.Visible = false;
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartRecording.Enabled = false;
            this.btnStartRecording.Image = ((System.Drawing.Image)(resources.GetObject("btnStartRecording.Image")));
            this.btnStartRecording.Location = new System.Drawing.Point(395, 5);
            this.btnStartRecording.Name = "btnStartRecording";
            this.btnStartRecording.Size = new System.Drawing.Size(45, 46);
            this.btnStartRecording.TabIndex = 31;
            this.btnStartRecording.UseVisualStyleBackColor = true;
            this.btnStartRecording.Visible = false;
            this.btnStartRecording.Click += new System.EventHandler(this.btnStartRecording_Click);
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopRecording.Enabled = false;
            this.btnStopRecording.Image = ((System.Drawing.Image)(resources.GetObject("btnStopRecording.Image")));
            this.btnStopRecording.Location = new System.Drawing.Point(395, 53);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(45, 46);
            this.btnStopRecording.TabIndex = 32;
            this.btnStopRecording.UseVisualStyleBackColor = true;
            this.btnStopRecording.Visible = false;
            this.btnStopRecording.Click += new System.EventHandler(this.btnStopRecording_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.comboBoxCameras);
            this.panel1.Location = new System.Drawing.Point(0, 231);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 31);
            this.panel1.TabIndex = 33;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.BackColor = System.Drawing.Color.Black;
            this.lblCurrentStatus.ForeColor = System.Drawing.Color.White;
            this.lblCurrentStatus.Location = new System.Drawing.Point(339, 215);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentStatus.TabIndex = 34;
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Location = new System.Drawing.Point(12, 202);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(75, 23);
            this.btnFullScreen.TabIndex = 35;
            this.btnFullScreen.Text = "button1";
            this.btnFullScreen.UseVisualStyleBackColor = true;
            this.btnFullScreen.Visible = false;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.Location = new System.Drawing.Point(408, 227);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(34, 32);
            this.btnConfig.TabIndex = 36;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnStream
            // 
            this.btnStream.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStream.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStream.Location = new System.Drawing.Point(395, 130);
            this.btnStream.Name = "btnStream";
            this.btnStream.Size = new System.Drawing.Size(45, 23);
            this.btnStream.TabIndex = 37;
            this.btnStream.Text = "Stream";
            this.btnStream.UseVisualStyleBackColor = true;
            this.btnStream.Visible = false;
            this.btnStream.Click += new System.EventHandler(this.btnStream_Click);
            // 
            // WebCamCtrl_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStream);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnFullScreen);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStopRecording);
            this.Controls.Add(this.btnStartRecording);
            this.Controls.Add(this.lblZoomingFactor);
            this.Controls.Add(this.btnSnapshot);
            this.Controls.Add(this.chkGrayScale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackContrast);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBrightness);
            this.Controls.Add(this.pictureBoxDisplay);
            this.Name = "WebCamCtrl_1";
            this.Size = new System.Drawing.Size(445, 262);
            this.Load += new System.EventHandler(this.WebCamCtrl_1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackContrast)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCameras;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TrackBar trackBrightness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.TrackBar trackContrast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkGrayScale;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.Label lblZoomingFactor;
        private System.Windows.Forms.Button btnStartRecording;
        private System.Windows.Forms.Button btnStopRecording;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnStream;
    }
}
