﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private VMFileReader inventorySource;

        public decimal CurrentBalance
        {
            get { return currentBalance; }
        }

        public string[] Slots
        {
            //foreach(VMItem KeyValuePair in  )
            get { return slots = this.inventory.Keys.ToArray();  }
            ////{
            ////    for(int i = 0; i < inventory.Count; i++)
            //////    {
            //////        Slots[i] = inventory.ContainsKey[i];
            ////    }
            //    //foreach (VMItem KeyValuePair in inventory)
            //    //{
            //    //    Slots[] = 
            //    //}
            //}

        }

        //public VendingMachine()
        //{
        //    VMFileReader reader = new VMFileReader("vendingmachine.csv");
        //    this.inventory = reader.GetInventory();
        //}

        public VendingMachine(Dictionary<string, List<VMItem>> inventory)
        {
            this.inventory = inventory;
        }

        public void FeedMoney()
        {
            this.currentBalance += currentBalance; //still unsure if not in 'amount in dollars'
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
            try
            {
                if (inventory.ContainsKey(slotID))
                {
                    validSlot = true;
                    
                }
                if (inventory[slotID].Count > 0)
                {
                    enoughQuanity = true;
                }
                if (currentBalance > inventory[slotID][1].Price)
                {
                    enoughMoneyInMachine = true;
                }
                
                if(validSlot && enoughQuanity && enoughMoneyInMachine)
                {
                    VMItem returnItemToCustomer =  inventory[slotID][0];
                    inventory[slotID].RemoveAt(slotID[0]);
                    currentBalance = currentBalance - inventory[slotID][1].Price;
                    return returnItemToCustomer;

                }
                else
                {
                    // do nothing friend-o
                }

            }
            catch(Exception ex)
            {
                if (!validSlot)
                {
                    System.Exception newexe = new InvalidSlotIDException("You punched the wrong spot", ex);
                    
                }
                else if (!enoughQuanity)
                {
                    Exception newexe = new OutOfStockException("Sold out!", ex);
                }
                else
                {
                    Exception newexe = new InsufficientFundsException("Gimme moar moneys", ex);
                }

            }
            finally
            {
                // loop through CLI and stuff
            }
            return null;


            
        }

        public Change ReturnChange()
        {
            Change amountInCents = new Change(currentBalance);
            return amountInCents;
            // seems too easy >_>

            
        }
    }
}
