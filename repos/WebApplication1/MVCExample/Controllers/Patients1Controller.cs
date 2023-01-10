using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExample.Controllers
{
    public class Patients1Controller : Controller
    {
        // GET: Patients1
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()); 
        public ActionResult Index()
        {
            List<Patient> plist = new List<Patient>();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Patient",con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Patient patient = new Patient();
                patient.Id = int.Parse(dr["Id"].ToString());
                patient.Name = dr["Name"].ToString();
                patient.Age = int.Parse(dr["Age"].ToString());
                plist.Add(patient);
            }
            
            return View(plist);
        }
        public ActionResult GetPatient(int? Id)
        {
            if(Id == 1)
            {
                ViewBag.Message = "Your id is "+ Id;
            }
            return View();
        }
       
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Patient p)
        {
           
            SqlCommand cmd = new SqlCommand("Insert into Patient Values('"+p.Name+"','"+p.Age+"')",con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(p);
            }
            finally
            {
                con.Close();
            }
        }
        public ActionResult UpdateData(int? id)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter("Select * from Patient where Id = '" + id + "'", con);
            DataTable dt  = new DataTable();
            sqlData.Fill(dt);
            //List<Patient> plist = new List<Patient>();  
            Patient p = new Patient();
            p.Name = dt.Rows[0]["Name"].ToString(); 
            p.Id = int.Parse(dt.Rows[0]["Id"].ToString());
            p.Age = int.Parse(dt.Rows[0]["Age"].ToString());
            return View(p);
        }
        [HttpPost]
        public ActionResult UpdateData(Patient p)
        {
            SqlCommand cmd = new SqlCommand("Update Patient set Name = '" + p.Name + "',Age = '" + p.Age + "' where Id = '"+p.Id+"'", con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }
        public ActionResult DeleteData(int? id)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter("Select * from Patient where Id = '" + id + "'", con);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            //List<Patient> plist = new List<Patient>();  
            Patient p = new Patient();
            p.Name = dt.Rows[0]["Name"].ToString();
            p.Id = int.Parse(dt.Rows[0]["Id"].ToString());
            p.Age = int.Parse(dt.Rows[0]["Age"].ToString());
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int? id)
        {
            SqlCommand cmd = new SqlCommand("Delete From Patient where id = '" + id + "' ", con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from Patient where Id = '" + id + "'", con);
                DataTable dt = new DataTable();
                sqlData.Fill(dt);
                //List<Patient> plist = new List<Patient>();  
                Patient p = new Patient();
                p.Name = dt.Rows[0]["Name"].ToString();
                p.Id = int.Parse(dt.Rows[0]["Id"].ToString());
                p.Age = int.Parse(dt.Rows[0]["Age"].ToString());
                return View(p);
            }
            finally
            {
                con.Close();
            }
        }
    }
}