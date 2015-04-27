using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Checkers.GameEngine;
using System.Linq;

namespace Checkers.GameEngine.Test
{
    [TestClass]
    public class ComputerIntelectTest
    {       
        [TestMethod]
        public void TestMove_Without_Beat()
        {
            Desk desk = new Desk();
            desk.StartPosition();
            ComputerIntelect computer = new ComputerIntelect(desk, ColorType.Black);
            Point p1;
            Point p2;

            computer.Move();
            computer.LastMove(out p1, out p2);

            Assert.IsNotNull(p1);
            Assert.IsNotNull(p2);
        }

        [TestMethod]
        public void TestMove_Beat()
        {
            Desk desk = new Desk();
            desk.StartPosition();
            ComputerIntelect computer = new ComputerIntelect(desk, ColorType.Black);
            Point p1;
            Point p2;

            Point p = new Point(4, 4);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.King, p);
            desk.GetCheckersOnDesks.Add(chD);

            computer.Move();
            computer.LastMove(out p1, out p2);

            Assert.IsNotNull(p1);
            Assert.IsNotNull(p2);
            Assert.IsTrue(p1.X - p2.X == 2 && p2.Y - p1.Y == 2);
        }

        [TestMethod]
        public void TestMove_Double_Beat()
        {
            Desk desk = new Desk();
            //desk.StartPosition();

            Point p = new Point(3, 3);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.Black, CheckerStatus.King, p);
            desk.GetCheckersOnDesks.Add(chD);
            
            Point p1 = new Point(4, 4);
            CheckerOnDesk chD1 = new CheckerOnDesk(ColorType.White, CheckerStatus.King, p1);
            desk.GetCheckersOnDesks.Add(chD1);

            Point p2 = new Point(2, 2);
            CheckerOnDesk chD2 = new CheckerOnDesk(ColorType.White, CheckerStatus.King, p2);
            desk.GetCheckersOnDesks.Add(chD2);

            ComputerIntelect computer = new ComputerIntelect(desk, ColorType.Black);
            computer.Move();

            Assert.AreEqual(0, desk.CountOfCheckers(ColorType.White));
        }
    }
}
