using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp3
{
    internal class Program
    {
        public static void MyMethod(int x, ref int a)
        {
            x += 5;
            a += 5;
        } 
        public static void MyMethod1(params int[] arr)
        {
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        } 
        static void Main(string[] args)
        {
            int sq, cube, quad;
            Multipes m = new Multipes(5, out sq, out cube, out quad);
            Console.WriteLine($"Square : {sq}");
            Console.WriteLine($"Cube : {cube}");
            Console.WriteLine($"Quad : {quad}");


            /* int y = 10;
             int b = 10;
             MyMethod(y,ref b);
             //Value Parametres
             Console.WriteLine(y);
             // Reference Parameters
             Console.WriteLine(b);

             //Params Parameter array

             int[] arr = {2, 3, 4, 5, 6};
             MyMethod1(arr);
 */

            /*int[] arr = new int[4];
            Multipes m = new Multipes();
            m.Multipers(10);
            Console.Write("Enter the No.:");
            int x = int.Parse(Console.ReadLine());
            arr[0] = x;
            arr[1] = m.Square(x);
            arr[2] = m.Cube(x);
            arr[3] = m.Quad(x);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(arr[i]);
            }
            int sqr, cube, quad;
            Console.WriteLine("second way");
            Console.WriteLine(m.Square(x));
            Console.WriteLine(m.Cube(x));
            Console.WriteLine(m.Quad(x));
            Console.WriteLine("third way");
            m.Multiply(2, out sqr, out cube, out quad);
            Console.WriteLine(sqr);
            Console.WriteLine(cube);
            Console.WriteLine(quad);
            Console.WriteLine();*/

            /*Class1 area = new Class1(5, 5, 5);
            area.AreaMethod();*/

            Console.ReadLine();
        }
    }
}
