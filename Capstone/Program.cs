using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;
using System.Runtime.InteropServices;

namespace Capstone
{
    class Program
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            VMFileReader stockInventory = new VMFileReader("vendingmachine.csv");
            Dictionary<string, List<VMItem>> inventory = stockInventory.GetInventory();
            VendingMachine vm = new VendingMachine(inventory);
            VMCLI mainmenu = new VMCLI(vm);
            mainmenu.Display();
        }
    }
}
