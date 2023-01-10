using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Calculator : Calc
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Subtract(double x, double y)
        {
            return x- y;
        }
        public double Multiply(double x, double y)
        {
            return x * y;
        }
        public double Divide(double x, double y)
        {
            return x / y;
        }
        public double Modulus(double x, double y)
        {
            return x % y;
        }
        public double Square(double x)
        {
            return x * x;
        }
        public double SquareRoot(double x)
        {
            return Math.Sqrt(x);
        }
        public double Power(double x,double y)
        {
            return Math.Pow(x, y);
        }
    }
}
