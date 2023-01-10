using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        public static int Options()
        {
            Console.WriteLine("You can do following Operations:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Divide");
            Console.WriteLine("5. Modulus");
            Console.WriteLine("6. Square");
            Console.WriteLine("7. SquareRoot");
            Console.WriteLine("8. Power");
            Console.WriteLine("9. Exit");
            int no = int.Parse(Console.ReadLine());
            return no;
        }
        public static bool Continue()
        {
            Console.WriteLine("Do you want to continue: y/n");
            char ans = char.Parse(Console.ReadLine());
            if(ans == 'y')
            {
                return true; 
            }
            return false;
        }
        public static void Method()
        {
            Calculator cal = new Calculator();
            bool check = true;
            bool cont = true;
            double ans = 0;
            while (check)
            {
                int num  = Options();
                double x, y;
                switch (num)
                {
                    case 1:
                        {
                            if (!cont)
                            {
                                Console.WriteLine("Enter numbers for Addition");
                                x = double.Parse(Console.ReadLine());
                                ans = cal.Add(ans,x);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter numbers for Addition");
                                x = double.Parse(Console.ReadLine());
                                y = double.Parse(Console.ReadLine());
                                ans = cal.Add(x, y);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (!cont)
                            {
                                Console.WriteLine("Enter numbers for Subtraction");
                                x = double.Parse(Console.ReadLine());
                                ans = cal.Subtract(ans,x);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;

                            }
                            else
                            {
                                Console.WriteLine("Enter numbers for Subtraction");
                                x = double.Parse(Console.ReadLine());
                                y = double.Parse(Console.ReadLine());
                                ans = cal.Subtract(x, y);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (!cont)
                            {
                                Console.WriteLine("Enter numbers for Multiplication");
                                x = double.Parse(Console.ReadLine());
                                ans = cal.Multiply(ans, x);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter numbers for Multiplication");
                                x = double.Parse(Console.ReadLine());
                                y = double.Parse(Console.ReadLine());
                                ans = cal.Multiply(x, y);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (!cont)
                            {
                                Console.WriteLine("Enter numbers for Divide");
                                x = double.Parse(Console.ReadLine());
                                ans = cal.Divide(ans, x);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;

                            }
                            else
                            {
                                Console.WriteLine("Enter numbers for Divide");
                                x = double.Parse(Console.ReadLine());
                                y = double.Parse(Console.ReadLine());
                                ans = cal.Divide(x, y);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;
                            }
                            break;
                        }
                    case 5:
                        {
                            if (!cont)
                            {
                                Console.WriteLine("Enter numbers for Modulus");
                                x = double.Parse(Console.ReadLine());
                                ans = cal.Modulus(ans, x);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;

                            }
                            else
                            {
                                Console.WriteLine("Enter numbers for Modulus");
                                x = double.Parse(Console.ReadLine());
                                y = double.Parse(Console.ReadLine());
                                ans = cal.Modulus(x, y);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;
                            }
                            break;
                        }
                    case 6:
                        {
                            if (!cont)
                            { 
                                ans = cal.Square(ans);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;

                            }
                            else
                            {
                                Console.WriteLine("Enter numbers for Square");
                                x = double.Parse(Console.ReadLine());
                                ans = cal.Square(x);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;
                            }
                            break;
                        }
                        case 7:
                        {
                            if (!cont)
                            {

                                ans = cal.SquareRoot(ans);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;

                            }
                            else
                            {
                                Console.WriteLine("Enter numbers for Square Root");
                                x = double.Parse(Console.ReadLine());
                                ans = cal.SquareRoot(x);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;
                            }
                            break;
                        }
                         case 8:
                        {
                            if (!cont)
                            {
                                Console.WriteLine("Enter numbers for Power");
                                x = double.Parse(Console.ReadLine());
                                ans = cal.Power(ans, x);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;

                            }
                            else
                            {
                                Console.WriteLine("Enter numbers for Power");
                                x = double.Parse(Console.ReadLine());
                                y = double.Parse(Console.ReadLine());
                                ans = cal.Power(x, y);
                                Console.WriteLine(ans);
                                if (Continue())
                                {
                                    cont = false;
                                }
                                else cont = true;
                            }
                            break;
                        }
                    case 9:
                        {
                            check = false;
                            break;
                        }
                    default:
                        Console.WriteLine("Invaild Input");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Method();
            
            
            
            Console.ReadLine();
        }
    }
}
