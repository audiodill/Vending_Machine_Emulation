using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;


namespace CapstoneTests
{
    [TestClass]
    public class AbstraceClassTests
    {
        [TestMethod]
        public void TestWhenAGumItemIsConsumed()
        {
            GumItem x = new GumItem("Big Red", 25);
            string result = x.Consume();
            Assert.AreEqual("Chew Chew, Yum!", result);
        }

        [TestMethod]
        public void TestWhenACandyItemIsConsumed()
        {
            CandyItem x = new CandyItem("Snickers", 50);
            string result = x.Consume();
            Assert.AreEqual("Munch Munch, Yum!", result);
        }

        [TestMethod]
        public void TestWhenAChipItemIsConsumed()
        {
            ChipItem x = new ChipItem("Lays", 75);
            string result = x.Consume();
            Assert.AreEqual("Crunch Crunch, Yum!", result);
        }

        [TestMethod]
        public void TestWhenABeverageItemIsConsumed()
        {
            BeverageItem x = new BeverageItem("Coke", 125);
            string result = x.Consume();
            Assert.AreEqual("Glug Glug, Yum!", result);
        }

        [TestMethod]
        public void CheckIfGumItemNameAndPriceExist()
        {
            GumItem x = new GumItem("Big Red", 25);
            string item = x.ItemName;
            decimal price = x.Price;
            Assert.AreEqual("Big Red", item);
            Assert.AreEqual(25, price);
        }

        [TestMethod]
        public void CheckIfCandyItemNameAndPriceExist()
        {
            CandyItem x = new CandyItem("Snickers", 125);
            string item = x.ItemName;
            decimal price = x.Price;
            Assert.AreEqual("Snickers", item);
            Assert.AreEqual(125, price);
        }

        [TestMethod]
        public void CheckIfChipItemNameAndPriceExist()
        {
            ChipItem x = new ChipItem("Lays", 145);
            string item = x.ItemName;
            decimal price = x.Price;
            Assert.AreEqual("Lays", item);
            Assert.AreEqual(145, price);
        }

        [TestMethod]
        public void CheckifBeverageItemNameAndPriceExist()
        {
            BeverageItem x = new BeverageItem("Coke", 200);
            string name = x.ItemName;
            decimal price = x.Price;
            Assert.AreEqual("Coke", name);
            Assert.AreEqual(200, price);
        }
    }
}
