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
    public partial class frmUserDetails : Form
    {
        DataSet dstFields = new DataSet();
        public frmUserDetails(DataSet DatasetFields)
        {
            InitializeComponent();
            dstFields = DatasetFields;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            new frmTakePicture().ShowDialog();
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            dgrdUserDetails.DataSource = dstFields.Tables[0];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            for (int i = 0; i <= dgrdUserDetails.Rows.Count - 1; i++)
            {
                dstFields.Tables[0].Rows[i][0] = dgrdUserDetails.Rows[i].Cells[0].Value.ToString();
            }

            clsCommon.dstUserDetails = dstFields;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
