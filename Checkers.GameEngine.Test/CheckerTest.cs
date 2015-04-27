using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Checkers.GameEngine;

namespace Checkers.GameEngine.Test
{
    /// <summary>
    /// Summary description for CheckerTest
    /// </summary>
    [TestClass]
    public class CheckerTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            CheckerOnDesk chD = new CheckerOnDesk(ColorType.White, CheckerStatus.Simple, new Point(1, 1));
            Assert.AreEqual(ColorType.White, chD.Color);
            Assert.AreEqual(CheckerStatus.Simple, chD.Status);
        }
    }
}
