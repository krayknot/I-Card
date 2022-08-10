using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace I_Card_Template_Creator
{
    public partial class frmCreateTemplate : Form
    {
        public frmCreateTemplate()
        {
            InitializeComponent();
        }

        private string cardImageName = string.Empty;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                cardImageName = openFileDialog1.FileName;
                pictureBox1.ImageLocation = cardImageName;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            try
            {
                using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
                {
                    for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                    {
                        using (Font myFont = new Font("Tahoma", 9))
                        {
                            try
                            {
                                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Length > 0)
                                {
                                    g.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), myFont, Brushes.White, new PointF(Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()), Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString())));
                                }
                            }
                            catch (Exception)
                            {

                                //throw;
                            }
                        }
                    }
                }

                //Setting image
                if (txtXImage.Text.Length > 0 && txtYImage.Text.Length > 0)
                {
                    System.Drawing.Graphics g = pictureBox1.CreateGraphics();
                    System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.MintCream);
                    g.DrawRectangle(p, new Rectangle(Convert.ToInt32(txtXImage.Text), Convert.ToInt32(txtYImage.Text), 130, 150));
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = cardImageName; //Loads the image again
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string heading = txtHeading.Text;
                string imageXcoor = txtXImage.Text;
                string imageYcoor = txtYImage.Text;
                string templateImage = Path.GetFileName(cardImageName);

                //Create a Dataset and export an xml in a separate folder
                DataSet dst = new DataSet();
                dst.Tables.Add("CardTemplate");
                dst.Tables["CardTemplate"].Columns.Add("Heading");
                dst.Tables["CardTemplate"].Columns.Add("ImgeX");
                dst.Tables["CardTemplate"].Columns.Add("ImageY");
                dst.Tables["CardTemplate"].Columns.Add("TemplateImageName");

                dst.Tables["CardTemplate"].Rows.Add(heading, imageXcoor, imageYcoor, templateImage);

                DataSet dstInfoDetails = new DataSet();
                dstInfoDetails.Tables.Add("InfoDetails");
                dstInfoDetails.Tables["InfoDetails"].Columns.Add("LabelHeading");
                dstInfoDetails.Tables["InfoDetails"].Columns.Add("LabelXPosition");
                dstInfoDetails.Tables["InfoDetails"].Columns.Add("LabelYPosition");

                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        dstInfoDetails.Tables["InfoDetails"].Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                }

                string destDirectory = "c:\\" + heading;
                System.IO.Directory.CreateDirectory(destDirectory);

                dst.WriteXml(destDirectory + "\\Template.xls");
                dstInfoDetails.WriteXml(destDirectory + "\\TemplateInfo.xls");

                //Save the image from the picturebox in the xml folder
                pictureBox1.Image.Save(destDirectory + "\\" + templateImage);

                MessageBox.Show("Template saved successfully at:\n" + destDirectory, "Template created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCreateTemplate_Load(object sender, EventArgs e)
        {

        }
    }
}
