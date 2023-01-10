using DbConnection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection
{
    internal class Program
    {
        public static void Display(List<Employee> elist)
        {
            foreach (Employee el in elist)
            {
                Console.WriteLine(el.empId + "||" + el.empName + "||" + el.empSalary + "||" + el.empDepartment);
            }
            Console.WriteLine();    
        }
        
        public static int Options()
        {
            Console.WriteLine("You can do following Operations:");
            Console.WriteLine("1. Display");
            Console.WriteLine("2. Insert");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Exit");
            int no = int.Parse(Console.ReadLine());
            return no;
        }

        static void Main(string[] args)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails();
            Employee employee = new Employee();
            bool check = true;
            while (check)
            {
                int no = Options();
                switch (no)
                {
                    case 1:
                        {
                            employeeDetails.GetEmployees();
                            //Display(elist);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Employee Id:");
                            employee.empId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Employee Name:");
                            employee.empName = Console.ReadLine();
                            Console.WriteLine("Enter Employee Salary:");
                            employee.empSalary = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Employee Department:");
                            employee.empDepartment = Console.ReadLine();
                            employeeDetails.InsertEmployee(employee);
                            break;
                        }
                    case 3:
                        {
                            employeeDetails.UpdateEmployee();
                            break;
                        }
                    case 4:
                        { 
                            Console.WriteLine("Enter Employee Id to be Deleted");
                            employee.empId = int.Parse(Console.ReadLine());
                            employeeDetails.DeleteEmployee(employee);
                            break;
                        }
                    case 5:
                        {
                            check = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }
                }
            }
            
            /*EmpolyeeAddressDetails empolyeeAddressDetails = new EmpolyeeAddressDetails();
            List<EmployeeAddress> eAddress = empolyeeAddressDetails.GetEmployeeAddresses();
            foreach(EmployeeAddress ea in eAddress)
            {
                Console.WriteLine($"{ea.houseno}|{ea.street}|{ea.area}|{ea.city}|{ea.state}|{ea.pincode}");
            }*/

            Console.ReadLine();
            
        }
    }
}
