using System;
using System.Reflection;
using Checkers.GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  System.Drawing;

namespace Checkers.GameEngine.Test
{
    [TestClass]
    public class CheckerOnDeskTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Point p = new Point(1, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, p);
            Assert.AreEqual(ColorType.White, chD.Color);
            Assert.AreEqual(CheckerStatus.Simple, chD.Status);
            Assert.AreEqual(p, chD.Point);
        }

        [TestMethod]
        public void EnemyColorTest()
        {
            var chD = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, new Point(1, 1));
            var chD2 = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, new Point(1, 1));
            var enemyColor1 = chD.EnemyColor();
            var enemyColor2 = chD2.EnemyColor();

            Assert.IsTrue(enemyColor1 == ColorType.Black);
            Assert.IsTrue(enemyColor2 == ColorType.White);
        }

        [TestMethod]
        public void EqualsTest()
        {
            var chD = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, new Point(1, 1));
            var chD2 = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, new Point(1, 1));
            var chD3 = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, new Point(1, 1));
            CheckerOnDesk chD4 = null;
            object chD5 = null;
            object chD6 = new CheckerOnDesk(ColorType.Black, CheckerStatus.Simple, new Point(1, 1));

            Assert.IsTrue(!chD.Equals(chD4));
            Assert.IsTrue(!chD.Equals(chD5));
            Assert.IsTrue(chD.Equals(chD2));
            Assert.IsTrue(!chD.Equals(chD3));
            Assert.IsTrue(!chD.Equals(chD6));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void EqualsTest_WrongParam()
        {
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, new Point(1, 1));
            Assert.IsTrue(!chD.Equals(5));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Point p = new Point(1, 1);
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, p);

            Type t = Type.GetType("System.Int32");
            Assert.IsInstanceOfType(chD.GetHashCode(), t);
        }
    }
}
