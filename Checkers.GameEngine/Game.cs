using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// змінити назву namespace за допомогою properties
namespace Checkers.GameEngine
{
    public class Game
    {
        #region Private Fields

        private GameType _typeOfGame;
        private Desk _desk;
        private Player _whitePlayer;
        private Player _blackPlayer;
        private Player _currentPlayer;
        private ComputerIntelect _computer;        

        #endregion

        #region Public Properties

        public GameType TypeOfGame
        {
            get { return this._typeOfGame; }
        }

        public Desk GameDesk
        {
            get { return this._desk; }
        }

        public Player WhitePlayer
        {
            get { return this._whitePlayer; }
        }

        public Player BlackPlayer
        {
            get { return this._blackPlayer; }
        }

        public Player CurrentPlayer
        {
            get { return this._currentPlayer; }
        }

        #endregion

        #region Constructors

        public Game(GameType typeOfGame)
        {

            this._desk = new Desk();
            this._desk.StartPosition();
            this._typeOfGame = typeOfGame;

            if (typeOfGame == GameType.MultyPlayer )
            {
                this._whitePlayer = new Player(_desk, ColorType.White);
                this._blackPlayer = new Player(_desk, ColorType.Black);
            }

            if (typeOfGame == GameType.SinglePlayer)
            {
                this._whitePlayer = new Player(_desk, ColorType.White);
                this._computer = new ComputerIntelect(_desk, ColorType.Black);
                this._blackPlayer = this._computer;
            }

            this._currentPlayer = this._whitePlayer;
        }

        #endregion

        #region Public Methods

        public void RunGame(Point point) 
        {
            _currentPlayer.Move(point);
            if (_currentPlayer.EndMove)
            {
                ChangeCurrentPlayer();
            }
        }

        public void RunGameWithComputer(Point point, out string message)
        {
            _whitePlayer.Move(point);
            message = "Player is moving";
            if (_whitePlayer.EndMove)
            {
                Point p1, p2;
                message = "Computer is moving";
                _computer.Move();
                _computer.LastMove(out p1, out p2);
                message = String.Format("Computer moved form {0} to {1}", p1, p2);
                ChangeCurrentPlayer();
            }
        }

        public bool IsExit(out string message)
        {
            bool isExit = false;
            message = "";

            if (_currentPlayer.CountOfCheckers() == 0 || _currentPlayer.CountOfMoves() == 0)
            {
                ChangeCurrentPlayer();
                message = String.Format("END GAME. {0} wins.", _currentPlayer.Color);
                isExit = true;
            }

            return isExit;
        }

        #endregion

        #region Helpers

        private void ChangeCurrentPlayer()
        {
            _currentPlayer = (_currentPlayer == _whitePlayer) ? _blackPlayer : _whitePlayer;
        }

        #endregion
    }
}
