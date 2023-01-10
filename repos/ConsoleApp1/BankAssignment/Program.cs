using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank b = new Bank("Ram", "124546", "saving", 1000);
            b.DepositAmount();
            b.Withdrwal();
            Console.ReadLine();
        }
    }
}
