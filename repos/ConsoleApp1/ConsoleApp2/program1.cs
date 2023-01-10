using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class program1
    {

    }
    public class Multipes {
        private int a; 
        public Multipes(int a,out int sq, out int cube, out int quad)
        {
            this.a = a;
            sq = a * a;
            cube = a * a * a;
            quad = a * a * a * a;
        }
        public void Multipers(int x)
        {
            Console.WriteLine($"The Square is: {x * x}");
            Console.WriteLine($"The Cube is: {x * x * x}");
            Console.WriteLine($"The Quad is: {x * x * x * x}");
        }
        public int Square(int x)
        {
            return x * x;
        }
        public int Cube(int x)
        {
            return x * x * x;
        }
        public int Quad(int x)
        {
            return x * x * x * x ;
        }
        public void Multiply(int x, out int sqr, out int cube, out int quad)
        { 
            sqr = x * x;
            cube = x * x * x;
            quad = x * x * x * x;
            /*return sqr;
            return cube;
            return quad;*/
        }

    }

}
