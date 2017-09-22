using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class InsufficientFundsException : VendingMachineException
    {
        private string v;
        private Exception ex;

        public InsufficientFundsException(string v, Exception ex)
        {
            this.v = v;
            this.ex = ex;
        }
    }
}
