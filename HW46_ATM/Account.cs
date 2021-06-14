using System;
using System.Collections.Generic;
using System.Text;

namespace HW46_ATM
{
    class Account
    {
        public string Name { get; set; }
        public int Balance { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Account name: {Name} | Balance: {Balance}");
        }
    }
}
