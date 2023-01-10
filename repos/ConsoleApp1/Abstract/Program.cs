using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    /*public interface IInvoicing
    {
        int Greeting(DateTime DOB);

    }
    public interface IBilling
    {
        void Estimate(string customerId, string customerName);
        int Greeting(DateTime DOB);
    }
    public class Child : IBilling,IInvoicing
    {
        public void Estimate(string customerId, string customerName)
        {

        }
        public int Greeting(DateTime DOB)
        {
            return 0;

        }
        int IInvoicing.Greeting(DateTime DOB)
        {
            return 0;
        }
    } */

    //*******************Partial Classes******************

    /*public interface P1
    {
        int Method1(int a, int b);
        void Method();

    }
    public partial class C1 : P1
    {
        public void Method()
        {
            Console.WriteLine("Hello");
        }
    }
    public partial class C1
    {
        public int Method1(int a, int b)
        {
            return a + b;
        }
    }*/

    //*******************Abstract Class*********************
    public abstract class MyAbstract
    {
        public abstract void M1();
        public void M2()
        {

        }
    }
    public class Child : MyAbstract
    {
        public override void M1()
        {
            Console.WriteLine("Hello");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
