using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritence1
{
    internal class Bike
    {
        public float costPrice;
        public Bike(float costPrice)
        {
            this.costPrice = costPrice;
        }

        public float readCostPrice()
        {
            Console.WriteLine("Enter Cost Price: ");
            this.costPrice = float.Parse(Console.ReadLine());
            return costPrice;
        }

        public float GST()
        {
            return (float)0.18 * costPrice;

        }
    }
    internal class Discount : Bike
    {
        public float discount;
        public float totalPrice;
        public Discount(float totalPrice, float costPrice):base(costPrice)
        {
            this.totalPrice = totalPrice;
        }

        public void DiscountAmt()
        {
            Console.WriteLine("Enter Discount Percentage: ");
            this.discount = float.Parse(Console.ReadLine());
            Console.WriteLine("Final Price is: "+ (float) (totalPrice - (discount / 100) * totalPrice));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Cost Price of Bike: ");
            float cp = float.Parse(Console.ReadLine());
            Bike b = new Bike(cp);
            Discount d = new Discount(cp + b.GST(), cp);
            d.DiscountAmt();          

            Console.ReadLine();

        }
    }
}
