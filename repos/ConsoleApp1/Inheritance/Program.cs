using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Parent1
    {
        public void Invoice()
        {
            Console.WriteLine("Parent class Invoice invoked");
        }
        public void Discount()
        {
            Console.WriteLine("Parent class discount ");
        }
    }
    internal class Child1 : Parent1
    {
        public void Invoice()
        {
            base.Invoice(); 
            Console.WriteLine("Child class invoice invoked");

        }
        public void Billing()
        {

        }
        public void Discount()
        {
            Console.WriteLine("Child 1 Discount");

        }
    }
    internal class Child2 : Parent1
    {
        public void Discount()
        {
            Console.WriteLine("Child 2 Discount");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Parent1 parent1 = new Parent1();
            Child1 child1 = new Child1();
            Child2 child2 = new Child2();
            parent1.Discount();
            child1.Discount();
            child2.Discount();
            Console.ReadLine();
        }
    }
}
