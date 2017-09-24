using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTests
    {
        [TestMethod]
        public void TestForQuarters()
        {
            Change x = new Change(1.15M);
            decimal result = x.Quarters;
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestForDimes()
        {
            Change x = new Change(1.15M);
            decimal result = x.Dimes;
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestForNickles()
        {
            Change x = new Change(1.15M);
            decimal result = x.Nickles;
            Assert.AreEqual(1, result);
        }
    }
}
