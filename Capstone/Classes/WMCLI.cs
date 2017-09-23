using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using static Capstone.Classes.VMCLISubMenu;
using System.IO;

namespace Capstone.Classes
{
    public class WMCLI
    {
        private string OptionDisplayPurchaseMenu;
        private string DisplayVendingMachine;
        private string InsertMoney;
        private string makeSelection;
        private string Quit;
        private string ReturnChange;
        private string ReturnToPreviousMenu;
        protected int money;
        protected decimal currentBalance = 0;

        protected VendingMachine vm;


        public void Display()
        {

            PrintHeader();

            while (true)
            {
                string mainMenu = "MainMenu.txt";
                string directory = Directory.GetCurrentDirectory();
                mainMenu = Path.Combine(directory, mainMenu);
                Console.ForegroundColor = ConsoleColor.Green;

                using (StreamReader sr = new StreamReader(mainMenu))
                {
                    string nextLine = "";
                    while (!sr.EndOfStream)
                    {
                        nextLine = sr.ReadLine();
                        Console.WriteLine(nextLine);
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("1] >> Display Inventory");
                Console.WriteLine("2] >> Purchase Item");
                Console.WriteLine("Q] >> Quit");
                Console.WriteLine();
                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine().ToUpper();

                if (input == "1")
                {
                    Console.WriteLine();
                    string inventory = "Inventory.txt";
                    directory = Directory.GetCurrentDirectory();
                    mainMenu = Path.Combine(directory, inventory);

                    using (StreamReader sr = new StreamReader(inventory))
                    {
                        string nextLine = "";
                        while (!sr.EndOfStream)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            nextLine = sr.ReadLine();
                            Console.WriteLine(nextLine);
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                    DisplayInventory();
                }
                else if (input == "2")
                {
                    DisplayPurchaseMenu();
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
            string logoPath = "Logo.txt";
            string directory = Directory.GetCurrentDirectory();
            logoPath = Path.Combine(directory, logoPath);
            Console.ForegroundColor = ConsoleColor.Green;
            using (StreamReader sr = new StreamReader(logoPath))
            {
                string nextLine = "";
                while (!sr.EndOfStream)
                {
                    nextLine = sr.ReadLine();
                    Console.WriteLine(nextLine);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            // Console.WriteLine("WELCOME TO THE VEND-A-TRON1000");
        }
        public void DisplayInvaidOption()
        {

        }
        public void DisplayInventory()
        {
            string[] slots = vm.Slots;
            for(int i = 0; i < slots.Length; i++)
            {
                Console.WriteLine($" { slots[i]} ** {vm.GetQuantityRemaining(slots[i]).ToString()} ** {vm.GetItemAtSlot(slots[i]).Price} ** {vm.GetItemAtSlot(slots[i]).ItemName} ");
            } 
            
        }
        public void DisplayPurchaseMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            string feedMoney = "FeedMoney.txt";
            string directory = Directory.GetCurrentDirectory();
            feedMoney = Path.Combine(directory, feedMoney);

            using (StreamReader sr = new StreamReader(feedMoney))
            {
                string nextLine = "";
                while (!sr.EndOfStream)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    nextLine = sr.ReadLine();
                    Console.WriteLine(nextLine);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            Console.WriteLine();
            Console.WriteLine("1.] $1 ");
            Console.WriteLine("2.] $5 ");
            Console.WriteLine("3.] $10 ");
            Console.WriteLine("4.] $20");
            Console.WriteLine();
            Console.Write("We accept $1, $5, $10, or $20. ");
            InsertMoney = Console.ReadLine().ToUpper();
            if(InsertMoney == "1")
            {
                vm.FeedMoney(1);
            }
            else if(InsertMoney == "2")
            {
                vm.FeedMoney(5);
            }
            else if(InsertMoney == "3")
            {
                vm.FeedMoney(10);
            }
            else if(InsertMoney == "4")
            {
                vm.FeedMoney(20);
            }
            Console.WriteLine();
            Console.WriteLine("Your current balance is $" + vm.CurrentBalance);
            Console.WriteLine();
            Console.Write("Please indicate ID of the item you wish to purchase: ");
            makeSelection = Console.ReadLine();
            VMItem item = vm.Purchase(makeSelection);
            Console.WriteLine("Here is your " + item.ItemName + " " + item.Price);
            Console.WriteLine($"Your change is {vm.CurrentBalance}");
            Console.WriteLine($"Your change consisits of {vm.ReturnChange().Quarters} Quarters {vm.ReturnChange().Dimes} Dimes and {vm.ReturnChange().Nickles} nickles. ");
            Console.WriteLine(item.Consume());
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

