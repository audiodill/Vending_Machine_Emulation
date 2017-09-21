using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachine //skeleton
    {
        private decimal currentBalance;
        Dictionary<string, List<VMItem>> inventory = new Dictionary<string, List<VMItem>>();
        private VMFileReader inventorySource;
        //

        public decimal CurrentBalance
        {
            get { return currentBalance; }
        }

        public string[] Slots
        {
            get; //This may be where we define our slots
        }

        public VendingMachine()
        {
            VMFileReader reader = new VMFileReader("vendingmachine.csv");
            this.inventory = reader.GetInventory();
        }

        public VendingMachine(Dictionary<string, List<VendingMachine>> inventory)
        {

        }

        public void FeedMoney()
        {

        }

        public VMItem GetItemAtSlot(string slotID)
        {
            return null;
            //idk
        }

        public int GetQuantityRemaining(string slotID)
        {
            return 0;
        }

        public VMItem Purchase(string slotID)
        {
            return null;
        }

        public Change ReturnChange()
        {
            return null;
        }
    }
}
