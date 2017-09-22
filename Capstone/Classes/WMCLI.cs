using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using static Capstone.Classes.VMCLISubMenu;

namespace Capstone.Classes
{
    public class WMCLI
    {
        private string OptionDisplayPurchaseMenu;
        private string DisplayVendingMachine;
        private string InsertMoney;
        private string MakeSelection;
        private string Quit;
        private string ReturnChange;
        private string ReturnToPreviousMenu;

        protected VendingMachine vm;


        public void Display()
        {
            PrintHeader();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1] >> Display Inventory");
                Console.WriteLine("2] >> Purchase Item");
                Console.WriteLine("Q] >> Quit");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Displaying Inventory");
                    DisplayInventory();
                }
                else if (input == "2")
                {
                    Submenu1CLI purchasemenu = new Submenu1CLI();
                    purchasemenu.Display();
                }
                else if (input == "Q")
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
            }
        }

        private void PrintHeader()
        {

            Console.WriteLine("WELCOME TO THE VEND-A-TRON1000");
        }
        public void DisplayInvaidOption()
        {

        }
        public void DisplayInventory()
        {
            string[] slots = vm.Slots;
            for(int i = 0; i < slots.Length; i++)
            {
                Console.WriteLine($" { slots[i]} ** {vm.GetQuantityRemaining(slots[i]).ToString()} ** {vm.GetItemAtSlot(slots[i]).ItemName} ");
            }
            
        }
        public void DisplayPurchaseMenu()
        {

        }
        public void DisplayReturnedChange()
        {

        }
        public void Run()
        {

        }
        public WMCLI(VendingMachine vm)
        {
            this.vm = vm;
        }

        public WMCLI()
        {
        }
    }
}

