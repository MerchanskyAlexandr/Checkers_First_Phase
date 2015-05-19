using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace Checkers.GameEngine
{
    public class ComputerIntelect : Player
    {
        #region Private Fields

        private Desk _desk;
        private bool _isBeat = false;
        private CheckerOnDesk _movingChecker;

        #endregion

        #region Constructors

        public ComputerIntelect(Desk desk, ColorType color)
            : base(desk, color)
        {
            this._desk = Desk;
        }

        #endregion

        public void Move()
        {
            Random rnd = new Random();
            if (_desk.CheckersHaveToBit(Color).Count != 0) 
            {
                do
                {
                    int r1 = rnd.Next(0, _desk.CheckersHaveToBit(Color).Count - 1);
                    CheckerOnDesk ch1 = _desk.CheckersHaveToBit(Color)[r1];

                    int r2 = rnd.Next(0, _desk.IsToBit(ch1).Count - 1);
                    Point p2 = _desk.IsToBit(ch1)[r2];

                    _desk.MoveCheking(ch1.Point, p2, out _isBeat, Color);

                    _movingChecker = _desk.GetCheckerOnDesk(p2);
                    FirstPoint = ch1.Point;
                    SecondPoint = p2;
                }
                while (_desk.IsToBit(_movingChecker).Count > 0); 
            }
            else
            {
                if (_desk.ChekersToMove(Color).Count != 0)
                {
                    int r1 = rnd.Next(0, _desk.ChekersToMove(Color).Count - 1);
                    CheckerOnDesk ch1 = _desk.ChekersToMove(Color)[r1];

                    int r2 = rnd.Next(0, _desk.IsToMove(ch1).Count - 1);
                    Point p2 = _desk.IsToMove(ch1)[r2];

                    _desk.MoveCheking(ch1.Point, p2, out _isBeat, Color);

                    FirstPoint = ch1.Point;
                    SecondPoint = p2;
                }
            }
            return;
        }
    }
}
