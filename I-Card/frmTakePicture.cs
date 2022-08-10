using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Touchless.Vision.Camera;

namespace I_Card
{
    public partial class frmTakePicture : Form
    {

        string filename = string.Empty;

        public frmTakePicture()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                _frameSource.StopFrameCapture();
                thrashOldCamera();
            }
            catch (Exception)
            {


            }
            
            this.Close();
        }

        private CameraFrameSource _frameSource;
        private static Bitmap _latestFrame;

        private System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"camera-shutter-click-01.wav");

        private void button1_Click(object sender, EventArgs e)
        {
            // Early return if we've selected the current camera
            if (_frameSource != null && _frameSource.Camera == lstCameras.SelectedItem)
                return;

            thrashOldCamera();
            startCapturing();
        }

        private void frmTakePicture_Load(object sender, EventArgs e)
        {
            // Refresh the list of available cameras
            lstCameras.Items.Clear();
            foreach (Camera cam in CameraService.AvailableCameras)
                lstCameras.Items.Add(cam);

            if (lstCameras.Items.Count > 0)
                lstCameras.SelectedIndex = 0;
        }

        private void thrashOldCamera()
        {
            // Trash the old camera
            if (_frameSource != null)
            {
                _frameSource.NewFrame -= OnImageCaptured;
                _frameSource.Camera.Dispose();
                setFrameSource(null);
                pictureBoxDisplay.Paint -= new PaintEventHandler(drawLatestImage);
            }
        }

        public void OnImageCaptured(Touchless.Vision.Contracts.IFrameSource frameSource, Touchless.Vision.Contracts.Frame frame, double fps)
        {
            _latestFrame = frame.Image;
            pictureBoxDisplay.Invalidate();
        }

        private void setFrameSource(CameraFrameSource cameraFrameSource)
        {
            if (_frameSource == cameraFrameSource)
                return;

            _frameSource = cameraFrameSource;
        }

        private void startCapturing()
        {
            try
            {
                Camera c = (Camera)lstCameras.SelectedItem;
                setFrameSource(new CameraFrameSource(c));
                _frameSource.Camera.CaptureWidth = 320;
                _frameSource.Camera.CaptureHeight = 240;
                _frameSource.Camera.Fps = 20;
                _frameSource.NewFrame += OnImageCaptured;

                pictureBoxDisplay.Paint += new PaintEventHandler(drawLatestImage);
                _frameSource.StartFrameCapture();

                //c.IsGrayScale = grayScaleSetting;
            }
            catch (Exception ex)
            {
                //comboBoxCameras.Text = "Select A Camera";
                MessageBox.Show(ex.Message);
            }
        }

        private void drawLatestImage(object sender, PaintEventArgs e)
        {
            if (_latestFrame != null)
            {
                // Draw the latest image from the active camera

                //if (chkGrayScale.CheckState == CheckState.Checked)
                //{


                //    //e.Graphics.DrawImage(GrayScaleImage(_latestFrame), 0, 0, _latestFrame.Width, _latestFrame.Height);
                //}
                //else
                //{
                //    e.Graphics.DrawImage(_latestFrame, 0, 0, _latestFrame.Width, _latestFrame.Height);
                //}

                e.Graphics.DrawImage(_latestFrame, 0, 0, _latestFrame.Width, _latestFrame.Height);
            }
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            clsCommon common = new clsCommon();
            player.Play();

            //Image name
            //Image name will be incremented as perthe count. Last count value will be saved in registry
            //Image name = ICard-Date()-Count from registry
            //Get the Last image count from registry
            string lastCountString = common.Read("ICARD");
            int lastCountInteger = 0;
            filename = "ICard--" + DateTime.Now.Date.ToString() + "--";

            if (lastCountString != null) //If the registry value is null then the last value will set to 1
            {
                if (lastCountString.Length < 1)
                {
                    lastCountString = "1";
                }
            }
            else
            {
                lastCountString = "1";
            }


            try //If the registry is not number or externally set to any string then it will throw an error and in the catch it will reset the value to 1
            {
                lastCountInteger = Convert.ToInt32(lastCountString);
            }
            catch (Exception)
            {
                lastCountInteger = 1;
            }

            //Increment the count to 1
            lastCountInteger = lastCountInteger + 1;
            filename = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/" + (lastCountInteger + 1).ToString() + ".bmp";

            Bitmap bmp = new Bitmap(pictureBoxDisplay.Width, pictureBoxDisplay.Height);
            pictureBoxDisplay.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
            bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp);

            //Save the last value in registry as lastCount
            common.Write("ICARD", lastCountInteger.ToString());

            picImagePreview.Visible = true;            

            picImagePreview.ImageLocation = filename;
            picImagePreview.Top = pictureBoxDisplay.Top;
            picImagePreview.Left = pictureBoxDisplay.Left;
            picImagePreview.SendToBack();
            picImagePreview.Refresh();
            System.Threading.Thread.Sleep(1000);

            picImagePreview.Visible = false;

            picLastImage.ImageLocation = filename;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clsCommon.imagePath = filename;

            try
            {
                _frameSource.StopFrameCapture();
                thrashOldCamera();
            }
            catch (Exception)
            {
                
                
            }
           

            this.Hide();
            new frmConfigureImage().ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            _frameSource.StopFrameCapture();
            thrashOldCamera();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _frameSource.StopFrameCapture();
                thrashOldCamera();
            }
            catch (Exception)
            {
                
                //throw;
            }
            

            // Refresh the list of available cameras
            lstCameras.Items.Clear();
            foreach (Camera cam in CameraService.AvailableCameras)
                lstCameras.Items.Add(cam);

            if (lstCameras.Items.Count > 0)
                lstCameras.SelectedIndex = 0;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The image size should be 466x273 for best viewing in the placeholder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                try
                {
                    _frameSource.StopFrameCapture();
                    thrashOldCamera();
                    picImagePreview.Refresh();
                }
                catch (Exception)
                {

                    //throw;
                }

                Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                pictureBoxDisplay.Image = bmp;


                //picImagePreview.ImageLocation = openFileDialog1.FileName;
                picImagePreview.Refresh();

                btnTakePicture_Click(sender, e);
            }
        }

        private void picLastImage_Click(object sender, EventArgs e)
        {
            if (filename.Length > 0)
            {
                MessageBox.Show("No image to display.\nClick any snap or upload the image.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmApplicationReview().ShowDialog();
        }

        private void btnCameraInfo_Click(object sender, EventArgs e)
        {

        }

        //public void GetCameraInfo()
        //{
        //    _cameraMethods.GetCameraInfo(_index);
        //}
    }
}
