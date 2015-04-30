using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Checkers.GameEngine
{
    public class Desk
    {
        #region Private Fields

        private int[,] _cells = new int[8, 8];
        private List<CheckerOnDesk> _checkersOnDesk;

        #endregion

        #region Constructors

        public Desk()
        {
            // краще замість for (int i = 5; i < 8; i++) написати for (int i = 5; i < _cells.GetLength(0); i++)
            // і замість for (int j = 0; j < 8; j++) написати (int i = 5; i < _cells.GetLength(1); i++)
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _cells[i, j] = 0;
                }
            }
            this._checkersOnDesk = new List<CheckerOnDesk>();
        }

        #endregion

        #region Public Properties

        public int[,] GetCells
        {
            get { return this._cells; }
        }

        public List<CheckerOnDesk> GetCheckersOnDesks
        {
            get { return this._checkersOnDesk; }
        }

        #endregion

        #region Public Methods

        public void StartPosition()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i % 2 != 0 && j % 2 != 0) || ((i % 2 == 0 && j % 2 == 0)))
                    {
                        CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, new Point(i, j));
                        _checkersOnDesk.Add(chD);
                        _cells[i, j] = 1;
                    }
                }
            }
            // краще замість for (int i = 5; i < 8; i++) написати for (int i = 5; i < _cells.GetLength(0); i++)
            // і замість for (int j = 0; j < 8; j++) написати (int i = 5; i < _cells.GetLength(1); i++)
            for (int i = 5; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i % 2 != 0 && j % 2 != 0) || ((i % 2 == 0 && j % 2 == 0)))
                    {
                        CheckerOnDesk chD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, new Point(i, j));
                        _checkersOnDesk.Add(chD);
                        _cells[i, j] = 2;
                    }
                }
            }

            // for testing
            _cells[2, 2] = 0; _cells[2, 2] = -1;
            _checkersOnDesk.Remove(GetCheckerOnDesk(new Point(2, 2))); 
            _checkersOnDesk.Add(new CheckerOnDesk(ColorType.White, CheckerStatus.King, new Point(2, 2)));
        }

        public int CountOfCheckers(ColorType color)
        {
            var list = from ch in _checkersOnDesk where ch.Color == color select ch;
            return list.Count();
        }

        public CheckerOnDesk GetCheckerOnDesk(Point point)
        {
            return _checkersOnDesk.Find(ch => ch.Point == point);
        }

        public bool IsEmpty(Point point)
        {
            return (GetCheckerOnDesk(point) == null);
        }

        public bool IsEnemy(CheckerOnDesk chD, Point point)
        {
            if (!IsEmpty(point))
            {
                return GetCheckerOnDesk(point).Color != chD.Color;
            }
            return false;
        }

        public void PossibleChangeOnKing(CheckerOnDesk chD, Point point)
        {
            if (point.X == 0 && chD.Color == ColorType.Black && chD.Status == CheckerStatus.Simple) 
            {
                chD.Status = CheckerStatus.King; //White KING
            }
            if (point.X == 7 && chD.Color == ColorType.White && chD.Status == CheckerStatus.Simple)
            {
                chD.Status = CheckerStatus.King; //Black KING
            }
        }
        //Можна було використати конструкцію if, else if, else
        public List<Point> IsToSimpleBit(CheckerOnDesk chD)
        {
            List<Point> points = new List<Point>();
            int xx = chD.Point.X;
            int yy = chD.Point.Y;

            if (xx + 2 < 8 && yy + 2 < 8 && IsEnemy(chD, new Point(xx + 1, yy + 1)) && IsEmpty(new Point(xx + 2, yy + 2)))
            {
                points.Add(new Point(xx + 2, yy + 2));
            }

            if (xx - 2 >= 0 && yy + 2 < 8 && IsEnemy(chD, new Point(xx - 1, yy + 1)) && IsEmpty(new Point(xx - 2, yy + 2)))
            {
                points.Add(new Point(xx - 2, yy + 2));
            }

            if (xx - 2 >= 0 && yy - 2 >= 0 && IsEnemy(chD, new Point(xx - 1, yy - 1)) && IsEmpty(new Point(xx - 2, yy - 2)))
            {
                points.Add(new Point(xx - 2, yy - 2));
            }

            if (xx + 2 < 8 && yy - 2 >= 0 && IsEnemy(chD, new Point(xx + 1, yy - 1)) && IsEmpty(new Point(xx + 2, yy - 2)))
            {
                points.Add(new Point(xx + 2, yy - 2));
            }

            return points;
        }
        // цей метод краще поділити на кілька методів
        public List<Point> IsToKingBit(CheckerOnDesk chD)
        {
            List<Point> points = new List<Point>();
            int x = chD.Point.X;
            int y = chD.Point.Y;
            int xx, yy;

            xx = x + 1;
            yy = y + 1;
            while (xx < 7 && yy < 7)
            {
                if ( IsEnemy(chD, new Point(xx, yy)) && IsEmpty(new Point(xx + 1, yy + 1)) )
                {
                    points.Add(new Point(xx + 1, yy + 1));
                    break;
                }
                xx++;
                yy++;
            }

            xx = x + 1;
            yy = y - 1;
            while (xx < 7 && yy > 0)
            {
                if ( IsEnemy(chD, new Point(xx, yy)) && IsEmpty(new Point(xx + 1, yy - 1)) )
                {
                    points.Add(new Point(xx + 1, yy - 1));
                    break;
                }
                xx++;
                yy--;
            }

            xx = x - 1;
            yy = y - 1;
            while (xx > 0 && yy > 0)
            {
                if ( IsEnemy(chD, new Point(xx, yy)) && IsEmpty(new Point(xx - 1, yy - 1)) )
                {
                    points.Add(new Point(xx - 1, yy - 1));
                    break;
                }
                xx--;
                yy--;
            }

            xx = x - 1;
            yy = y + 1;
            while (xx > 0 && yy < 7)
            {
                if ( IsEnemy(chD, new Point(xx, yy)) && IsEmpty(new Point(xx - 1, yy + 1)) )
                {
                    points.Add(new Point(xx - 1, yy + 1));
                    break;
                }
                xx--;
                yy++;
            }

            return points;
        }

        public List<Point> IsToBit(CheckerOnDesk chD)
        {
            return (chD.Status == CheckerStatus.Simple) ? IsToSimpleBit(chD) : IsToKingBit(chD);
        }
        //Можна було переробити у linq-expression цикл foreach
        public List<CheckerOnDesk> CheckersHaveToBit(ColorType color)
        {
            List<CheckerOnDesk> list1 = new List<CheckerOnDesk>();

            var list = from ch in _checkersOnDesk where ch.Color == color select ch;

            foreach (CheckerOnDesk chD in list)
            {
                if (IsToBit(chD).Count != 0)
                {
                    list1.Add(chD);
                }
            }
            return list1;
        }
        //Можна було переробити у linq-expression цикл foreach
        public List<CheckerOnDesk> ChekersToMove(ColorType color)
        {
            List<CheckerOnDesk> list1 = new List<CheckerOnDesk>();

            var list = from ch in _checkersOnDesk where ch.Color == color select ch;

            foreach (CheckerOnDesk chD in list)
            {
                if (IsToMove(chD).Count != 0)
                {
                    list1.Add(chD);
                }
            }
            return list1;
        }

        public List<Point> IsToSimpleMove(CheckerOnDesk chD)
        {
            List<Point> points = new List<Point>();
            int x = chD.Point.X;
            int y = chD.Point.Y;
            
            int i = (chD.Color == ColorType.White) ? 1 : -1;

            if (x + i < 8 && y + 1 < 8 && (_cells[x + i, y + 1] == 0))
            {
                points.Add(new Point(x + i, y + 1));
            }
            if (x + i < 8 && y - 1 >= 0 && (_cells[x + i, y - 1] == 0))
            {
                points.Add(new Point(x + i, y - 1));
            }

            return points;
        }

        public List<Point> IsToKingMove(CheckerOnDesk chD)
        {
            List<Point> points = new List<Point>();
            points.AddRange(DiagonalForwardLeft(chD.Point));
            points.AddRange(DiagonalForwardRight(chD.Point));
            points.AddRange(DiagonalBackRight(chD.Point));
            points.AddRange(DiagonalBackLeft(chD.Point));        

            return points;
        }

        public List<Point> IsToMove(CheckerOnDesk chD)
        {
            return (chD.Status == CheckerStatus.Simple) ? IsToSimpleMove(chD) : IsToKingMove(chD);
        }

        public void RemoveChecker(Point p1, Point p2)
        {
            // remove checker after beat
            int x = p1.X + (p2.X - p1.X)/2;
            int y = p1.Y + (p2.Y - p1.Y)/2;
            Point p = new Point(x, y);
            while (GetCheckerOnDesk(p) == null)
            {
                p1 = p;
                x = p1.X + (p2.X - p1.X) / 2;
                y = p1.Y + (p2.Y - p1.Y) / 2;
                p = new Point(x, y);
            }
            _checkersOnDesk.Remove(GetCheckerOnDesk(p));
        }

        public void MoveCheking(Point p1, Point p2, out bool isBeat, ColorType color)
        {
            isBeat = false;
            CheckerOnDesk chD = GetCheckerOnDesk(p1);  
                     
            if (IsToBit(chD).Count == 0)  
            {
                if (IsToMove(chD).Contains(p2)) 
                {
                    _checkersOnDesk.Remove(chD);
                    _checkersOnDesk.Add(new CheckerOnDesk(chD.Color, chD.Status, p2));
                    PossibleChangeOnKing(chD, p2);
                    _cells[p2.X, p2.Y] = (int)chD.Color * (int)chD.Status;
                    _cells[chD.Point.X, chD.Point.Y] = 0;
                }
            }
            else
            {
                if (IsToBit(chD).Contains(p2))
                {
                    _checkersOnDesk.Remove(chD);
                    _checkersOnDesk.Add(new CheckerOnDesk(chD.Color, chD.Status, p2));
                    PossibleChangeOnKing(chD, p2);
                    RemoveChecker(p1, p2);
                    _cells[p2.X, p2.Y] = (int)chD.Color * (int)chD.Status; 
                    _cells[chD.Point.X, chD.Point.Y] = 0; 
                    _cells[p1.X, p1.Y] = 0; 

                    isBeat = true;
                }
            }
        }

        #endregion

        #region Helpers

        private List<Point> DiagonalForwardLeft(Point point)
        {
            List<Point> points = new List<Point>();
            int xx = point.X + 1;
            int yy = point.Y - 1;
            while (xx < 8 && yy >= 0)
            {
                if (_cells[xx, yy] == 0)
                {
                    points.Add(new Point(xx, yy));
                }
                else
                {
                    break;
                }
                xx++;
                yy--;
            }
            return points;
        }

        private List<Point> DiagonalForwardRight(Point point)
        {
            List<Point> points = new List<Point>();
            int xx = point.X + 1;
            int yy = point.Y + 1;
            while (xx < 8 && yy < 8)
            {
                if (_cells[xx, yy] == 0)
                {
                    points.Add(new Point(xx, yy));
                }
                else
                {
                    break;
                }
                xx++;
                yy++;
            }
            return points;
        }

        private List<Point> DiagonalBackRight(Point point)
        {
            List<Point> points = new List<Point>();
            int xx = point.X - 1;
            int yy = point.Y + 1;
            while (xx >= 0 && yy < 8)
            {
                if (_cells[xx, yy] == 0)
                {
                    points.Add(new Point(xx, yy));
                }
                else
                {
                    break;
                }
                xx--;
                yy++;
            }
            return points;
        }

        private List<Point> DiagonalBackLeft(Point point)
        {
            List<Point> points = new List<Point>();
            int xx = point.X - 1;
            int yy = point.Y - 1;
            while (xx >= 0 && yy >= 0)
            {
                if (_cells[xx, yy] == 0)
                {
                    points.Add(new Point(xx, yy));
                }
                else
                {
                    break;
                }
                xx--;
                yy--;
            }
            return points;
        }

        #endregion
    }
}

