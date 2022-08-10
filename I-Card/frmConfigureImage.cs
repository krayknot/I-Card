using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace I_Card
{
    public partial class frmConfigureImage : Form
    {
        private bool picBoxClickEncountered = false;

        public frmConfigureImage()
        {
            InitializeComponent();
            
        }

        private void frmConfigureImage_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBoxDisplay.ImageLocation = clsCommon.imagePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
        }

        private void pictureBoxDisplay_Click(object sender, EventArgs e)
        {
            try
            {
            picBoxClickEncountered = true;
            System.Drawing.Graphics g = pictureBoxDisplay.CreateGraphics();
            System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.MintCream);
            g.DrawRectangle(p, new Rectangle(Convert.ToInt32(lblX.Text), Convert.ToInt32(lblY.Text), 130, 150));

            Bitmap bmp = new Bitmap(pictureBoxDisplay.Width, pictureBoxDisplay.Height);
            pictureBoxDisplay.DrawToBitmap(bmp, new Rectangle(0, 0, pictureBoxDisplay.Width, pictureBoxDisplay.Height));

            try
            {
                Bitmap bmpCrop = bmp.Clone(new Rectangle(Convert.ToInt32(lblX.Text), Convert.ToInt32(lblY.Text), 130, 150), bmp.PixelFormat);

                picPreview.Image = bmpCrop;
                picPreview.Refresh();

                clsCommon.bmpCardImage = bmpCrop;
            }
            catch (Exception)
            {

                //throw;
            }

            p.Dispose();
            g.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            //Cursor.Current = Cursors.Cross;

            if (picBoxClickEncountered == false)
            {
                pictureBoxDisplay.Refresh();
                System.Drawing.Graphics g = pictureBoxDisplay.CreateGraphics();
                System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.MintCream);
                g.DrawRectangle(p, new Rectangle(e.X, e.Y, 130, 150));

                //Bitmap bmp = new Bitmap(picPreview.Width, picPreview.Height, g);
                //pictureBoxDisplay.DrawToBitmap(bmp, new Rectangle(new Point(e.X, e.Y), picPreview.Size));

                Bitmap bmp = new Bitmap(pictureBoxDisplay.Width, pictureBoxDisplay.Height);
                pictureBoxDisplay.DrawToBitmap(bmp, new Rectangle(0, 0, pictureBoxDisplay.Width, pictureBoxDisplay.Height));

                try
                {
                    Bitmap bmpCrop = bmp.Clone(new Rectangle(e.X, e.Y, 130, 150), bmp.PixelFormat);

                    picPreview.Image = bmpCrop;
                    //picPreview.Refresh();
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                

                p.Dispose();
                g.Dispose();

                lblX.Text = e.X.ToString();
                lblY.Text = e.Y.ToString();
            }

            //Cursor.Current = Cursors.Arrow;
        }

        private void pictureBoxDisplay_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetBrightness(int brightness, Bitmap CurrentBitmap)
        {
            Bitmap temp = CurrentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    bmap.SetPixel(i, j, Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
            CurrentBitmap = (Bitmap)bmap.Clone();
            pictureBoxDisplay.Image = CurrentBitmap;
        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBoxDisplay.Width, pictureBoxDisplay.Height);
            pictureBoxDisplay.DrawToBitmap(bmp, new Rectangle(0, 0, pictureBoxDisplay.Width, pictureBoxDisplay.Height));

            SetBrightness( Convert.ToInt32(numericUpDown1.Value), bmp);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmPreviewCard().ShowDialog();

            //clsCommon.PreviewCard.ShowDialog();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmTakePicture().ShowDialog();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
