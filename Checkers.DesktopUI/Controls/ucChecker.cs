using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers.GameEngine;

namespace Checkers.DesktopUI.Controls
{
    public partial class ucChecker : UserControl
    {
        #region Constructor
        public ucChecker()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Fields

        private CheckerOnDesk _currentChecker;

        #endregion

        #region Public Fields

        public CheckerOnDesk CurrentChecker
        {
            get
            {
                return _currentChecker;
            }
            set
            {
                _currentChecker = value;
                DrawChecker();
            }
        }
        public ucDesk DeskUI { get; set; }
        public ucGameInfo GameInfo { get; set; }

        #endregion

        private void DrawChecker()
        {
            if (_currentChecker != null)
            {
                if (_currentChecker.Status == CheckerStatus.Simple)
                {
                    this.BackgroundImage = (_currentChecker.Color == ColorType.White) ? 
                        Properties.Resources.yellow_checkers :
                        Properties.Resources.black_checkers;
                }
                else
                {
                    this.BackgroundImage = (_currentChecker.Color == ColorType.White) ?
                        Properties.Resources.yellow_checkers_d :
                        Properties.Resources.black_checkers_d;
                }
            }
        }

        private void CheckerUI_MouseDown(object sender, MouseEventArgs e)
        {
            DeskUI.UnHighlightCells();

            if (_currentChecker.Color != DeskUI.TheGame.CurrentPlayer.Color)
            {
                return;
            }

            // Load possible Cells
            if (DeskUI.TheGame.TypeOfGame == GameType.SinglePlayer)
            {
                DeskUI.TheGame.RunGameWithComputer(_currentChecker.Point);
                if (DeskUI.TheGame.CurrentPlayer.Color == ColorType.Black)
                {
                    DeskUI.TheGame.ChangeCurrentPlayer();
                }
            }
            else
            {
                DeskUI.TheGame.RunGame(_currentChecker.Point);
            }

            if (GameInfo.SoundFlagOn)
            {
                SoundEffect.Click.Play();
            }
            DeskUI.HighlightCells();
            // Can move
            this.DoDragDrop(this, DragDropEffects.Move);
        }
    }
}
