using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers.GameEngine;
using System.Drawing;
using System.Linq;

namespace Checkers.GameEngine.Test
{
    /// <summary>
    /// Summary description for GameTest
    /// </summary>
    [TestClass]
    public class GameTest
    {        
        [TestMethod]
        public void TestConstructor()
        {
            Game game = new Game(GameType.MultyPlayer);
            Assert.AreEqual(24, game.GameDesk.GetCheckersOnDesks.Count);
            Assert.AreEqual(GameType.MultyPlayer, game.TypeOfGame);
            Assert.AreEqual(ColorType.White, game.WhitePlayer.Color);
            Assert.AreEqual(ColorType.Black, game.BlackPlayer.Color);

            game = new Game(GameType.SinglePlayer);
            Assert.AreEqual(24, game.GameDesk.GetCheckersOnDesks.Count);
            Assert.AreEqual(GameType.SinglePlayer, game.TypeOfGame);
            Assert.AreEqual(ColorType.White, game.WhitePlayer.Color);
            Assert.AreEqual(ColorType.Black, game.BlackPlayer.Color);
        }

        [TestMethod]
        public void TestRunGame()
        {
            Game game = new Game(GameType.MultyPlayer);
            Point p = new Point(2, 0);
            game.RunGame(p);
            List<Point> points = new List<Point> { new Point(3, 1) };
            Assert.IsTrue(game.WhitePlayer.LightPoints.SequenceEqual(points));

            p = new Point(3, 1);
            game.RunGame(p);
            Assert.IsTrue(game.WhitePlayer.EndMove == true);

            p = new Point(5, 3);
            game.RunGame(p);
            points = new List<Point> { new Point(4, 4), new Point(4, 2) };
            Assert.IsTrue(game.BlackPlayer.LightPoints.SequenceEqual(points));

            p = new Point(4, 7);
            game.RunGame(p);
            Assert.IsTrue(game.BlackPlayer.EndMove == false);

            p = new Point(4, 4);
            game.RunGame(p);
            Assert.IsTrue(game.BlackPlayer.EndMove == true);
        }

        [TestMethod]
        public void TestRunGameWithComputer()
        {
            Game game = new Game(GameType.SinglePlayer);
            Point p = new Point(2, 0);
            string s;
            game.RunGameWithComputer(p);
            List<Point> points = new List<Point> { new Point(3, 1) };
            Assert.IsTrue(game.WhitePlayer.LightPoints.SequenceEqual(points));

            p = new Point(3, 1);
            game.RunGameWithComputer(p);
            Assert.IsTrue(game.WhitePlayer.EndMove == true);
        }

        [TestMethod]
        public void TestIsExit()
        {
            Game game = new Game(GameType.SinglePlayer);

            game.GameDesk.GetCheckersOnDesks.Clear();
            string s;

            Assert.IsTrue(game.IsExit() == true);
        }
    }
}
