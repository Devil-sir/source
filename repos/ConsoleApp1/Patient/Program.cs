using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    internal class Program
    {
        /*public static void displayOption()
        {
            
        }*/
        
        static void Main(string[] args)
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("Display options using Store Procedure");
                Console.WriteLine("1. Display All Data");
                Console.WriteLine("2. Display by Age");
                Console.WriteLine("3. Display by Disease");
                Console.WriteLine("4. Create Procedure");
                Console.WriteLine("5. Check Id in Patient DB");
                Console.WriteLine("6. Exit");
                Console.Write("Choose the option: ");
                int val = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (val)
                {
                    case 1:
                        {
                            Display display = new Display();
                            List<PatientSchema> patients = display.fetchData();
                            foreach (PatientSchema p in patients)
                            {
                                Console.WriteLine($"{p.id} | {p.name} | {p.age} | {p.disease}");
                            }
                            Console.WriteLine();
                            break;
                        }
                        case 2:
                        {
                            Display display = new Display();
                            List<PatientSchema> patients = display.fetchDataByAge();
                            foreach (PatientSchema p in patients)
                            {
                                Console.WriteLine($"{p.id} | {p.name} | {p.age} | {p.disease}");
                            }
                            Console.WriteLine();
                            break;
                        }
                    case 3:
                        {
                            Display display = new Display();
                            List<PatientSchema> patients = display.fetchDataByDisease();
                            foreach (PatientSchema p in patients)
                            {
                                Console.WriteLine($"{p.id} | {p.name} | {p.age} | {p.disease}");
                            }
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            Display display = new Display();
                            display.CreateProcedure();
                            List<PatientSchema> patients = display.fetchData();
                            foreach (PatientSchema p in patients)
                            {
                                Console.WriteLine($"{p.id} | {p.name} | {p.age} | {p.disease}");
                            }
                            Console.WriteLine();
                            break;
                        }
                    case 5:
                        {
                            Display display = new Display();
                            display.fetchDataById();
                            Console.WriteLine();
                            break;
                        }
                    case 6:
                        {
                            check = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Input!!");
                            break;
                        }
                }
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
