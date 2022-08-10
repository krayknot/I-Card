using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Touchless.Vision.Camera;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
//using AviFile;
using System.IO;
using System.Threading;
//using ClosedCircuit_DAL;
using System.Diagnostics;

namespace Controls_1
{
    public partial class WebCamCtrl_1 : UserControl
    {
        int destWidth = 0;
        int destHeight = 0;

        private const string videoFolder = "VideoLocation1";
        private const string aviBitmapFileName = "image";
        
        private string pathSnapShot = "\\SnapshotLocation1\\";
        private string pathVideo = "\\VideoLocation1\\";

        private delegate void HideRecordingLabel(object item);

        private CameraFrameSource _frameSource;

        private static Bitmap _latestFrame;
        //private static Bitmap _latestFrameBMP;
        string bmpSavePath = string.Empty;

        string bmpFileName = String.Empty;

        Stream fs;

        DateTime dt;

        //AviManager aviManager;
        //VideoStream aviStream;

        //AviManager aviManagerWEBSTREAM;
        //VideoStream aviStreamWEBSTREAM;

        //VideoStream aviStream1;

        private static Bitmap _logoFrame = new Bitmap("E:\\CC sources\\logokrayblack.bmp");
        private int countBMPSaved;

        private int countWEBSTREAMSaved = 0;
        string fileWEBSTREAM = string.Empty;

        private bool STARTRECORDING = false;
        private bool STARTSTREAMING = false;

        private string AVISource = string.Empty;
        private string AVIDestination = string.Empty;

        float b = 0.0f;
        float c = 0.0f;
        float t = 0.0f;

        string filePath = string.Empty; //Vidio file path
        double rate = 8;
        
        Bitmap bmp;
        Bitmap bmpWEBSTREAM;

        Bitmap bitmap; 
        
        public WebCamCtrl_1()
        {
            InitializeComponent();            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Yellow, 0, 0, 100, 100);
        }

        private void WebCamCtrl_1_Load(object sender, EventArgs e)
        {
            String videoPath;
            if (!DesignMode)
            {
                // Refresh the list of available cameras
                comboBoxCameras.Items.Clear();
         
                foreach (Camera cam in CameraService.AvailableCameras)
                {
                    comboBoxCameras.Items.Add(cam);                            
                }

                //clsCommon common = new clsCommon();
                try
                {
                    //if (comboBoxCameras.Items.Count > 0)
                    //    comboBoxCameras.SelectedIndex = Convert.ToInt32(common.Read("Location1Camera"));
                }
                catch (Exception)
                {
                    
                    //throw;
                }

                //Create the folder if not exists
                //if (!Directory.Exists(common.Read("SnapFolder").ToString() + pathSnapShot))
                //    Directory.CreateDirectory(common.Read("SnapFolder").ToString() + pathSnapShot);

                ////Create the folder if not exists
                //if (!Directory.Exists(common.Read("SnapFolder").ToString() + pathSnapShot))
                //    Directory.CreateDirectory(common.Read("SnapFolder").ToString() + pathSnapShot);

                //videoPath = common.Read("VideoFolder").ToString();
                //pathVideo = videoPath + pathVideo;

                ////Create the video folder if it does not exists already.
                //if (!Directory.Exists(String.Concat(videoPath, "\\", videoFolder))) Directory.CreateDirectory(pathVideo);
                //if (!Directory.Exists(String.Concat(videoPath, "\\", videoFolder + "\\Output"))) Directory.CreateDirectory(String.Concat(videoPath, "\\", videoFolder + "\\Output"));

                ////Saves the video snapshot in the selected folder            
                ////---------------------------------------------------------------------------------------               

                //if (common.Read("VideoFolder") != null)
                //{
                //    videoPath = common.Read("VideoFolder");
                //    filePath = String.Concat(videoPath, "\\", videoFolder, "\\");
                //}
                //else
                //{
                //    filePath = Application.ExecutablePath + pathSnapShot + DateTime.Now.Ticks.ToString();
                //}
                //---------------------------------------------------------------------------------------

                //bmp = (Bitmap)Image.FromFile(filePath + "image0.bmp");
                //aviManager = new AviManager(filePath + "Output\\" + DateTime.Now.Ticks.ToString() + ".avi", false);
                //aviStream = aviManager.AddVideoStream(false, rate, new Bitmap(bmp));
                //aviStream1 = aviManager.AddVideoStream(false, rate, new Bitmap(600,400));
            }            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartCamera();
        }

