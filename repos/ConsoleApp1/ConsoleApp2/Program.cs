using ConsoleApp2.Assignment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Selling Price:");
            int s = int.Parse(Console.ReadLine());
            ProfitLoss pl = new ProfitLoss(s);
            pl.ReadCostPrice();
            pl.PoiftLossCheck();









            /*    string path = "C:\\Desktop\n";
                Console.Write(path);
                string fn = "Rahul";
                string ln = "Yadav";
                Console.WriteLine("Hey my name is " + fn + " "+ ln +" hello");
                Console.WriteLine("Hey my name is {0} {1}", fn, ln);
                Console.WriteLine($"Hey my name is {fn} {ln}");

                //Console.ReadLine();
                string article = "Candidates who qualify in JAM 2023 examination should pass an undergraduate degree or should be currently studying in their final year of the undergraduate programme for admission to the Indian Institute of Technology (IIT) and National Institute of Technology (NIT). The exam is open to all national candidates with no age restriction. The JAM 2023 score will be valid only for a year.\r\n\r\nThe IIT JAM 2023 exam will be conducted in over 100 cities in India in the Computer Based Test (CBT) mode. The exam will be conducted in seven test papers, including Biotechnology, Chemistry, Economics, Geology, Mathematics, Mathematical Statistics and Physics. The candidates can appear for either one or two test papers.\r\n\r\nThrough this exam, over 3000 seats in various IITs and over 2000 seats in various NITs will be filled for the master's programmes including MSc, MSc (Tech), MSc – MTech Dual Degree, MSc - MS (Research), Joint MSc - PhD, MSc – PhD Dual Degree and Integrated PhD.\r\n\r\nThe JAM 2023 score might also be used by other centrally funded technical institutions including the Indian Institute of Science (IISc) Bangalore, Jawaharlal Nehru Centre for Advanced Scientific Research (JNCASR), Indian Institute of Engineering Science and Technology (IIEST) Shibpur, Sant Longowal Institute of Engineering and Technology (SLIET) Punjab, Defence Institute of Advanced Technology (DIAT) and Indian Institutes of Science Education and Research (IISERs) for admission to their master's programmes.";
                bool check = article.Contains("exam");
                article.Split('.');
                if (check)
                    Console.WriteLine("Rejected");
                else
                    Console.WriteLine("Approved");*/
            /*string article = "Candidates who qualify in JAM 2023 examination should pass an undergraduate degree or should be currently studying in their final year of the undergraduate programme for admission to the Indian Institute of Technology (IIT) and National Institute of Technology (NIT). The exam is open to all national candidates with no age restriction. The JAM 2023 score will be valid only for a year.\r\n\r\nThe IIT JAM 2023 exam will be conducted in over 100 cities in India in the Computer Based Test (CBT) mode. The exam will be conducted in seven test papers, including Biotechnology, Chemistry, Economics, Geology, Mathematics, Mathematical Statistics and Physics. The candidates can appear for either one or two test papers.\r\n\r\nThrough this exam, over 3000 seats in various IITs and over 2000 seats in various NITs will be filled for the master's programmes including MSc, MSc (Tech), MSc – MTech Dual Degree, MSc - MS (Research), Joint MSc - PhD, MSc – PhD Dual Degree and Integrated PhD.\r\n\r\nThe JAM 2023 score might also be used by other centrally funded technical institutions including the Indian Institute of Science (IISc) Bangalore, Jawaharlal Nehru Centre for Advanced Scientific Research (JNCASR), Indian Institute of Engineering Science and Technology (IIEST) Shibpur, Sant Longowal Institute of Engineering and Technology (SLIET) Punjab, Defence Institute of Advanced Technology (DIAT) and Indian Institutes of Science Education and Research (IISERs) for admission to their master's programmes.";
            char ch = 'y';
            while(ch != 'n')
            {
                Console.Write("Enter blocked word:");
                
                if (article.Contains(Console.ReadLine()))
                    Console.WriteLine("Rejected");
                else
                    Console.WriteLine("Approved");
                Console.Write("Do you want to continue:");
                if (Console.Read() != 'y')
                {
                    ch = 'n';
                    //Console.Clear();
                }
                else ch = 'y';  */




            Console.ReadLine();

        }
    }
}
