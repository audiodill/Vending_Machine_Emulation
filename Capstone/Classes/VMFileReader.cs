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
        private const int Cost = 2;
        protected int InitialQuantity;
        private const int Product = 1;
        private const int SlotID = 0;
        string[] lineData = new string[3];
        Dictionary<string, List<VMItem>> inventory = new Dictionary<string, List<VMItem>>();

        public VMFileReader(string filepath)
        {
            string directory = Directory.GetCurrentDirectory();
            filepath = Path.Combine(directory, filepath);
            try
            {

                using (StreamReader sr = new StreamReader(filepath))
                {

                    while (!sr.EndOfStream)
                    {
                        string nextLine = sr.ReadLine();
                        lineData = nextLine.Split('|');
                        List<VMItem> stock = new List<VMItem>();

                        for (int i = 0; i < 6; i++)
                        {
                            stock.Add(CreateInitialInventory(lineData));
                        }

                        inventory[lineData[SlotID]] = stock;
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
                ChipItem chip = new ChipItem(lineData[Product], Decimal.Parse(lineData[Cost]));
                return chip;
            }
            else if (lineData[0].Contains("B"))
            {
                CandyItem candy = new CandyItem(lineData[Product], Decimal.Parse(lineData[Cost]));
                return candy;
            }
            else if (lineData[0].Contains("C"))
            {
                BeverageItem beverage = new BeverageItem(lineData[Product], Decimal.Parse(lineData[Cost]));
                return beverage;
            }
            else
            {
                GumItem gum = new GumItem(lineData[Product], Decimal.Parse(lineData[Cost]));
                return gum;
            }
        }

        public Dictionary<string, List<VMItem>> GetInventory()
        {
            return inventory;
        }

    }
}
