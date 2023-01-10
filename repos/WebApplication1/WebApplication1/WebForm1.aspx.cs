using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            //remiderdate if(datetime.now>=reminderdate) lblDis 
        }

        public void DdlBind()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Patient", con);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();
        }
        protected void btnPatient_Click(object sender, EventArgs e)
        {
            RegistrationView.Visible = true;
            RegistrationView.SetActiveView(View1);
        }

        protected void btnDoctor_Click(object sender, EventArgs e)
        {
            RegistrationView.Visible = true;
            RegistrationView.SetActiveView(View2);

        }

        protected void btnRegisterPatient_Click(object sender, EventArgs e)
        {

            RegistrationViewPatient.Visible = true;
            RegistrationViewPatient.SetActiveView(ViewRegisterPatient);
            //Label lRegisterMsg = new Label();
            PatientSchema patient = new PatientSchema();
            patient.Id = int.Parse(tbIdPatient.Text);
            patient.Name = tbNamePatient.Text;
            patient.Age = int.Parse(tbAgePatient.Text);
            SqlCommand sqlCommand = new SqlCommand("Insert into Patient(Id,[Name],Age) Values ('" + patient.Id + "','" + patient.Name + "','" + patient.Age + "')", con);
            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                lRegisterMsg.Text = "Successful Registered!!!!";
            }
            catch (Exception ex)
            {
                lRegisterMsg.Text = "Unsuccessful" + ex;
            }

            con.Close();
            if (IsPostBack)
            {
                DdlBind();
            }

        }

        protected void btnLoginPatient_Click(object sender, EventArgs e)
        {
            RegistrationViewPatient.Visible = true;
            RegistrationViewPatient.SetActiveView(ViewLoginPatient);
            lLoginMsg.Text = "";
            PatientSchema patient = new PatientSchema();
            //patient.Id = int.Parse(tbIdPatientLogin.Text);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Patient ", con);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    //PatientSchema patient = new PatientSchema();
                    patient.Id = int.Parse(dr["Id"].ToString());
                    patient.Name = dr["Name"].ToString();
                    patient.Age = int.Parse(dr["Age"].ToString());

                    lLoginMsg.Text += $"{patient.Id} | {patient.Name} | {patient.Age}" + "<br />";
                }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            PatientSchema patient = new PatientSchema();
            patient.Id = int.Parse(tbIdPatientLogin.Text);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Patient where Id = '" + patient.Id + "'", con);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //PatientSchema patient = new PatientSchema();
                    patient.Id = int.Parse(dr["Id"].ToString());
                    patient.Name = dr["Name"].ToString();
                    patient.Age = int.Parse(dr["Age"].ToString());

                    lLoginMsg.Text = $"{patient.Id} | {patient.Name} | {patient.Age}\n";
                }
            }
            else
            {
                lLoginMsg.Text = "Patient Not Present!!!";
            }


        }

        protected void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            RegistrationViewPatient.Visible = true;
            RegistrationViewPatient.SetActiveView(ViewUpdatePatient);
            PatientSchema patient = new PatientSchema();
            patient.Id = int.Parse(tbIdPatient.Text);
            patient.Name = tbNamePatient.Text;
            patient.Age = int.Parse(tbAgePatient.Text);
            SqlCommand sqlCommand = new SqlCommand("Update Patient Set Name='"+patient.Name+"',Age='"+patient.Age+"' where Id='"+patient.Id+"' ", con);
            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                lUpdatePatient.Text = "Successful Updated!!!!";
            }
            catch (Exception ex)
            {
                lUpdatePatient.Text = "Unsuccessful" + ex;
            }

            con.Close();
        }

        protected void btnDeletePatient_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Patient", con);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}