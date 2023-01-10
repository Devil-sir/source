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
    internal class EmpolyeeAddressDetails
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection1"].ToString());
        public List<EmployeeAddress> GetEmployeeAddresses()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from empAddress",con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<EmployeeAddress> empAddress = new List<EmployeeAddress>();
            foreach(DataRow dr in dt.Rows)
            {
                EmployeeAddress empAdd = new EmployeeAddress();
                empAdd.houseno = dr["houseno"].ToString();
                empAdd.street = dr["street"].ToString();
                empAdd.area = dr["area"].ToString();
                empAdd.city = dr["city"].ToString();
                empAdd.state = dr["state"].ToString();
                empAdd.pincode = dr["pincode"].ToString();
                empAddress.Add(empAdd);
            }
            return empAddress;
        }
    }
}
