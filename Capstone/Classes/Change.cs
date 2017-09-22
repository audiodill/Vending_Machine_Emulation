using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        private decimal dimesValue = .10M;
        private decimal nicklesValue = .5M;
        private decimal quartersValue = .25M;
        private int quarters;
        private int dimes;
        private int nickles;
        //private decimal totalChange;
        //private int amountInCents;

        //public decimal TotalChange
        //{
        //    get { return totalChange; }
        //}
        
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

        public Change(decimal amountInCents)
        {

            while(amountInCents / .25m >= 1)
            {
                quarters++;
                amountInCents -= quartersValue;
            }
            while(amountInCents / .10m >= 1)
            {
                dimes++;
                amountInCents -= dimesValue;
            }
            while(amountInCents / .5m > 1)
            {
                nickles++;
                amountInCents -= nicklesValue;
            }
            
            //this.totalChange = amountInCents;
            //decimal remainder = totalChange % 25;
            //quartersValue = amountInCents / 25;
            //dimesValue = remainder / 10;
            //remainder = remainder % 10;
            //nicklesValue = remainder / 5;

            //this.totalChange = amountInCents;
            //int remainder = Convert.ToInt32(totalChange % 25);
            //quarters = Convert.ToInt32(amountInCents / 25);
            //dimes = Convert.ToInt32(remainder / 10);
            //remainder = remainder % 10;
            //nickles = Convert.ToInt32(remainder / 5);
            
        }

        //public Change(decimal amountInDollars)
        //{
        //    this.totalChange = Convert.ToInt32(amountInDollars) * 100;
        //    amountInCents = Convert.ToInt32(amountInDollars);
        //    //unsure of order of operations or difference between both Change constructors
        //}

        
    }
}
