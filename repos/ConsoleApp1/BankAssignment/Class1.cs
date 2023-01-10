using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAssignment
{
    internal class Bank
    {
        public string name;
        public string accno;
        public string typeofAccount;
        public int balance;
        public Bank(string name, string accno, string typeofAccount, int balance)
        {
            this.name = name;
            this.accno = accno;
            this.typeofAccount = typeofAccount;
            this.balance = balance;
        }
        public void DepositAmount()
        {
            Console.WriteLine("Enter Amount to be Deposited:");
            int amount = int.Parse(Console.ReadLine());
            this.balance += amount;
            Console.WriteLine("The bank holder is: " + this.name);
            Console.WriteLine("The bank account Number is: " + this.accno);
            Console.WriteLine("the Current Balance is: " + this.balance);

        }
        public void Withdrwal()
        {
            Console.WriteLine("Enter Amount to be Withdrawal:");
            int withdrawalAmt = int.Parse(Console.ReadLine());
            if (balance > withdrawalAmt)
            {
                Console.WriteLine("Amount Debited");
                this.balance -= withdrawalAmt;
                Console.WriteLine("The bank holder is: " + this.name);
                Console.WriteLine("The bank account Number is: " + this.accno);
                Console.WriteLine("the Current Balance is: " + this.balance);
            }
            else Console.WriteLine("Insufficient balance");
        }
    }
}
