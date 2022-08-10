using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace I_Card
{
    public partial class frmSelectTemplate : Form
    {
        public frmSelectTemplate()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSelectTemplate_Load(object sender, EventArgs e)
        {
           //Create the pervasive dataset structure
            clsCommon.dstInformation.Tables.Add("IdCard");
            clsCommon.dstInformation.Tables["IdCard"].Columns.Add("Template");




        }

        private void lvTemplates_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //Get the select item information
            string selectedTemplate = string.Empty;

            foreach (ListViewItem lvItem in lvTemplates.SelectedItems)
            {
                selectedTemplate = lvItem.ImageKey.ToString();
            }

            clsCommon.templateName = selectedTemplate;

            this.Hide();

            new frmUserDetails().ShowDialog();

            //clsCommon.dstInformation.Tables["IdCard"].Rows.Add(row);
            //clsCommon.dstInformation.Tables["IdCard"].Rows[0]["Template"] = selectedTemplate;

            //MessageBox.Show(selectedTemplate);
        }
    }
}
