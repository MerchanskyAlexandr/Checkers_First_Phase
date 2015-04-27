using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using Checkers.GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  System.Linq;

namespace Checkers.GameEngine.Test
{
    [TestClass]
    public class DeskTest
    {
        [TestMethod]
        public void TestConstructor_Desk()
        {
            Desk desk = new Desk();
            Assert.AreEqual(8, desk.GetCells.GetLength(1));
            Assert.AreEqual(0, desk.GetCells[2, 2]);
            Assert.IsNotNull(desk.GetCheckersOnDesks);
            Assert.AreEqual(0, desk.GetCheckersOnDesks.Count());
        }

        [TestMethod]
        public void StartPosiotionTest()
        {
            Desk desk = new Desk();
            int [,]  matr = new int[8, 8];
            matr[0, 0] = 1;
            matr[0, 2] = 1;
            matr[2, 4] = 1;
            matr[1, 3] = 1;
            matr[7, 1] = 2;
            matr[6, 4] = 2;
            matr[5, 7] = 2;
            matr[6, 5] = 0;

            desk.StartPosition();

            Point p = new Point(2, 0);
            Assert.AreEqual(24, desk.GetCheckersOnDesks.Count);
            Assert.AreEqual(ColorType.White, desk.GetCheckerOnDesk(p).Color);
            Assert.AreEqual(CheckerStatus.Simple, desk.GetCheckerOnDesk(p).Status);
            Assert.AreEqual(p, desk.GetCheckerOnDesk(p).Point);

            Assert.IsTrue(matr[0,0] == desk.GetCells[0,0]);
            Assert.IsTrue(matr[0, 2] == desk.GetCells[0, 2]);
            Assert.IsTrue(matr[2, 4] == desk.GetCells[2, 4]);
            Assert.IsTrue(matr[1, 3] == desk.GetCells[1, 3]);
            Assert.IsTrue(matr[7, 1] == desk.GetCells[7, 1]);
            Assert.IsTrue(matr[6, 4] == desk.GetCells[6, 4]);
            Assert.IsTrue(matr[5, 7] == desk.GetCells[5, 7]);
            Assert.IsTrue(matr[6, 5] == desk.GetCells[6, 5]);
        }

        [TestMethod]
        public void CountOfChekersTest()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Assert.IsTrue(desk.CountOfCheckers(ColorType.White) == 12);
            Assert.IsTrue(desk.CountOfCheckers(ColorType.Black) == 12);
        }

        [TestMethod]
        public void GetCheckerOnDeskTest()
        {
            Desk desk = new Desk();
            desk.StartPosition();
            Point p = new Point(2, 6);
            Point p2 = new Point(2, 7);
            Assert.IsNotNull(desk.GetCheckerOnDesk(p));
            Assert.AreEqual(ColorType.White, desk.GetCheckerOnDesk(p).Color);
            Assert.AreEqual(CheckerStatus.Simple, desk.GetCheckerOnDesk(p).Status);
            Assert.AreEqual(p, desk.GetCheckerOnDesk(p).Point);
            Assert.AreEqual(null, desk.GetCheckerOnDesk(p2));
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Desk desk = new Desk();
            desk.StartPosition();
            Point p = new Point(2, 6);
            Point p2 = new Point(2, 7);
            Assert.AreEqual(true, desk.IsEmpty(p2));
            Assert.AreEqual(false, desk.IsEmpty(p));
        }

        [TestMethod]
        public void IsEnemyTest()
        {
            Desk desk = new Desk();
            desk.StartPosition();
            Point p = new Point(2, 6);
            Point p2 = new Point(2, 7);
            Point p3 = new Point(5, 3);
            CheckerOnDesk chD = desk.GetCheckerOnDesk(p);
            Assert.AreEqual(false, desk.IsEnemy(chD, p2));
            Assert.AreEqual(true, desk.IsEnemy(chD, p3));
        }

