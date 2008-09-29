using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectSandWindows
{
    public partial class frmMapProperties : Form
    {
        public frmMapProperties()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Closes the dialog
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}