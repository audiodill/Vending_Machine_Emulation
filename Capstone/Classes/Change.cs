using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        private const decimal DimesValue = .10M;
        private const decimal NicklesValue = .5M;
        private const decimal QuartersValue = .25M;
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

            while(amountInCents / QuartersValue >= 1)
            {
                quarters++;
                amountInCents -= QuartersValue;
            }
            while(amountInCents / DimesValue >= 1)
            {
                dimes++;
                amountInCents -= DimesValue;
            }
            if(amountInCents > 0)
            {
                nickles = 1;
                amountInCents -= NicklesValue;
            }
        }
    }
}