        [TestMethod]
        public void PossibleChangeOnKingTest()
        {
            Desk desk = new Desk();
            desk.StartPosition();
            Point p1 = new Point(7, 5);
            Point p2 = new Point(0, 4);
            Point p3 = new Point(1, 1);
            CheckerOnDesk chD1 = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, p1);
            CheckerOnDesk chD2 = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, p2);
            CheckerOnDesk chD3 = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, p3);

            desk.PossibleChangeOnKing(chD1, p1);
            desk.PossibleChangeOnKing(chD2, p2);
            desk.PossibleChangeOnKing(chD3, p3);

            Assert.AreEqual(CheckerStatus.King, chD1.Status);
            Assert.AreEqual(CheckerStatus.King, chD2.Status);
            Assert.AreEqual(CheckerStatus.Simple, chD3.Status);
        }

        [TestMethod]
        public void IsToSimpleBitTest_1()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point p = new Point(3, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point pp = new Point(3, 3);
            CheckerOnDesk chDD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, pp);
            desk.GetCheckersOnDesks.Add(chDD);


            Point p1 = new Point(2, 2);
            CheckerOnDesk chD1 = desk.GetCheckerOnDesk(p1);
            List<Point> points1 = new List<Point> { new Point(4, 4), new Point(4, 0) };

            Point p2 = new Point(2, 0);
            CheckerOnDesk chD2 = desk.GetCheckerOnDesk(p2);
            List<Point> points2 = new List<Point> { new Point(4, 2) };

            Point p3 = new Point(1, 1);
            CheckerOnDesk chD3 = desk.GetCheckerOnDesk(p3);
            List<Point> points3 = new List<Point>();

            Assert.IsTrue(desk.IsToSimpleBit(chD1).SequenceEqual(points1));
            Assert.IsTrue(desk.IsToSimpleBit(chD2).SequenceEqual(points2));
            Assert.IsTrue(desk.IsToSimpleBit(chD3).SequenceEqual(points3));
        }

        [TestMethod]
        public void IsToSimpleBitTest_2()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point p = new Point(4, 4);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point p1 = new Point(5, 5);
            CheckerOnDesk chD1 = desk.GetCheckerOnDesk(p1);
            List<Point> points1 = new List<Point> { new Point(3, 3) };

            Point p2 = new Point(5, 3);
            CheckerOnDesk chD2 = desk.GetCheckerOnDesk(p2);
            List<Point> points2 = new List<Point> { new Point(3, 5) };

            Assert.IsTrue(desk.IsToSimpleBit(chD1).SequenceEqual(points1));
            Assert.IsTrue(desk.IsToSimpleBit(chD2).SequenceEqual(points2));
        }

        [TestMethod]
        public void IsToKingBitTest_1()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point p = new Point(3, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.Black, CheckerStatus.King, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point pp = new Point(3, 3);
            CheckerOnDesk chDD = new CheckerOnDesk(ColorType.Black, CheckerStatus.King, pp);
            desk.GetCheckersOnDesks.Add(chDD);


            Point p1 = new Point(2, 2);
            CheckerOnDesk chD1 = desk.GetCheckerOnDesk(p1);
            List<Point> points1 = new List<Point> { new Point(4, 4), new Point(4, 0) };

            Point p2 = new Point(2, 0);
            CheckerOnDesk chD2 = desk.GetCheckerOnDesk(p2);
            List<Point> points2 = new List<Point> { new Point(4, 2) };

            Assert.IsTrue(desk.IsToKingBit(chD1).SequenceEqual(points1));
            Assert.IsTrue(desk.IsToKingBit(chD2).SequenceEqual(points2));
        }

        [TestMethod]
        public void IsToKingBitTest_2()
        {
            Desk desk = new Desk();

            Point p = new Point(1, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.King, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point pp = new Point(6, 6);
            CheckerOnDesk chDD = new CheckerOnDesk(ColorType.Black, CheckerStatus.King, pp);
            desk.GetCheckersOnDesks.Add(chDD);

            List<Point> points1 = new List<Point> { new Point(7, 7) };
            List<Point> points2 = new List<Point> { new Point(0, 0) };

            Assert.IsTrue(desk.IsToKingBit(chD).SequenceEqual(points1));
            Assert.IsTrue(desk.IsToKingBit(chDD).SequenceEqual(points2));
        }

        [TestMethod]
        public void IsToKingBitTest_3()
        {
            Desk desk = new Desk();

            Point p = new Point(1, 5);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.King, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point pp = new Point(5, 1);
            CheckerOnDesk chDD = new CheckerOnDesk(ColorType.Black, CheckerStatus.King, pp);
            desk.GetCheckersOnDesks.Add(chDD);

            List<Point> points1 = new List<Point> { new Point(6, 0) };
            List<Point> points2 = new List<Point> { new Point(0, 6) };

            Assert.IsTrue(desk.IsToKingBit(chD).SequenceEqual(points1));
            Assert.IsTrue(desk.IsToKingBit(chDD).SequenceEqual(points2));
        }

        [TestMethod]
        public void IsToBitTest()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point p = new Point(3, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point pp = new Point(3, 3);
            CheckerOnDesk chDD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, pp);
            desk.GetCheckersOnDesks.Add(chDD);


            Point p1 = new Point(2, 2);
            CheckerOnDesk chD1 = desk.GetCheckerOnDesk(p1);
            List<Point> points1 = new List<Point> { new Point(4, 4), new Point(4, 0) };

            Point p2 = new Point(2, 0);
            CheckerOnDesk chD2 = desk.GetCheckerOnDesk(p2);
            List<Point> points2 = new List<Point> { new Point(4, 2) };

            Point p3 = new Point(1, 1);
            CheckerOnDesk chD3 = desk.GetCheckerOnDesk(p3);
            List<Point> points3 = new List<Point>();

            Assert.IsTrue(desk.IsToBit(chD1).SequenceEqual(points1));
            Assert.IsTrue(desk.IsToBit(chD2).SequenceEqual(points2));
            Assert.IsTrue(desk.IsToBit(chD3).SequenceEqual(points3));
        }

        [TestMethod]
        public void CheckersHaveToBitTest()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point p = new Point(3, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point pp = new Point(3, 3);
            CheckerOnDesk chDD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, pp);
            desk.GetCheckersOnDesks.Add(chDD);

            Point p1 = new Point(2, 0);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(2, 4);
            List<CheckerOnDesk> list1 = new List<CheckerOnDesk>();
            list1.Add(desk.GetCheckerOnDesk(p1));
            list1.Add(desk.GetCheckerOnDesk(p3));
            list1.Add(desk.GetCheckerOnDesk(p2));

            Assert.IsTrue(desk.CheckersHaveToBit(ColorType.White).SequenceEqual(list1));
            Assert.IsTrue(desk.CheckersHaveToBit(ColorType.Black).SequenceEqual(new List<CheckerOnDesk>()));
        }

        [TestMethod]
        public void ChekersToMoveTest()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point p = new Point(3, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point pp = new Point(3, 3);
            CheckerOnDesk chDD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, pp);
            desk.GetCheckersOnDesks.Add(chDD);

            Point p1 = new Point(2, 0);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(2, 4);
            Point p4 = new Point(2, 6);
            List<CheckerOnDesk> list1 = new List<CheckerOnDesk>();
            list1.Add(desk.GetCheckerOnDesk(p1));
            list1.Add(desk.GetCheckerOnDesk(p3));
            list1.Add(desk.GetCheckerOnDesk(p4));
            list1.Add(desk.GetCheckerOnDesk(p2));

            Assert.IsTrue(desk.ChekersToMove(ColorType.White).SequenceEqual(list1));
        }

        [TestMethod]
        public void IsToSimpleMoveTest()
        { 
            Desk desk = new Desk();
            desk.StartPosition();

            Point point1 = new Point(2, 0);
            CheckerOnDesk chD1 = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, point1);
            List<Point> points1 = new List<Point>{ new Point(3, 1) };

            Point point2 = new Point(2, 4);
            CheckerOnDesk chD2 = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, point2);
            List<Point> points2 = new List<Point> { new Point(3, 5), new Point(3, 3) };

            Point point3 = new Point(1, 1);
            CheckerOnDesk chD3 = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, point3);
            List<Point> points3 = new List<Point>();

            Point point4 = new Point(5, 5);
            CheckerOnDesk chD4 = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, point4);
            List<Point> points4 = new List<Point> { new Point(4, 6), new Point(4, 4) };

            Assert.IsTrue(desk.IsToSimpleMove(chD1).SequenceEqual(points1));
            Assert.IsTrue(desk.IsToSimpleMove(chD2).SequenceEqual(points2));
            Assert.IsTrue(desk.IsToSimpleMove(chD3).SequenceEqual(points3));
            Assert.IsTrue(desk.IsToSimpleMove(chD4).SequenceEqual(points4));
        }

        [TestMethod]
        public void IsToKingMoveTest_1()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point point1 = new Point(2, 2);
            List<Point> points1 = new List<Point>
            {
                new Point(3, 1),
                new Point(4, 0),
                new Point(3, 3),
                new Point(4, 4)
            };

            CheckerOnDesk chD = desk.GetCheckerOnDesk(point1);

            Assert.IsTrue(desk.IsToKingMove(chD).SequenceEqual(points1));
        }

        [TestMethod]
        public void IsToKingMoveTest_2()
        {
            Desk desk = new Desk();

            Point p = new Point(1, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.King, p);
            desk.GetCheckersOnDesks.Add(chD);

            Point point1 = new Point(2, 2);
            List<Point> points1 = new List<Point>
            {
                new Point(2, 0),
                new Point(2, 2),
                new Point(3, 3),
                new Point(4, 4),
                new Point(5, 5),
                new Point(6, 6),
                new Point(7, 7),
                new Point(0, 2),
                new Point(0, 0)
            };

            Assert.IsTrue(desk.IsToKingMove(chD).SequenceEqual(points1));
        }

        [TestMethod]
        public void IsToMoveTest()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point p1 = new Point(2, 2);
            CheckerOnDesk chD1 = desk.GetCheckerOnDesk(p1);
            List<Point> points1 = new List<Point>
            {
                new Point(3, 1),
                new Point(4, 0),
                new Point(3, 3),
                new Point(4, 4)
            };

            Point p2 = new Point(2, 0);
            CheckerOnDesk chD2 = desk.GetCheckerOnDesk(p2);
            List<Point> points2 = new List<Point> { new Point(3, 1) };

            Point p3 = new Point(1, 1);
            CheckerOnDesk chD3 = desk.GetCheckerOnDesk(p3);
            List<Point> points3 = new List<Point>();

            Assert.IsTrue(desk.IsToMove(chD1).SequenceEqual(points1));
            Assert.IsTrue(desk.IsToMove(chD2).SequenceEqual(points2));
            Assert.IsTrue(desk.IsToMove(chD3).SequenceEqual(points3));
        }

        [TestMethod]
        public void RemoveCheckerTest_1()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point pp = new Point(3, 3);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, pp);
            desk.GetCheckersOnDesks.Add(chD);

            Point p1 = new Point(2, 2);
            Point p2 = new Point(4, 4);

            desk.RemoveChecker(p1, p2);
            Assert.IsTrue(desk.IsEmpty(pp));
            Assert.IsNull(desk.GetCheckerOnDesk(pp));
        }

        [TestMethod]
        public void RemoveCheckerTest_2()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point pp = new Point(4, 4);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, pp);
            desk.GetCheckersOnDesks.Add(chD);

            Point p1 = new Point(2, 2);
            Point p2 = new Point(5, 5);

            desk.RemoveChecker(p1, p2);
            Assert.IsTrue(desk.IsEmpty(pp));
            Assert.IsNull(desk.GetCheckerOnDesk(pp));
        }

        [TestMethod]
        public void MoveChekingTest_1()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point pp = new Point(3, 3);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, pp);
            desk.GetCheckersOnDesks.Add(chD);

            Point p1 = new Point(2, 2);
            Point p2 = new Point(4, 4);
            bool isBeat = false;

            desk.MoveCheking(p1, p2, out isBeat, ColorType.White);

            Assert.IsTrue(isBeat == true);
            Assert.IsTrue(desk.IsEmpty(pp));
            Assert.IsNull(desk.GetCheckerOnDesk(pp));
            Assert.IsTrue(desk.IsEmpty(p1));
        }

        [TestMethod]
        public void MoveChekingTest_2()
        {
            Desk desk = new Desk();
            desk.StartPosition();

            Point pp = new Point(3, 3);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, pp);
            desk.GetCheckersOnDesks.Add(chD);

            Point p1 = new Point(2, 6);
            Point p2 = new Point(3, 7);
            bool isBeat = false;

            desk.MoveCheking(p1, p2, out isBeat, ColorType.White);

            Assert.IsTrue(isBeat == false);
            Assert.IsTrue(desk.IsEmpty(p1));
            Assert.IsNull(desk.GetCheckerOnDesk(p1));
        }

    }
}
