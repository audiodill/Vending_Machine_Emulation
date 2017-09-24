using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class VMItem
    {

        protected string itemName;
        protected decimal priceInCents;

        public decimal Price
        {
            get { return priceInCents ; } 
        }

        public string ItemName
        {
            get { return itemName; }
        }

        public VMItem(string itemName, decimal priceInCents)
        {
            this.itemName = itemName;
            this.priceInCents = priceInCents;
        }

        public abstract string Consume(); 
    }
}
