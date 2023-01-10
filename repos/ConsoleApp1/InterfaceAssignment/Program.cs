using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAssignment
{
    /// <summary>
    ///    Create a C# program that implements an IVehicle interface with two methods, 
    ///    one for Drive of type void and another for Refuel of type bool that has a parameter of type 
    ///    integer with the amount of gasoline to refuel.
    ///    Then create a Car class with a builder that receives a parameter with the car's starting 
    ///    gasoline amount and implements the Drive and Refuel methods of the car.
    ///    The Drive method will print on the screen that the car is Driving, if the gasoline is greater than 0. 
    ///    The Refuel method will increase the gasoline of the car and return true.
    ///    To carry out the tests, create an object of type Car with 0 of gasoline in the Main of the program and
    ///    ask the user for an amount of gasoline to refuel, finally execute the Drive method of the car.


    /// </summary>
    
    public interface IVehicle
    {
        void Drive();
        bool Refuel(int Amt);
    }

    public class Car : IVehicle
    {
        public float Gasoline;

        public Car(float gasoline)
        {
            this.Gasoline = gasoline;
        }
        public bool Refuel(int Amt)
        {
            Gasoline = Amt;
            return true;
        }
        public void Drive()
        {
            
            if (Gasoline > 0)
            {
                  Console.WriteLine("Car is Driving");
            }
            else
            {
                Console.WriteLine("Need to refuel tank");
                Console.WriteLine("Enter Amount to refuel car tank:");
                if (this.Refuel(int.Parse(Console.ReadLine())))
                    this.Drive();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car(0);
            c1.Drive(); 


            Console.ReadLine();
        }
    }
}
