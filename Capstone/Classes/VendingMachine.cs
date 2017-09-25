using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class VendingMachine //skeleton v1.2
    {
        public bool validSlot = false;
        public bool enoughQuanity = false;
        public bool enoughMoneyInMachine = false;
        private string[] slots;
        private decimal currentBalance;
        Dictionary<string, List<VMItem>> inventory = new Dictionary<string, List<VMItem>>();

        public decimal CurrentBalance
        {
            get { return currentBalance; }
        }

        public string[] Slots
        {
            get { return slots = this.inventory.Keys.ToArray(); }
        }

        public VendingMachine(Dictionary<string, List<VMItem>> inventory)
        {
            this.inventory = inventory;
        }

        public void FeedMoney(decimal money)
        {
            this.currentBalance += money;
        }

        public VMItem GetItemAtSlot(string slotID)
        {
            if (inventory.ContainsKey(slotID))
            {
                return inventory[slotID][0];
            }
            else
            {
                return null;
            }
        }

        public int GetQuantityRemaining(string slotID)
        {
            if (inventory.ContainsKey(slotID))
            {
                return inventory[slotID].Count;
            }
            return 0;
        }

        public VMItem Purchase(string slotID)
        {
            if (!inventory.ContainsKey(slotID))
            {
                throw new InvalidSlotIDException("Error: You punched the wrong spot");
            }

            if ((inventory[slotID].Count == 1))
            {
                throw new OutOfStockException("Error: Sold Out");
            }

            if (!(currentBalance > inventory[slotID][1].Price))
            {
                throw new InsufficientFundsException("Error: Please insert more money");
            }


            VMItem returnItemToCustomer = inventory[slotID][0];
            inventory[slotID].RemoveAt(0);
            currentBalance = currentBalance - returnItemToCustomer.Price;
            return returnItemToCustomer;            
        }

        public Change ReturnChange()
        {
            Change amountInCents = new Change(currentBalance);
            return amountInCents;
        }
    }
}