        public void StartCamera()
        {
            // Early return if we've selected the current camera
            if (_frameSource != null && _frameSource.Camera == comboBoxCameras.SelectedItem)
                return;

            btnStartRecording.Enabled = true;
            //btnStopRecording.Enabled = true;
            btnSnapshot.Enabled = true;

            thrashOldCamera();
            startCapturing();
        }

        private void startCapturing()
        {
            try
            {
                Camera c = (Camera)comboBoxCameras.SelectedItem;
                setFrameSource(new CameraFrameSource(c));
                _frameSource.Camera.CaptureWidth = 320;
                _frameSource.Camera.CaptureHeight = 240;
                _frameSource.Camera.Fps = 20;
                _frameSource.NewFrame += OnImageCaptured;

                pictureBoxDisplay.Paint += new PaintEventHandler(drawLatestImage);                              
                _frameSource.StartFrameCapture();
            }
            catch (Exception ex)
            {
                comboBoxCameras.Text = "Select A Camera";
                MessageBox.Show(ex.Message);
            }
        }

        private void drawLatestImage(object sender, PaintEventArgs e)
        {
            //string bmpFileName = String.Empty;
            if (_latestFrame != null)
            {
                //Image resize algo
                int sourceWidth = _latestFrame.Width;
                int sourceHeight = _latestFrame.Height;
                //int sourceX = 0;
                //int sourceY = 0;
                int destX = 0;
                int destY = 0;

                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;

                nPercentW = ((float)pictureBoxDisplay.Width / (float)sourceWidth);
                nPercentH = ((float)pictureBoxDisplay.Height / (float)sourceHeight);
                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = System.Convert.ToInt16((Width -
                                  (sourceWidth * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = System.Convert.ToInt16((Height -
                                  (sourceHeight * nPercent)) / 2);
                }

                destWidth = (int)(sourceWidth * nPercent);
                destHeight = (int)(sourceHeight * nPercent);
                
                if (chkGrayScale.CheckState == CheckState.Checked)
                {
                    //e.Graphics.DrawImage(MakeGrayscale3(_latestFrame), new Rectangle(0, 0, _latestFrame.Width, _latestFrame.Height), 0, 0, _latestFrame.Width, _latestFrame.Height, GraphicsUnit.Pixel, imageAttributes);
                }
                else
                {   
                    //Setting the frame start position x on the picturebox.
                    //If the image not satisfies the destination picturebox dimensions then we resize the image to display it correctly.
                    float imageStartX = 0;
                    
                    if (destWidth < pictureBoxDisplay.Width)
                    {
                        imageStartX = (pictureBoxDisplay.Width - destWidth) / 2;
                    }
                    e.Graphics.DrawImage(_latestFrame, imageStartX,0, destWidth, destHeight);
                }

                dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                e.Graphics.DrawString("krayknot", new Font("Bauhaus 93", 10), Brushes.WhiteSmoke, new RectangleF(10, 10, 90, 40));
                e.Graphics.DrawString(String.Format("{0:dddd, MMMM d, yyyy}", dt) + " | " + DateTime.Now.ToLongTimeString(), new Font("Tahoma", 8), Brushes.White, new RectangleF(10, 25, 200, 40));

                if (STARTRECORDING)
                {
                    //Saves the Bitmap at a particular location
                    //bmpFileName = String.Concat(aviBitmapFileName, countBMPSaved, ".bmp");
                    //_latestFrame.Save(pathVideo + bmpFileName);
                    //countBMPSaved += 1;            

                    //bitmap = new Bitmap(_latestFrame);
                    //aviStream.AddFrame(_latestFrame);
                    //bitmap.Dispose();

                    //Thread th = new Thread(new ThreadStart(SaveBMP));
                    //th.Start();
                }

                if (STARTSTREAMING)
                {
                    //aviStreamWEBSTREAM.AddFrame(_latestFrame);        
                    //if(aviStreamWEBSTREAM.CountFrames >= 50)
                    //{                        
                    //    ResetWEBSTREAM();
                    //}

                }
            }
        }        

        private void SaveBMP()
        {
            //Saves the Bitmap at a particular location
            bmpFileName = String.Concat(aviBitmapFileName, countBMPSaved, ".bmp");            
            _latestFrame.Save(pathVideo + bmpFileName);
            countBMPSaved += 1;    
        }

        private void CreateAVI()
        {
            string videoPath;
            //clsCommon common = new clsCommon();

            ////Saves the snapshot in the selected folder            
            //string filePath = string.Empty;

            //if (common.Read("VideoFolder") != null)
            //{
            //    videoPath = common.Read("VideoFolder");                
            //    filePath = String.Concat(videoPath, "\\", videoFolder, "\\");
            //}
            //else
            //{
            //    filePath = Application.ExecutablePath + pathSnapShot + DateTime.Now.Ticks.ToString();
            //}

            //CamLibrary.clsCamLib camLib = new CamLibrary.clsCamLib();
            //camLib.CreateAvi(0, 20, 5, filePath + "Output\\", filePath, filePath, pathVideo);

            string name = string.Empty;
            if (lblCurrentStatus.InvokeRequired)
            {
                lblCurrentStatus.Invoke(new MethodInvoker(delegate {lblCurrentStatus.Visible = false; }));
            }           
        }

        public void ImposeText()
        {
            //RectangleF rectf = new RectangleF(10, 10, 90, 40);
            //RectangleF rectfTimeStamp = new RectangleF(10, pictureBoxDisplay.Height - 40, 200,40);

            Graphics g = Graphics.FromImage(_latestFrame);
            string overlayText = "krayknot" ;
            
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.DrawString(overlayText, new Font("Bauhaus 93", 10), Brushes.Black, new RectangleF(10, 10, 90, 40));
            g.DrawString(DateTime.Now.ToLongDateString() + " | " + DateTime.Now.ToLongTimeString(), new Font("Verdana", 8), Brushes.Black, new RectangleF(10, pictureBoxDisplay.Height - 40, 200, 40));

            g.Flush();

            //return largeBmp;
        }

        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
      {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
      });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
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
        //

        public void thrashOldCamera()
        {
            // Trash the old camera
            if (_frameSource != null)
            {
                _frameSource.NewFrame -= OnImageCaptured;
                _frameSource.Camera.Dispose();
                setFrameSource(null);
                pictureBoxDisplay.Paint -= new PaintEventHandler(drawLatestImage);

                btnStartRecording.Enabled = false;
                btnStopRecording.Enabled = false;
                btnSnapshot.Enabled = false;
            }
        }

        private void trackBrightness_Scroll(object sender, EventArgs e)
        {
            b = trackBrightness.Value * 0.01f;                    
            float[][] colorMatrixElements = {	new float[] {1,0,0,0,0},
                                                new float[] {0,1,0,0,0},
                                                new float[] {0,0,1,0,0},
                                                new float[] {0,0,0,1,0},
                                                new float[] {b,b,b,0,1}
                                                    };
        }

        private void trackContrast_Scroll(object sender, EventArgs e)
        {
            c = (float)trackContrast.Value / 5;
            t = (1.0f - c) / 2.0f;            

            float[][] colorMatrixElements = {	    new float[] {c,0,0,0,0},
	                                                new float[] {0,c,0,0,0},
	                                                new float[] {0,0,c,0,0},
	                                                new float[] {0,0,0,1,0},
	                                                new float[] {1,1,1,0,1}
                                                        };
        }

        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            //clsCommon common = new clsCommon();

            ////Saves the snapshot in the selected folder            
            //string filePath = string.Empty;

            //if (common.Read("SnapFolder") != null)
            //{
            //    filePath = common.Read("SnapFolder").ToString() + pathSnapShot + DateTime.Now.Ticks.ToString();
            //}
            //else
            //{
            //    filePath = Application.ExecutablePath + pathSnapShot + DateTime.Now.Ticks.ToString();
            //}

            //Bitmap bmpSnapshot = new Bitmap (_latestFrame.Width, _latestFrame.Height);
            //pictureBoxDisplay.DrawToBitmap(bmpSnapshot, new Rectangle(0, 0, _latestFrame.Width, _latestFrame.Height));
            //bmpSnapshot.Save(filePath);
            //bmpSnapshot.Dispose();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            trackBrightness.Value = 5;
            trackContrast.Value = 5;
            chkGrayScale.CheckState = CheckState.Unchecked;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            thrashOldCamera();
        }

        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            //_latestFrame.Save(filePath + "image0.bmp");
            //bmp = (Bitmap)Image.FromFile(filePath + "image0.bmp");
            //aviManager = new AviManager(filePath + "Output\\" + DateTime.Now.Ticks.ToString() + ".avi", false);
            //aviStream = aviManager.AddVideoStream(false, rate, bmp);
            
