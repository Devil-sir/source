using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegetMethod
{
    //public delegate void MyDelegate(int x);

    internal class Program
    {
        public static void Square(int y)
        {
            Console.WriteLine(y * y);
        }
        public static void Cube(int y)
        {
            Console.WriteLine(y * y * y);
        }
        public static void Quad(int y)
        {
            Console.WriteLine(y * y * y * y);
        }
        public static int Addition(int x, int y)
        {
            return x + y;
        }
        public static string fun(int x, int y, int z, int a, int b, int f, int h, int j, int m, int u, int t, int s, int e, int w){
            Console.WriteLine("Hello");
            return " ";
        }
        public delegate void petname(string name);
        
        static void Main(string[] args)
        {
            
            /*Func<int, int, int> f = Addition;
            Console.WriteLine(f.Invoke(10, 20));

            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> p = fun;
            p.Invoke(1,2,3,4,5,6,7,8,9,10,11,12,13,14);
*/
            /* Predicate<string> p1 = check;
             p1.Invoke();*/
            string b = "Dog";
            petname pan = delegate(string pname){
                Console.WriteLine(pname);
                Console.WriteLine(b);
            };
            pan("Cat");
            //MyDelegate m  = new MyDelegate(Square);
            /*Action<int> m = Square;
            m += Cube;
            m += Quad;
            m.Invoke(10);*/
            Console.ReadLine();
        }
    }
}
