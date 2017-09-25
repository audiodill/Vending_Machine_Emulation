using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MenuHeaderClass
    {

        public string GetAddMoneyHeader()
        {
            StringBuilder sb = new StringBuilder();
            string feedMoney = "FeedMeMoney.txt";
            try
            {
                using (StreamReader sr = new StreamReader(feedMoney))
                {
                    string nextLine = "";
                    while (!sr.EndOfStream)
                    {
                        sb.AppendLine(sr.ReadLine());                        
                    }                    
                }                
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading FeedMeMoney.txt");
            }

            return sb.ToString();
        }
    }
}
