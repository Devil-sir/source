using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class Display
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ToString());
        public void CreateProcedure()
        {
            Console.Write("Enter stored Procedure Name: ");
            string str = Console.ReadLine();
            SqlCommand sqlCommand = new SqlCommand("CREATE PROCEDURE '"+ str +"' AS SELECT * FROM patient GO", con);
            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Successfully Created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            con.Close();
        }

        public List<PatientSchema> fetchData()
        {

           /*SqlCommand scmd = new SqlCommand("SelectAllPatient");
            scmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlData = new SqlDataAdapter(scmd);*/
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("EXEC SelectAllPatient", con);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            List<PatientSchema> patients = new List<PatientSchema>();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                PatientSchema patient = new PatientSchema();
                patient.id = int.Parse(dataRow["id"].ToString());
                patient.name = dataRow["name"].ToString();
                patient.age = int.Parse(dataRow["age"].ToString());
                patient.disease = dataRow["disease"].ToString();
                patients.Add(patient);
            }
            return patients;
        }

        public List<PatientSchema> fetchDataByAge()
        {
            Console.Write("Enter the Age of the patient: ");
            int val = int.Parse(Console.ReadLine());
            Console.WriteLine();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("EXEC SelectPatientByAge @age = '" + val + "'", con);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            List<PatientSchema> patients = new List<PatientSchema>();
            foreach (DataRow dataRow in dataTable.Rows)
                {
                    PatientSchema patient = new PatientSchema();
                    patient.id = int.Parse(dataRow["id"].ToString());
                    patient.name = dataRow["name"].ToString();
                    patient.age = int.Parse(dataRow["age"].ToString());
                    patient.disease = dataRow["disease"].ToString();
                    patients.Add(patient);
            }
            return patients;
        }

        public void fetchDataById()
        {
            Console.Write("Enter the Id of the patient: ");
            int val = int.Parse(Console.ReadLine());
            Console.WriteLine();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("EXEC SelectPatientById @id = '"+ val +"'", con);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            //int count = 0;
            //List<PatientSchema> patients = new List<PatientSchema>();
            if (dataTable.Rows.Count > 0)
            {
                Console.WriteLine("Present");
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    PatientSchema patient = new PatientSchema();
                    patient.id = int.Parse(dataRow["id"].ToString());
                    patient.name = dataRow["name"].ToString();
                    patient.age = int.Parse(dataRow["age"].ToString());
                    patient.disease = dataRow["disease"].ToString();
                    //patients.Add(patient);
                    Console.WriteLine($"{patient.id} | {patient.name} | {patient.age} | {patient.disease}");
                }
                
            }

            else Console.WriteLine("Not Present");
            
        }
        public List<PatientSchema> fetchDataByDisease()
        {
            Console.Write("Enter the Disease of the patient: ");
            string str = Console.ReadLine();
            Console.WriteLine();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("EXEC SelectPatientByDisease @disease = '"+ str +"'", con);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            List<PatientSchema> patients = new List<PatientSchema>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                PatientSchema patient = new PatientSchema();
                patient.id = int.Parse(dataRow["id"].ToString());
                patient.name = dataRow["name"].ToString();
                patient.age = int.Parse(dataRow["age"].ToString());
                patient.disease = dataRow["disease"].ToString();
                patients.Add(patient);
            }
            return patients;
        }

    }
}
