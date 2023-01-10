using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bike
{
    internal class Bike
    {
        public int id { set; get; }
        public string Color { set; get; }
        public int tyres { set; get; }

        public virtual void Discount()
        {
            Console.WriteLine("Parent class Discount");
        }
    }    
    internal class Gixxer : Bike
    {
        public override void Discount()
        {
            Console.WriteLine("Child 1 Gixxer Discount");
        }
    }
    internal class Hornet : Bike
    {
        public override void Discount()
        {
            Console.WriteLine("Child 2 Hornet Discount");
        }
    } 
    internal class Program
    {
        static void Main(string[] args)
        {
            /*    Bike b = new Gixxer();
                // call dicount of parent class
                b.Discount();
                // If we want to call child class discount then
                // write virtual and override keywords before return type
                // parent class - public virtual void dicount() {}
                // Child class - public override void Discount() {}
                b = new Hornet();
                b.Discount();*/
            /*Array Impelmentation of parent class &  the obj of the child class get lost when we update(like(b = new Horent());)*/ 
            Bike[] b = new Bike[2];
            b[0] = new Gixxer();
            b[1] = new Hornet();
            b[0].Discount();
            b[1].Discount();
            Console.ReadLine();

        }
    }
}
