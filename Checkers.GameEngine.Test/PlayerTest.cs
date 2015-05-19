using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Linq;
using Checkers.GameEngine;

namespace Checkers.GameEngine.Test
{  
    [TestClass]
    public class PlayerTest
    {        
        [TestMethod]
        public void TestConstructor()
        {
            Desk desk = new Desk();
            Player player1 = new Player(desk, ColorType.White);

            Assert.AreEqual(ColorType.White, player1.Color);
            Assert.AreEqual(0, player1.LightPoints.Count);
        }

        [TestMethod]
        public void TestCountOfCheckers()
        {
            Desk desk = new Desk();
            desk.StartPosition();
            Player player1 = new Player(desk, ColorType.White);

            Assert.AreEqual(12, player1.CountOfCheckers());
        }

        [TestMethod]
        public void TestCountOfMoves()
        {
            Desk desk = new Desk();
            desk.StartPosition();
            Player player1 = new Player(desk, ColorType.Black);

            Assert.AreEqual(4, player1.CountOfMoves());
        }

        [TestMethod]
        public void TestMove_Without_Beat()
        {
            Desk desk = new Desk();
            desk.StartPosition();
            Player player = new Player(desk, ColorType.White);

            Point p = new Point(2, 4);
            player.Move(p);
            List<Point> points = new List<Point> { new Point(3, 5), new Point(3, 3) };
            Assert.IsTrue(player.LightPoints.SequenceEqual(points));

            p = new Point(1, 1);
            player.Move(p);
            points = new List<Point>();
            Assert.IsTrue(player.LightPoints == null);
        }

        [TestMethod]
        public void TestMove_SecondBeat()
        {
            Desk desk = new Desk();

            Point p = new Point(1, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.King, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point p2 = new Point(3, 3);
            CheckerOnDesk chD2 = new CheckerOnDesk(ColorType.Black, CheckerStatus.King, p2);
            desk.GetCheckersOnDesks.Add(chD2);

            Point p3 = new Point(5, 5);
            CheckerOnDesk chD3 = new CheckerOnDesk(ColorType.Black, CheckerStatus.King, p3);
            desk.GetCheckersOnDesks.Add(chD3);

            Player player = new Player(desk, ColorType.White);
            player.Move(p);
            player.Move(new Point(4, 4));
            player.Move(new Point(6, 6));

            Assert.AreEqual(1, desk.GetCheckersOnDesks.Count);
        }

        [TestMethod]
        public void TestMove_SecondBeat_WrongPoint()
        {
            Desk desk = new Desk();

            Point p = new Point(1, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.King, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point p2 = new Point(3, 3);
            CheckerOnDesk chD2 = new CheckerOnDesk(ColorType.Black, CheckerStatus.King, p2);
            desk.GetCheckersOnDesks.Add(chD2);

            Point p3 = new Point(5, 5);
            CheckerOnDesk chD3 = new CheckerOnDesk(ColorType.Black, CheckerStatus.King, p3);
            desk.GetCheckersOnDesks.Add(chD3);

            Player player = new Player(desk, ColorType.White);
            player.Move(p);
            player.Move(new Point(4, 4));
            player.Move(new Point(1, 1));

            Assert.AreEqual(2, desk.GetCheckersOnDesks.Count);
        }

        [TestMethod]
        public void TestMove_Choosing_Another_Checker()
        {
            Desk desk = new Desk();

            Point p = new Point(1, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.King, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point pp = new Point(1, 3);
            chD = new CheckerOnDesk(ColorType.White, CheckerStatus.King, pp);
            desk.GetCheckersOnDesks.Add(chD);

            Point enemyPoint = new Point(2, 2);
            CheckerOnDesk chD2 = new CheckerOnDesk(ColorType.Black, CheckerStatus.King, enemyPoint);
            desk.GetCheckersOnDesks.Add(chD2);

            Player player = new Player(desk, ColorType.White);
            player.Move(p);
            player.Move(pp);
            player.MovingChecker = chD2;

            Assert.AreEqual(3, desk.GetCheckersOnDesks.Count);
            Assert.AreNotEqual(player.MovingChecker, chD);
        }

        [TestMethod]
        public void TestMovingChecker()
        {
            Game game = new Game(GameType.SinglePlayer);
            game.RunGameWithComputer(new Point(2, 2));
            Assert.IsTrue(game.CurrentPlayer.MovingChecker.Color == ColorType.White);

            game.RunGameWithComputer(new Point(2, 2));
        }
    }
}
