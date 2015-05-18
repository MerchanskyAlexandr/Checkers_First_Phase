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
using Checkers.GameEngine;

namespace Checkers.DesktopUI.Controls
{
    public partial class ucDesk : UserControl
    {
        #region Constants

        private const byte THE_BOARDSIZE = 7;

        #endregion

        #region Constructor
        public ucDesk()
        {
            InitializeComponent();
            InitCells();
        }

        #endregion

        #region Public Fields
        public Game TheGame { get; set; }

        public ucChecker LastRemoteCheckerPanel { get; set; }

        public ucGameInfo GameInfo { get; set; }

        #endregion

        #region Private Fields

        private Dictionary<String, ucDeskCell> _cellMap = new Dictionary<String, ucDeskCell>();

        #endregion

        #region Init Controls

        private void InitCells()
        {
            for (int x = 0; x <= THE_BOARDSIZE; x++)
            {
                for (int y = 0; y <= THE_BOARDSIZE; y++)
                {
                    string key = GenerateKey(THE_BOARDSIZE - y, THE_BOARDSIZE - x);
                    ucDeskCell panel = new ucDeskCell();
                    panel.GameInfo = this.GameInfo;
                    panel.DeskUI = this;
                    panel.Size = new Size(this.Width / (THE_BOARDSIZE + 1), this.Height / (THE_BOARDSIZE + 1));
                    panel.Location = new Point((THE_BOARDSIZE - x) * panel.Width, y * panel.Height);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.BackColor = (THE_BOARDSIZE - x + y) % 2 == 0 ? Colors.DeskWhite : Colors.DeskBlack;
                    panel.AllowDrop = !((THE_BOARDSIZE - x + y) % 2 == 0);
                    panel.IsHighlightedCell = false;
                    panel.DeskPoint = new Point((THE_BOARDSIZE - y), (THE_BOARDSIZE - x));

                    this.Controls.Add(panel);
                    _cellMap.Add(key, panel);
                }
            }
        }

        private void InitChekers()
        {
            if (TheGame != null)
            {
                ClearChekers();
                List<CheckerOnDesk> checkers = TheGame.GameDesk.GetCheckersOnDesks;
                foreach (CheckerOnDesk checker in checkers)
                {
                    string key = GenerateKey(checker.Point.X, checker.Point.Y);
                    if (_cellMap.ContainsKey(key))
                    {
                        ucDeskCell panel = _cellMap[key];
                        ucChecker checkerPanel = new ucChecker();
                        checkerPanel.DeskUI = this;
                        checkerPanel.GameInfo = this.GameInfo;
                        checkerPanel.CurrentChecker = checker;
                        checkerPanel.Size = new Size(panel.Width - 2, panel.Height - 2);
                        checkerPanel.Location = new Point(panel.Width / 2 - checkerPanel.Width / 2,
                            panel.Height / 2 - checkerPanel.Height / 2);

                        panel.Controls.Clear();
                        panel.Controls.Add(checkerPanel);
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        public void StartGame(GameType typeOfGame)
        {
            TheGame = new Game(typeOfGame);
            ClearChekers();
            InitChekers();
            GameInfo.UpdateStatistic();
        }

        public void HighlightCells()
        {
            List<Point> lightPoints = TheGame.CurrentPlayer.LightPoints;
            CheckerOnDesk currentChecker = TheGame.CurrentPlayer.MovingChecker;
            string currentKey = "";

            if (currentChecker != null)
            {
                currentKey = GenerateKey(currentChecker.Point.X, currentChecker.Point.Y);
            }

            List<String> lightArray = new List<String>();
            if (lightPoints != null)
            {
                lightArray.AddRange(lightPoints.Select(point => GenerateKey(point.X, point.Y)));
            }

            foreach (var cell in _cellMap)
            {
                if (lightArray.Contains(cell.Key))
                {
                    cell.Value.IsHighlightedCell = true;
                    cell.Value.BackColor = Colors.HighLightCell;
                }

                if (cell.Key == currentKey)
                {
                    cell.Value.IsHighlightedChecker = true;
                    cell.Value.BackColor = Colors.HighLightChecker;
                }
            }
            InitChekers();
        }

        public void UnHighlightCells()
        {
            foreach (var cell in _cellMap)
            {
                if (cell.Value.IsHighlightedCell || cell.Value.IsHighlightedChecker)
                {
                    cell.Value.IsHighlightedCell = false;
                    cell.Value.IsHighlightedChecker = false;
                    cell.Value.BackColor = Colors.DeskBlack;
                }
            }
        }

        #endregion

        #region Helpers

        private string GenerateKey(int x, int y)
        {
            return x.ToString() + "-" + y.ToString();
        }

        private void ClearChekers()
        {
            for (int x = 0; x <= THE_BOARDSIZE; x++)
            {
                for (int y = 0; y <= THE_BOARDSIZE; y++)
                {
                    string key = GenerateKey(THE_BOARDSIZE - y, THE_BOARDSIZE - x);
                    if (_cellMap.ContainsKey(key))
                    {
                        ucDeskCell panel = _cellMap[key];
                        panel.GameInfo = this.GameInfo;
                        panel.Controls.Clear();
                    }
                }
            }
        }

        private void DeskUI_Resize(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void UpdateSize()
        {
            for (var x = 0; x <= THE_BOARDSIZE; x++)
            {
                for (var y = 0; y <= THE_BOARDSIZE; y++)
                {
                    var key = GenerateKey(THE_BOARDSIZE - y, THE_BOARDSIZE - x);
                    var panel = _cellMap[key];
                    panel.Size = new Size(this.Width / (THE_BOARDSIZE + 1), this.Height / (THE_BOARDSIZE + 1));
                    panel.Location = new Point((THE_BOARDSIZE - x) * panel.Width, y * panel.Height);
                }
            }
            InitChekers();
        }


        #endregion
    }
}
