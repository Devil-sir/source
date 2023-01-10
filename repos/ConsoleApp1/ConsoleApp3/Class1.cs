using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Class1
    {
        private int radius;
        private int? length;
        public int? breadth;
        public Class1(int radius, int? length, int? breadth)
        {
            this.radius = radius;
            this.length = length;
            this.breadth = breadth;
        }
        public void AreaMethod()
        {
            if (length == null || breadth == null)
                Console.WriteLine($"Area of circle: {2 * radius * 3.14F}");
            else
                Console.WriteLine($"Area of rectangle: {length * breadth}");

        }
        /*public void AreaMethod(int l, int b)
        {
            Console.WriteLine( l * b);
        }*/
    }
}
