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
    public partial class frmSelection : Form
    {
        public frmSelection()
        {
            InitializeComponent();
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            //this.Hide();
            new frmApplicationReview().ShowDialog();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            //this.Close();
            new I_Card_Template_Creator.frmCreateTemplate().ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }
    }
}
