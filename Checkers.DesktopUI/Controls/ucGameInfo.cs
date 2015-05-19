using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Checkers.GameEngine;


namespace Checkers.DesktopUI.Controls
{
    public partial class ucGameInfo : UserControl
    {
        public ucDesk DeskUI { get; set; }

        public bool SoundFlagOn { get; private set; }
        
        public ucGameInfo()
        {
            InitializeComponent();
        }

        public void UpdateStatistic()
        {
            lbWhiteCount.Text = DeskUI.TheGame.GameDesk.CountOfCheckers(ColorType.White).ToString();
            lbBlackCount.Text = DeskUI.TheGame.GameDesk.CountOfCheckers(ColorType.Black).ToString();
            lblGameType.Text = DeskUI.TheGame.TypeOfGame.ToString();
            pboxCurrentPlayer.BackgroundImage = (DeskUI.TheGame.CurrentPlayer.Color == ColorType.White) ?
                        Properties.Resources.yellow_checkers :
                        Properties.Resources.black_checkers;

            if (DeskUI.TheGame.IsExit())
            {
                string message = String.Format("END GAME. {0} wins.", DeskUI.TheGame.WinnerColor);
                SoundEffect.Win.Play();
                MessageBox.Show(message);
                this.ParentForm.Close();
            }
        }

        private void chboxSound_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxSound.Checked)
            {
                chboxSound.Text = "Sound On";
                SoundFlagOn = true;
            }
            else
            {
                chboxSound.Text = "Sound Off";
                SoundFlagOn = false;
            }
        }
    }
}
