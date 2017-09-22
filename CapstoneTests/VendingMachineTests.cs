using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        VendingMachine vend;
        [TestInitialize]
        public void Initialize()
        {
            VMFileReader stockInventory = new VMFileReader("vendingmachine.csv");
            Dictionary<string, List<VMItem>> inventory = stockInventory.GetInventory();
            vend = new VendingMachine(inventory);
        }
        [TestMethod]
        public void TestToGetInventoryCountOfA1()
        {
            int result = vend.GetQuantityRemaining("A1");
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestToGetInventoryCountOfD4()
        {
            int result = vend.GetQuantityRemaining("D4");
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestToGetNameOfSlotID()
        {
            
        }
    }
}
