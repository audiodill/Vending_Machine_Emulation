using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        
        static void Main(string[] args)
        {
            VMFileReader stockInventory = new VMFileReader("vendingmachine.csv");
            Dictionary<string, List<VMItem>> inventory = stockInventory.GetInventory();
            VendingMachine vend = new VendingMachine(inventory);
            int result = vend.GetQuantityRemaining("A1");
            Console.ReadLine();
        }
    }
}