            //countBMPSaved = 0;
            //STARTRECORDING = true;


            //btnStopRecording.Enabled = true;
            //btnStartRecording.Enabled = false;

            //lblCurrentStatus.Visible = true;
            //lblCurrentStatus.Text = "Recording";
            //lblCurrentStatus.ForeColor = Color.Red;
        }

        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            STARTRECORDING = false;
            //aviManager.Close();

            //Thread thAVI = new Thread(CreateAVI);
            //thAVI.Start();

            btnStopRecording.Enabled = false;
            btnStartRecording.Enabled = true;

            lblCurrentStatus.Text = string.Empty;

            //lblCurrentStatus.Text = "Saving....";
            //lblCurrentStatus.ForeColor = Color.White;
        }

        private void pictureBoxDisplay_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            // snap camera
            if (_frameSource != null)
                _frameSource.Camera.ShowPropertiesDialog();
        }

        private void btnStream_Click(object sender, EventArgs e)
        {
            STARTSTREAMING = true;
            ResetWEBSTREAM();          

            //BasicFTPClientNamespace.BasicFTPClient basicFTP = new BasicFTPClientNamespace.BasicFTPClient();
            //basicFTP.UploadFile("nature.mpg", "E:\\Nature.mpg");                            
        }

        private void ResetWEBSTREAM()
        {           
            
            //Closes the existing WebStream capture and initialize a new one
            //if (aviManagerWEBSTREAM != null)
            //{
            //    aviManagerWEBSTREAM.Close();
            //    bmpWEBSTREAM.Dispose();

            //    AVISource =filePath + "OutputWEBSTREAM\\" + fileWEBSTREAM;
            //    AVIDestination = filePath + "OutputWEBSTREAM\\" + fileWEBSTREAM.Replace("avi", "flv");

            //    Thread th = new Thread(new ThreadStart(AVItoFLV));
            //    th.Start();
                
            //    //aviStreamWEBSTREAM.Close();
            //}

            ////This will maintain only 5 files at a time, and there will be a overwrite each time
            ////Five avi, 5 flv and 5 uploads 
            //if (countWEBSTREAMSaved > 5)
            //{
            //    countWEBSTREAMSaved = 0;
            //}

            //lblCurrentStatus.Visible = true;
            //lblCurrentStatus.Text = countWEBSTREAMSaved.ToString();
            //lblCurrentStatus.ForeColor = Color.Red;

            //countWEBSTREAMSaved++;
            //fileWEBSTREAM = "WEBSTREAM" + countWEBSTREAMSaved.ToString() + ".avi";
            //_latestFrame.Save(filePath + "image0.bmp");
            //bmpWEBSTREAM = (Bitmap)Image.FromFile(filePath + "image0.bmp");            
            
            //aviManagerWEBSTREAM  = new AviManager(filePath + "OutputWEBSTREAM\\" + fileWEBSTREAM, false);
            //aviStreamWEBSTREAM = aviManagerWEBSTREAM.AddVideoStream(false, rate, bmpWEBSTREAM);                       
        }

        private void UploadFLV()
        {
            //BasicFTPClientNamespace.BasicFTPClient basicFTP = new BasicFTPClientNamespace.BasicFTPClient();
            //basicFTP.UploadFile(Path.GetFileName(AVIDestination), AVIDestination);                            
        }

        private void AVItoFLV()
        {

            //Convert to .flv
            //Code is working fine below but commented for future releases
            //=============================================================================
            Process ffmpeg; // creating process

            string video;
            string mpg;
            //video = Page.MapPath("c:\\WinVideo-HDI-VS08-AJAX-Support.wmv"); // setting video input name with path
            //video = @"c:\ImagesAVI\Cam" + aviSeed + ".avi"; //"c:\\superimpose.avi"; // setting video input name with path
            video = AVISource; //"c:\\superimpose.avi"; // setting video input name with path


            //mpg = Page.MapPath("") + "c:\\video.flv"; // thumb name with path !
            //mpg =  @"c:\ImagesFLV\Cam"+ aviSeed  +".flv";//"c:\\video.flv"; // thumb name with path !
            mpg = AVIDestination;//"c:\\video.flv"; // thumb name with path !
            ffmpeg = new Process();

            ffmpeg.StartInfo.Arguments = " -i " + video + " -aspect 16:9 -deinterlace -ab 32 -r 15 -ar 22050 -ac 1 -y " + mpg; // arguments !
            //ffmpeg.StartInfo.FileName = Page.MapPath("c:\\ffmpeg.rev12665\\ffmpeg.exe");
            ffmpeg.StartInfo.FileName = "ffmpeg.exe";

            ffmpeg.Start(); // start !
            ffmpeg.WaitForExit();
            ffmpeg.Close();

            UploadFLV();

            //Thread th = new Thread(new ThreadStart(UploadFLV));
            //th.Start();

        }

        public static Stream ToStream(Image image, ImageFormat format)
        {
            var stream = new System.IO.MemoryStream();
            image.Save(stream, format);
            stream.Position = 0;
            return stream;
        }
    }
}
