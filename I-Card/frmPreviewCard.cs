using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace I_Card
{
    public partial class frmPreviewCard : Form
    {
        public frmPreviewCard()
        {
            InitializeComponent();
        }
        DataSet dst = new DataSet();
        string templatePathFolder = string.Empty;

        bool firstInstance; //we use this variable at the time of entering user details.
        //As the user details has a separate window and when it gets closed it will update the value to false 
        //in the form activated event. If it is true then it reads the values from xml else it reads the 
        //values from the update dataset in the frmUserDetails form

        DataSet dstInfo = new DataSet();

        private void btnImportCardTemplate_Click(object sender, EventArgs e)
        {
            string heading = string.Empty;

            //folderBrowserDialog1.ShowDialog();

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                templatePathFolder = folderBrowserDialog1.SelectedPath;

                try
                {
                    dst.ReadXml(templatePathFolder + "\\Template.xml");
                    heading = dst.Tables[0].Rows[0]["Heading"].ToString();

                    listBox1.Items.Add(heading);
                    listBox2.Items.Add(templatePathFolder);

                    if (!System.IO.Directory.Exists("Card_Templates"))
                    {
                        System.IO.Directory.CreateDirectory("Card_Templates");
                    }

                    if (!System.IO.Directory.Exists("Card_Templates\\" + heading))
                    {
                        System.IO.Directory.CreateDirectory("Card_Templates\\" + heading);
                    }

                    clsCommon.DirectoryCopy(templatePathFolder, "Card_Templates\\" + heading, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex != -1)
            {


                try
                {
                    listBox2.SelectedIndex = listBox1.SelectedIndex;
                }
                catch (Exception)
                {

                    //throw;
                }



                try
                {
                    string path = "Card_Templates\\" + listBox1.Text;
                    dst.Clear(); //Clears the previous values if there is 
                    dst.ReadXml(path + "\\Template.xml");

                    //using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
                    //{
                    //    g.DrawImage(bmp, new Point(0, 0));

                    //}
                    //pictureBox1.Image = bmp;
                    //pictureBox1.Refresh();

                    string imageXCoor = dst.Tables[0].Rows[0]["ImgeX"].ToString();
                    string imageYCoor = dst.Tables[0].Rows[0]["ImageY"].ToString();
                    Bitmap bmp = new Bitmap(listBox2.Text + "\\" + dst.Tables[0].Rows[0]["TemplateImageName"].ToString());

                    //Setting image
                    if (imageXCoor.Length > 0 && imageYCoor.Length > 0)
                    {
                        System.Drawing.Graphics g = Graphics.FromImage(bmp);
                        System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.MintCream);
                        g.DrawRectangle(p, new Rectangle(Convert.ToInt32(imageXCoor), Convert.ToInt32(imageYCoor), 130, 150));
                    }

                    //Set the image
                    //clsCommon.bmpCardImage = Image sved in static variable from the previous screen
                    System.Drawing.Graphics gr = Graphics.FromImage(bmp);
                    gr.DrawImage(clsCommon.bmpCardImage, new Point(Convert.ToInt32(imageXCoor), Convert.ToInt32(imageYCoor)));

                    if (1 == 1)
                    {
                        dstInfo.ReadXml(path + "\\TemplateInfo.xml");
                    }
                    else
                    {
                        dstInfo = clsCommon.dstUserDetails;
                    }


                    System.Drawing.Graphics g1 = Graphics.FromImage(bmp);
                    System.Drawing.Font myFont = new Font("Tahoma", 9);


                    for (int i = 0; i <= dstInfo.Tables["InfoDetails"].Rows.Count - 1; i++)
                    {
                        g1.DrawString(dstInfo.Tables["InfoDetails"].Rows[i]["LabelHeading"].ToString(), myFont, Brushes.White, new PointF(Convert.ToInt32(dstInfo.Tables["InfoDetails"].Rows[i]["LabelXPosition"].ToString()), Convert.ToInt32(dstInfo.Tables["InfoDetails"].Rows[i]["LabelYPosition"].ToString())));


                    }
                    pictureBox1.Image = bmp;
                    //pictureBox1.Invalidate();
                    //Set the text
                    //using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
                    //{
                    //    for (int i = 0; i <= dstInfo.Tables["InfoDetails"].Rows.Count - 1; i++)
                    //    {
                    //        using (Font myFont = new Font("Tahoma", 9))
                    //        {
                    //            try
                    //            {
                    //                if (dstInfo.Tables["InfoDetails"].Rows[i]["LabelHeading"].ToString().Length > 0)
                    //                {
                    //                    g.DrawString(dstInfo.Tables["InfoDetails"].Rows[i]["LabelHeading"].ToString(), myFont, Brushes.White, new PointF(Convert.ToInt32(dstInfo.Tables["InfoDetails"].Rows[i]["LabelXPosition"].ToString()), Convert.ToInt32(dstInfo.Tables["InfoDetails"].Rows[i]["LabelYPosition"].ToString())));
                    //                }
                    //            }
                    //            catch (Exception)
                    //            {
                    //                throw;
                    //            }
                    //        }
                    //    }
                    //    g.Flush(FlushIntention.Sync);
                    //}

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnUserDetails.Enabled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog1.ShowDialog();

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));

                string imageName = "\\ICard-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + ".jpg";

                try
                {
                    bmp.Save(folderBrowserDialog1.SelectedPath + imageName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("Card saved successfully at:\n" + folderBrowserDialog1.SelectedPath + imageName, "Card created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            string message = "You will lose all the information.\nAre you sure?";

            if (MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();

                new frmTakePicture().ShowDialog();

            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new frmAboutBox().ShowDialog();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Hide();
            clsCommon.ConfigureImage.ShowDialog();
        }

        private void frmPreviewCard_Load(object sender, EventArgs e)
        {
            string heading = string.Empty;
            string path =  string.Empty;

            try
            {
            foreach (string dir in System.IO.Directory.GetDirectories("Card_Templates"))
            {
                //MessageBox.Show(dir);
                path = dir.ToString() + "\\Template.xml";
                dst.ReadXml(path);
                heading = dst.Tables[0].Rows[0]["Heading"].ToString();

                listBox1.Items.Add(heading);
                listBox2.Items.Add(dir);
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            firstInstance = true;
        }

        private void btnUserDetails_Click(object sender, EventArgs e)
        {



            new frmUserDetails(dstInfo).ShowDialog();


            if (firstInstance == true)
            {
                firstInstance = false;
                listBox1_Click(sender, e);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //pictureBox1.Invalidate();
        }

       

       
    }
}
