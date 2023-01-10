using DbConnection.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection
{
    
    internal class EmployeeDetails
    {
        //Establishing Connection to database
        SqlConnection con  = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ToString());
        //Read dta from Database
        //SqlDataAdapter -- disconnection architecture
        public void GetEmployees()
        {
            
            
            bool check = true;
            while (check)
            {
                List<Employee> emp1 = new List<Employee>();
                Console.WriteLine("Display Options");
                Console.WriteLine("1. Display");
                Console.WriteLine("2. Display based on salary");
                Console.WriteLine("3. Display based on Department");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option : ");
                int opt = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (opt)
                {
                    case 1:
                        {
                            SqlDataAdapter da = new SqlDataAdapter("select * from emp", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            foreach (DataRow datarow in dt.Rows)
                            {
                                Employee e = new Employee();
                                e.empId = int.Parse(datarow["empId"].ToString());
                                e.empName = datarow["empName"].ToString();
                                e.empSalary = int.Parse(datarow["empSalary"].ToString());
                                e.empDepartment = datarow["empDepartment"].ToString();
                                emp1.Add(e);
                            }
                            Program.Display(emp1);
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter the Salray to compare:");
                            int val = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            SqlDataAdapter da = new SqlDataAdapter("select * from emp where empSalary > '"+val+"' ", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            foreach (DataRow datarow in dt.Rows)
                            {
                                Employee e = new Employee();
                                e.empId = int.Parse(datarow["empId"].ToString());
                                e.empName = datarow["empName"].ToString();
                                e.empSalary = int.Parse(datarow["empSalary"].ToString());
                                e.empDepartment = datarow["empDepartment"].ToString();
                                emp1.Add(e);
                            }
                            Program.Display(emp1);
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Enter the Department:");
                            string str = Console.ReadLine();
                            Console.WriteLine();
                            SqlDataAdapter da = new SqlDataAdapter("select * from emp where empDepartment = '" + str + "'", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            foreach (DataRow datarow in dt.Rows)
                            {
                                Employee e = new Employee();
                                e.empId = int.Parse(datarow["empId"].ToString());
                                e.empName = datarow["empName"].ToString();
                                e.empSalary = int.Parse(datarow["empSalary"].ToString());
                                e.empDepartment = datarow["empDepartment"].ToString();
                                emp1.Add(e);
                            }
                            Program.Display(emp1);
                            break;
                        }
                    case 4:
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

           //return emp1;

        }
        /*public List<Employee> GetEmployeesBySalary()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select ",con);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            List<Employee> employees = new List<Employee>();
            foreach(DataRow dataRow in dt.Rows)
            {
                Employee emp = new Employee();
                emp.empId = int.Parse(dataRow["empId"].ToString());
                emp.empName = dataRow["empName"].ToString();
                emp.empSalary = int.Parse(dataRow["empSalary"].ToString());
                emp.empDepartment = dataRow["empDepartment"].ToString();
                employees.Add(emp);
            }
            return employees;
        } 
*/
        //Insert into database
        public void InsertEmployee(Employee e)
        {
            SqlCommand sqlCommand = new SqlCommand("Insert into emp(empId,empName,empSalary,empDepartment) Values ('" + e.empId + "','" + e.empName + "','" + e.empSalary +"','"+ e.empDepartment +"')",con);
            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Successfully Inserted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            con.Close();
        }
        
        
        
        //Delete from database
        public void DeleteEmployee(Employee e)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from emp where empId = '" + e.empId + "'", con);
            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Successfully Deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            con.Close();
        }

        /*public int optionsforUpdate()
        {

            Console.WriteLine("Enter which Column to be updated");
            Console.WriteLine("1. empId");
            Console.WriteLine("2. empName");
            Console.WriteLine("3. empNumber");
            int num = int.Parse(Console.ReadLine());
            return num;
        }*/


        public void UpdateEmployee()
        {
            Employee e = new Employee();
            Console.WriteLine("Enter which Column to be updated");
            //Console.WriteLine("1. empId");
            Console.WriteLine("1. empName");
            Console.WriteLine("2. empSalary");
            Console.WriteLine("3. empDepartment");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                /*case 1:
                    {
                        Console.WriteLine("Enter Empolyee Id to be Updated:");
                        e.empId = int.Parse(Console.ReadLine());
                        //int opt = optionsforUpdate();
                        Console.WriteLine("Enter the ref Value:");
                        int val = int.Parse(Console.ReadLine());
                        SqlCommand sqlCommand = new SqlCommand("Update emp set empId = '" + e.empId + "' where empId = '" + val + "'", con);
                        try
                        {
                            con.Open();
                            sqlCommand.ExecuteNonQuery();
                            Console.WriteLine("Successfully Updated!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        con.Close();
                        break;
                    }*/
                case 1:
                    {
                        Console.WriteLine("Enter Empolyee Name to be Updated:");
                        e.empName = Console.ReadLine();
                        //int opt = optionsforUpdate();
                        Console.WriteLine("Enter the ref Value:");
                        int val = int.Parse(Console.ReadLine());
                        SqlCommand sqlCommand = new SqlCommand("Update emp set empName = '" + e.empName + "' where empId = '" + val + "'", con);
                        try
                        {
                            con.Open();
                            sqlCommand.ExecuteNonQuery();
                            Console.WriteLine("Successfully Updated!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        con.Close(); 
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter Empolyee Salary to be Updated:");
                        e.empSalary = int.Parse(Console.ReadLine());
                        //int opt = optionsforUpdate();
                        Console.WriteLine("Enter the ref Value:");
                        int val = int.Parse(Console.ReadLine());
                        SqlCommand sqlCommand = new SqlCommand("Update emp set empSalary = '" + e.empSalary + "' where empId = '" + val + "'", con);
                        try
                        {
                            con.Open();
                            sqlCommand.ExecuteNonQuery();
                            Console.WriteLine("Successfully Updated!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        con.Close();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter Empolyee Department to be Updated:");
                        e.empDepartment = Console.ReadLine();
                        //int opt = optionsforUpdate();
                        Console.WriteLine("Enter the ref Value:");
                        int val = int.Parse(Console.ReadLine());
                        SqlCommand sqlCommand = new SqlCommand("Update emp set empDepartment = '" + e.empDepartment + "' where empId = '" + val + "'", con);
                        try
                        {
                            con.Open();
                            sqlCommand.ExecuteNonQuery();
                            Console.WriteLine("Successfully Updated!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        con.Close();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invaild Input");
                        break;
                    }
            }
            /*int val = 0;
            bool check = int.TryParse(Console.ReadLine(), out val);
            if (check)
                e.empId = val;
            else
                Console.WriteLine("Please enter a valid number");*/
        }
    }

 
}
