using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone
{
    class Program
    {
        
        static void Main(string[] args)
        {
            VMFileReader stockInventory = new VMFileReader("vendingmachine.csv");
            Dictionary<string, List<VMItem>> inventory = stockInventory.GetInventory();
            VendingMachine vm = new VendingMachine(inventory);
            WMCLI mainmenu = new WMCLI(vm);
            mainmenu.Display();
        }
    }
}
