using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Checkers.GameEngine
{
    public class Player
    {
        #region Private Fields

        private Desk _desk;
        private CheckerOnDesk _movingChecker; 
        private bool _moveStarted;
        private bool _switchClick;
        private bool _isCangeChecker;
        private bool _wasBeat;
        private bool _isCorrect;
        private bool _endMove;

        #endregion

        #region Public Properties

        public ColorType Color { get; private set; }
        public bool EndMove { get; private set; }
        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }
        public List<Point> LightPoints { get; set; }
        public Desk Desk
        {
            get
            {
                return this._desk;
            }
            set
            {
                this._desk = value;
            }
        }

        #endregion

        #region Constructors

        public Player(Desk desk, ColorType color)
        {
            this.Color = color;
            this._desk = desk;
            this.LightPoints = new List<Point>();
        }

        #endregion

        #region Public Methods

        public int CountOfCheckers()
        {
            return _desk.CountOfCheckers(Color);
        }

        public int CountOfMoves()
        {
            return _desk.ChekersToMove(Color).Count;
        }

        public void LastMove(out Point p1, out Point p2)
        {
            p1 = this.FirstPoint;
            p2 = this.SecondPoint;
        }

        public void Move(Point point)
        {
            this.EndMove = false;
            if (!_switchClick)
            {
                FirstClick(point, out _switchClick);
            }
            else
            {
                _isCorrect = false;
                _endMove = false;
                SecondClick(point, out _isCangeChecker, out _wasBeat); 

                if (_isCangeChecker)
                {
                    FirstClick(point, out _switchClick);
                }

                if (_wasBeat)
                {
                    if (_desk.IsToBit(_movingChecker).Count != 0)
                    {
                        FirstClick(point, out _switchClick);
                    }
                }

                if (_isCorrect && _endMove)
                {
                    _switchClick = false;
                    this.LightPoints = null;
                    this.EndMove = true;
                    this.FirstPoint = _movingChecker.Point;
                    this.SecondPoint = point;
                }
            }
        }

        #endregion

        #region Helpers

        private void FirstClick(Point firstPoint, out bool isThisFirstClick)
        {
            isThisFirstClick = false;
            List<Point> p = null;
            if (_desk.GetCheckerOnDesk(firstPoint) != null) 
            {
                CheckerOnDesk checker = _desk.GetCheckerOnDesk(firstPoint);
                if (_desk.CheckersHaveToBit(Color).Count != 0) 
                {
                    if (_desk.IsToBit(_desk.GetCheckerOnDesk(firstPoint)) != null) 
                    {
                        isThisFirstClick = true;
                        p = _desk.IsToBit(checker);
                        _movingChecker = checker;
                    }
                }
                else
                {
                    if (_desk.IsToMove(checker).Count != 0)
                    {
                        isThisFirstClick = true;
                        p = _desk.IsToMove(checker);
                        _movingChecker = checker;
                    }
                }
            }
            this.LightPoints = p;
        }

        private void SecondClick(Point p, out bool isCangeChecker, out bool wasBeat)
        {
            _isCorrect = false;
            _endMove = false;
            bool isBeat = false;
            isCangeChecker = false;
            wasBeat = false;

            if (_moveStarted && !LightPoints.Contains(p))
            {
                return;
            }

            if (!LightPoints.Contains(p))
            {
                if (!_desk.IsEmpty(p) && _desk.GetCheckerOnDesk(p).Color == this.Color)
                {
                    if (_desk.CheckersHaveToBit(this.Color).Count == 0)
                    {
                        _isCorrect = true;
                        _endMove = false;
                        isCangeChecker = true;
                    }
                    else 
                    {
                        if (_desk.IsToBit(_desk.GetCheckerOnDesk(p)) != null)  
                        {
                            _isCorrect = true;
                            _endMove = false;
                            isCangeChecker = true;
                        }
                    }
                }
            }
            else 
            {
                _desk.MoveCheking(_movingChecker.Point, p, out isBeat, Color);
                _movingChecker = _desk.GetCheckerOnDesk(p);
                _isCorrect = true;
                _endMove = true;
                wasBeat = isBeat;
                LightPoints = null;

                if (isBeat)
                {
                    _endMove = _desk.IsToBit(_movingChecker).Count == 0;
                    _moveStarted = true;
                }
            }
        }

        #endregion
    }
}
