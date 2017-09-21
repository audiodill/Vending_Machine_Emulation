using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTests
    {
        [TestMethod]
        public void TestConversionReturnsAsCents()
        {
            Change x = new Change(1.00m);
            Change y = new Change(100);
            double dollarsResult = x.TotalChange;
            double centsResult = y.TotalChange;
            Assert.AreEqual(100, dollarsResult);
            Assert.AreEqual(100, centsResult);
        }

        [TestMethod]
        public void TestForQuarters()
        {
            Change x = new Change(115);
            int result = x.Quarters;
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestForDimes()
        {
            Change x = new Change(115);
            int result = x.Dimes;
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestForNickles()
        {
            Change x = new Change(115);
            int result = x.Nickles;
            Assert.AreEqual(1, result);
        }
    }
}
