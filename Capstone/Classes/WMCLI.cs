using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class VMCLI
    {
        private string InsertMoney;
        private string makeSelection;
        protected int money;
        protected decimal currentBalance = 0;

        protected VendingMachine vm;
        
        public void Display()
        {

            PrintHeader();
            //Main menu
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
                Console.WriteLine("2] >> Purchase Menu");

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
                    DisplayAddMoney();
                    DisplayPurchaseMenu();
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Would you like to make anonther purchase? ");
                        Console.WriteLine();
                        Console.WriteLine("1.] Purchase Menu ");
                        Console.WriteLine("2.] Return to Main Menu ");
                        Console.WriteLine("3.] Add More Money ");
                        Console.WriteLine("4.] Quit and Return remaining change ");
                        string optionAfterConsume = Console.ReadLine();
                        if (optionAfterConsume == "1")
                        {
                            DisplayPurchaseMenu();
                        }
                        else if (optionAfterConsume == "2")
                        {
                            break;
                        }
                        else if (optionAfterConsume == "3")
                        {
                            DisplayAddMoney();
                            DisplayPurchaseMenu();
                        }
                        else if (optionAfterConsume == "4")
                        {
                            Console.WriteLine($"Your change is {vm.CurrentBalance}");
                            Console.WriteLine($"Your change consisits of {vm.ReturnChange().Quarters} Quarters {vm.ReturnChange().Dimes} Dimes and {vm.ReturnChange().Nickles} Nickles. ");
                            Console.WriteLine("Your remaining vending machine balance is $0.00.");
                            GiveChangeAudit();
                            Environment.Exit(0);
                        }
                    }

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

        //Purchase menu
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
        }
        public void DisplayInventory()
        {
            string[] slots = vm.Slots;
            for (int i = 0; i < slots.Length; i++)
            {
                Console.WriteLine($" { slots[i]} ** {(vm.GetQuantityRemaining(slots[i]) - 1).ToString()} ** {vm.GetItemAtSlot(slots[i]).Price} ** {vm.GetItemAtSlot(slots[i]).ItemName} ");
            }

        }
        public void DisplayPurchaseMenu()
        {
            Console.WriteLine();
            string feedMoney = "PurchaseMenu.txt";
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
            //DisplayAddMoney();

            Console.WriteLine();
            Console.Write("Please indicate the letter and number of the item you wish to purchase: ");
            makeSelection = Console.ReadLine().ToUpper();
            VMItem item = vm.Purchase(makeSelection);
            if (item == null)
            {
                Display();
            }
            PurchaseItemAudit(item.ItemName, item.Price);
            //purchaseItemAudit
            Console.WriteLine("Here is your " + item.ItemName + " " + item.Price);
            Console.WriteLine($"Your current balance is {vm.CurrentBalance}");

            Console.WriteLine(item.Consume());
        }
        
        public void DisplayAddMoney()
        {
            Console.WriteLine();
            Console.WriteLine();
            string feedMoney = "FeedMeMoney.txt";
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
            string money;
            if (InsertMoney == "1")
            {
                money = "$1.00";
                vm.FeedMoney(1);
                FeedMoneyAudit(money);
            }
            else if (InsertMoney == "2")
            {
                money = "$5.00";
                vm.FeedMoney(5);
                FeedMoneyAudit(money);
            }
            else if (InsertMoney == "3")
            {
                money = "$10.00";
                vm.FeedMoney(10);
                FeedMoneyAudit(money);
            }
            else if (InsertMoney == "4")
            {
                money = "$20.00";
                vm.FeedMoney(20);
                FeedMoneyAudit(money);
            }
            Console.WriteLine();
            Console.WriteLine("Your current balance is $" + vm.CurrentBalance);
        }
        public void Run()
        {

        }
        public VMCLI(VendingMachine vm)
        {
            this.vm = vm;
        }

        public VMCLI()
        {
        }

        public void FeedMoneyAudit(string money)
        {
            string RecordFeedMoney = "Log.txt";
            string directory = Directory.GetCurrentDirectory();
            RecordFeedMoney = Path.Combine(directory, RecordFeedMoney);
            using (StreamWriter sw = new StreamWriter(RecordFeedMoney, true))
            {
                sw.WriteLine($"{DateTime.UtcNow}    Feed Money       {money.ToString().PadRight(10)}${vm.CurrentBalance.ToString().PadRight(12)}");
            }
        }

        public void PurchaseItemAudit(string ItemName, decimal Price)
        {
            string RecordFeedMoney = "Log.txt";
            string directory = Directory.GetCurrentDirectory();
            RecordFeedMoney = Path.Combine(directory, RecordFeedMoney);
            using (StreamWriter sw = new StreamWriter(RecordFeedMoney, true))
            {
                sw.WriteLine($"{DateTime.UtcNow}    {ItemName.PadRight(15)}  ${Price.ToString().PadRight(10)}${vm.CurrentBalance.ToString().PadRight(10)}");
            }
        }

        public void GiveChangeAudit()
        {
            string RecordFeedMoney = "Log.txt";
            string directory = Directory.GetCurrentDirectory();
            RecordFeedMoney = Path.Combine(directory, RecordFeedMoney);
            using (StreamWriter sw = new StreamWriter(RecordFeedMoney, true))
            {
                sw.Write($"{DateTime.UtcNow}    ");
                sw.Write("Give Change      ");
                sw.Write("$" + vm.CurrentBalance.ToString().PadRight(10));
                sw.WriteLine("$0.00".PadRight(10));
                sw.WriteLine("End of Transaction session");
                sw.WriteLine();
            }
        }
    }
}

