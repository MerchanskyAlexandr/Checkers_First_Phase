using System.Threading;
using Checkers.DesktopUI.Controls;
using Checkers.GameEngine;
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
    public partial class CheckerForm : Form
    {
        public CheckerForm()
        {
            InitializeComponent();
            ucDesk.GameInfo = gameInfoUI;
            gameInfoUI.DeskUI = ucDesk;
        }

        public void singlePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucDesk.StartGame(GameType.SinglePlayer);
        }

        public void multyPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucDesk.StartGame(GameType.MultyPlayer);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

    }
}
