using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentMonday
{
    
    public class revenue
    {
        public float costPrice;
        public float sellingPrice;
        public revenue(float sellingPrice)
        {
           /* this.costPrice = costPrice;*/
            this.sellingPrice = sellingPrice;
        }
        public void read()
        { 
            Console.WriteLine("Enter Cost Price:");
            this.costPrice = float.Parse(Console.ReadLine());

        }
        public void proiftLoss()
        {
            if(sellingPrice > costPrice) {
                Console.WriteLine("Profit is: " + ((sellingPrice - costPrice) / costPrice) * 100 + " %");
            }
            else
                Console.WriteLine("Profit is: " + ((costPrice - sellingPrice) / costPrice) * 100 + " %");
        }
    }

    internal class Conversion
    {
        public float celsius;
        public Conversion(float celsius)
        {
            this.celsius = celsius;
        }
        public void convert()
        {
            float fahrenheit = (celsius * 9) / 5 + 32;
            Console.WriteLine("Fahernheit is : " + fahrenheit);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Selling Price:");
            float s = float.Parse(Console.ReadLine());
            revenue r = new revenue(s);
            r.read();
            r.proiftLoss();

           
            Console.WriteLine("Enter temperature in celsius:");
            float x = float.Parse(Console.ReadLine());
            Conversion con = new Conversion(x);
            con.convert();

            Console.ReadLine();
        }

    }
}
