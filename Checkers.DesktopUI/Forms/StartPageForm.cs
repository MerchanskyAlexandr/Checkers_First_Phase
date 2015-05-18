using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers.DesktopUI
{
    public partial class StartPageForm : Form
    {
        public StartPageForm()
        {
            InitializeComponent();
        }

        #region Event Handler

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            CheckerForm checkerForm = new CheckerForm();
            this.Hide();
            checkerForm.Show();
            checkerForm.singlePlayerToolStripMenuItem_Click(null, null);
            checkerForm.Closed += this.checkerForm_Closed;
        }

        private void btnMultyPlayer_Click(object sender, EventArgs e)
        {
            CheckerForm checkerForm = new CheckerForm();
            this.Hide();
            checkerForm.Show();
            checkerForm.multyPlayerToolStripMenuItem_Click(null, null);
            checkerForm.Closed += this.checkerForm_Closed;
        }

        private void checkerForm_Closed(object sender, EventArgs e)
        {
            this.Show();
        }

        #endregion
    }
}
