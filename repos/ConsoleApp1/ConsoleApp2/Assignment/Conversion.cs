using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Assignment
{
    public class ProfitLoss
    {
        public int CostPrice;
        public int SellingPrice;
        public ProfitLoss(int SellingPrice)
        {
            /* this.costPrice = costPrice;*/
            this.SellingPrice = SellingPrice;
        }
        public void ReadCostPrice()
        {
            Console.WriteLine("Enter Cost Price:");
            this.CostPrice = int.Parse(Console.ReadLine());

        }
        public void PoiftLossCheck()
        {
            if (SellingPrice > CostPrice)
            {
                Console.WriteLine("Profit is: " + ((SellingPrice - CostPrice) / CostPrice) * 100 + " %");
            }
            else
                Console.WriteLine("Profit is: " + ((CostPrice - SellingPrice) / CostPrice) * 100 + " %");
        }
    }
}
