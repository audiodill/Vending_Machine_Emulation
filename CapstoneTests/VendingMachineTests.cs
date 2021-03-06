﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        VendingMachine vend;
        VMFileReader stockInventory;
        Dictionary<string, List<VMItem>> inventory;
        //string slotID;
        
        [TestInitialize]
        public void Initialize()
        {
            stockInventory = new VMFileReader("vendingmachine.csv");
            inventory = stockInventory.GetInventory();
            vend = new VendingMachine(inventory);
        }
        [TestMethod]
        public void TestToGetInventoryCountOfA1()
        {
            int result = vend.GetQuantityRemaining("A1");
            Assert.AreEqual(5 + 1, result);
        }

        [TestMethod]
        public void TestToGetInventoryCountOfD4()
        {
            int result = vend.GetQuantityRemaining("D4");
            Assert.AreEqual(5 + 1, result);
        }

        [TestMethod]
        public void TestToGetNameOfSlotID()
        {
            string result = vend.GetItemAtSlot("A1").ItemName;
            Assert.AreEqual("Potato Crisps", result);
        }
        [TestMethod]
        public void TestingToGetThePriceOfAnItemBack()
           
        {
            decimal result = vend.GetItemAtSlot("A1").Price;
            Assert.AreEqual(3.05M, result);    // testing for a decimal
        }

        [TestMethod]
        public void TestTheFeedMoneyMethod()
        {
            vend.FeedMoney(20);
            double result =  Convert.ToDouble(vend.CurrentBalance);
            Assert.AreEqual(20.00, result);
        }

        [TestMethod]
        public void TestForPurchaseAccuracy()
        {
            vend.FeedMoney(20);
            vend.Purchase("A1");
            VMItem item = vend.Purchase("A1");
            Assert.AreEqual(3.05M, item.Price);
            Assert.AreEqual("Potato Crisps", item.ItemName);
        }
    }
}
