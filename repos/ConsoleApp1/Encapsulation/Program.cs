using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Mul
    {
        private int id;
        public  int getId()
        {
            return this.id;
        }
        private int x;
        public Mul(int x)
        {
            this.x = x;
        }
        public int[] PowerTo()
        {
            int[] values = new int[3];
            values[0] = x*x;
            values[1] = x*x*x;
            values [2] = x*x*x*x;
            return values;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number: ");
            Mul m = new Mul(int.Parse(Console.ReadLine()));
            int[] mul =  m.PowerTo();
            Console.WriteLine("the square is {0}, the cube is {1}, the quad is {2}", mul[0], mul[1], mul[2]);
            Console.ReadLine();
        }
    }
}
