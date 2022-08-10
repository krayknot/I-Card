namespace I_Card
{
    partial class frmTakePicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTakePicture));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStartCapture = new System.Windows.Forms.Button();
            this.lstCameras = new System.Windows.Forms.ListBox();
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.picImagePreview = new System.Windows.Forms.PictureBox();
            this.picLastImage = new System.Windows.Forms.PictureBox();
            this.btnTakePicture = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnCameraInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLastImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(609, 306);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStartCapture
            // 
            this.btnStartCapture.Image = ((System.Drawing.Image)(resources.GetObject("btnStartCapture.Image")));
            this.btnStartCapture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartCapture.Location = new System.Drawing.Point(12, 306);
            this.btnStartCapture.Name = "btnStartCapture";
            this.btnStartCapture.Size = new System.Drawing.Size(97, 26);
            this.btnStartCapture.TabIndex = 1;
            this.btnStartCapture.Text = "&Start Capture";
            this.btnStartCapture.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartCapture.UseVisualStyleBackColor = true;
            this.btnStartCapture.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstCameras
            // 
            this.lstCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCameras.FormattingEnabled = true;
            this.lstCameras.Location = new System.Drawing.Point(3, 17);
            this.lstCameras.Name = "lstCameras";
            this.lstCameras.Size = new System.Drawing.Size(194, 279);
            this.lstCameras.TabIndex = 2;
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDisplay.Location = new System.Drawing.Point(8, 20);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(466, 273);
            this.pictureBoxDisplay.TabIndex = 14;
            this.pictureBoxDisplay.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCameraInfo);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.picImagePreview);
            this.groupBox1.Controls.Add(this.picLastImage);
            this.groupBox1.Controls.Add(this.btnTakePicture);
            this.groupBox1.Controls.Add(this.pictureBoxDisplay);
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 299);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Output";
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(398, 255);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 36);
            this.button3.TabIndex = 20;
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // picImagePreview
            // 
            this.picImagePreview.Location = new System.Drawing.Point(214, 183);
            this.picImagePreview.Name = "picImagePreview";
            this.picImagePreview.Size = new System.Drawing.Size(100, 50);
            this.picImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImagePreview.TabIndex = 19;
            this.picImagePreview.TabStop = false;
            this.picImagePreview.Visible = false;
            // 
            // picLastImage
            // 
            this.picLastImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLastImage.Image = ((System.Drawing.Image)(resources.GetObject("picLastImage.Image")));
            this.picLastImage.Location = new System.Drawing.Point(429, 24);
            this.picLastImage.Name = "picLastImage";
            this.picLastImage.Size = new System.Drawing.Size(40, 34);
            this.picLastImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLastImage.TabIndex = 19;
            this.picLastImage.TabStop = false;
            this.picLastImage.Click += new System.EventHandler(this.picLastImage_Click);
            // 
            // btnTakePicture
            // 
            this.btnTakePicture.Image = ((System.Drawing.Image)(resources.GetObject("btnTakePicture.Image")));
            this.btnTakePicture.Location = new System.Drawing.Point(436, 255);
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.Size = new System.Drawing.Size(36, 36);
            this.btnTakePicture.TabIndex = 19;
            this.btnTakePicture.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTakePicture.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTakePicture.UseVisualStyleBackColor = true;
            this.btnTakePicture.Click += new System.EventHandler(this.btnTakePicture_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstCameras);
            this.groupBox2.Location = new System.Drawing.Point(490, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 299);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera Devices";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(115, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 26);
            this.button1.TabIndex = 17;
            this.button1.Text = "S&top Capture";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(218, 306);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 26);
            this.button2.TabIndex = 18;
            this.button2.Text = "&Refresh Cameras";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(517, 306);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(89, 26);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files|*.jpg";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.Location = new System.Drawing.Point(422, 306);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(89, 26);
            this.btnPrevious.TabIndex = 20;
            this.btnPrevious.Text = "&Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnCameraInfo
            // 
            this.btnCameraInfo.Location = new System.Drawing.Point(30, 262);
            this.btnCameraInfo.Name = "btnCameraInfo";
            this.btnCameraInfo.Size = new System.Drawing.Size(75, 23);
            this.btnCameraInfo.TabIndex = 21;
            this.btnCameraInfo.Text = "button4";
            this.btnCameraInfo.UseVisualStyleBackColor = true;
            this.btnCameraInfo.Visible = false;
            this.btnCameraInfo.Click += new System.EventHandler(this.btnCameraInfo_Click);
            // 
            // frmTakePicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 337);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStartCapture);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTakePicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take Picture";
            this.Load += new System.EventHandler(this.frmTakePicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLastImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStartCapture;
        private System.Windows.Forms.ListBox lstCameras;
        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTakePicture;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox picLastImage;
        private System.Windows.Forms.PictureBox picImagePreview;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnCameraInfo;
    }
}