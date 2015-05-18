using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers.DesktopUI.Controls
{
    public partial class ucDeskCell : UserControl
    {
        #region Constructor
        public ucDeskCell()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Fields

        public ucGameInfo GameInfo { get; set; }

        public Boolean IsHighlightedCell { get; set; }

        public Boolean IsHighlightedChecker { get; set; }


        public ucDesk DeskUI { get; set; }

        public Point DeskPoint { get; set; }

        #endregion

        #region Event Handler
        private void DeskCellUI_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = IsHighlightedCell ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void DeskCellUI_DragDrop(object sender, DragEventArgs e)
        {
            ((ucChecker) e.Data.GetData(typeof (ucChecker))).Parent = (ucDeskCell) sender;
            if (DeskUI.TheGame.TypeOfGame == GameEngine.GameType.SinglePlayer)
            {
                DeskUI.TheGame.RunGameWithComputer(this.DeskPoint);
            }
            else
            {
                DeskUI.TheGame.RunGame(this.DeskPoint);
            }

            if (IsHighlightedCell && GameInfo.SoundFlagOn)
            {
                SoundEffect.Drop.Play();
            }
            DeskUI.UnHighlightCells();
            DeskUI.HighlightCells();
            GameInfo.UpdateStatistic();
        }

        #endregion
    }
}
