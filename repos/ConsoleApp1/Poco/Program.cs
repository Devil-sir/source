using Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
/*
    public void Method1(){
         
        }*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "Ram");
            dic.Add(2, "Guruji");
            foreach (KeyValuePair<int, string> ksp in dic)
            {
                Console.WriteLine(ksp.Key + " || " + ksp.Value);
            }

            Dictionary<int, Patient> patients = new Dictionary<int, Patient>();
            Patient patient = new Patient();
            patient.Id = 1;
            patient.Name = "Ramesh";
            patient.temp = 102.24F;
            patients.Add(patient.Id, patient);
            Patient patient2 = new Patient() { 
                Id = 2,
                Name = "Satish",
                temp = 85.24F
            };
            patients.Add(patient2.Id,patient2);
            foreach(KeyValuePair<int, Patient> ksp in patients)
            {
                Console.WriteLine(ksp.Key + " || " + ksp.Value.Id + " || " + ksp.Value.Name + " || " + ksp.Value.temp);
            }

            /* Stack<int> marks = new Stack<int>();
             marks.Push(1);
             marks.Push(2);
             marks.Peek();
             marks.Pop();


             Queue<int> queue = new Queue<int>();
             queue.Enqueue(1);
             queue.Enqueue(2);
             queue.Enqueue(3);



             List<string> books = new List<string>();
             books.Add("Pride and Prejudice");
             books.Add("Sense and Sensibilty");*/



            /* List<Patient> patients = new List<Patient>();
             Patient patient = new Patient();
             patient.Id = 1;
             patient.Name = "Ramesh";
             patient.temp = 102.24F;
             patients.Add(patient);
             Patient patient2 = new Patient();
             patient2.Id = 2;
             patient2.Name = "Satish";
             patient2.temp = 85.24F;
             patients.Add(patient2);
             foreach (Patient pat in patients)
             {
                 Console.WriteLine($"{pat.Id}  | {pat.Name} | {pat.temp}");
             }*/


            /*
                        MyClass<string> obj = new MyClass<string>();
                        obj.Name = "Hello";
                        obj.MyMethod("hi");*/
            Console.ReadLine();
        }
    }
    public class MyClass<T>
    {
        public int Value;
        public T Name { get; set; }
        public void MyMethod(T x)
        {
            if(typeof(T) == typeof(string))
            {
                Console.WriteLine("Send Email");
            }
            else if(typeof(T) == typeof(int))
            {
                Console.WriteLine("Send SMS");
            }
        }
        
    }
}
