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
            if(amountInCents > 0)
            {
                nickles = 1;
                amountInCents -= nicklesValue;
            }
        }
    }
}
