using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VMFileReader
    {
        protected int Cost;
        protected int InitialQuantity;
        protected int Product;
        protected string SlotID;
        string[] lineData = new string[3];
        Dictionary<string, List<VMItem>> inventory = new Dictionary<string, List<VMItem>>();

        public VMFileReader(string filepath)
        {
            string directory = Directory.GetCurrentDirectory();
            string filename = "vendingmachine.csv";
            filepath = Path.Combine(directory, filename);
            try
            {

                using (StreamReader sr = new StreamReader(filepath))
                {

                    while (!sr.EndOfStream)
                    {
                        string nextLine = sr.ReadLine();
                        lineData = nextLine.Split('|');
                        List<VMItem> stock = new List<VMItem>();
                        for (int i = 0; i < 5; i++)
                        {
                            stock.Add(CreateInitialInventory(lineData));
                        }
                        inventory[lineData[0]] = stock;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Error Don't Panic");
                Console.WriteLine(ex.Message);
            }
        }

        public VMItem CreateInitialInventory(string[] lineData)
        {
            if (lineData[0].Contains("A"))
            {
                ChipItem chip = new ChipItem(lineData[1], Decimal.Parse(lineData[2]));
                return chip;
            }
            else if (lineData[0].Contains("B"))
            {
                CandyItem candy = new CandyItem(lineData[1], Decimal.Parse(lineData[2]));
                return candy;
            }
            else if (lineData[0].Contains("C"))
            {
                BeverageItem beverage = new BeverageItem(lineData[1], Decimal.Parse(lineData[2]));
                return beverage;
            }
            else
            {
                GumItem gum = new GumItem(lineData[1], Decimal.Parse(lineData[2]));
                return gum;
            }
        }

        public Dictionary<string, List<VMItem>> GetInventory()
        {
            return inventory;
        }

    }
}
