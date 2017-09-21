using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        private int dimes;
        private int nickles;
        private int quarters;
        private double totalChange;

        public double TotalChange
        {
            get { return totalChange; }
        }
        
        public int Quarters
        {
            get { return quarters; }
        }
        
        public int Nickles
        {
            get { return nickles; }
        }
        
        public int Dimes
        {
            get { return dimes; }
        }

        public Change(decimal amountInDollars)
        {
            this.totalChange = Convert.ToDouble(amountInDollars) * 100; //unsure of order of operations or difference between both Change constructors
        }

        public Change(int amountInCents)
        {
            this.totalChange = amountInCents;
            int remainder = Convert.ToInt32(totalChange % 25);
            quarters = Convert.ToInt32(amountInCents / 25);
            dimes = Convert.ToInt32(remainder / 10);
            remainder = remainder % 10;
            nickles = Convert.ToInt32(remainder / 5);
        }
    }
}
