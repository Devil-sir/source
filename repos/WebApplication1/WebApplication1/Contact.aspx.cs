using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WebApplication1.Models;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class Contact : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ToString());
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBinding();
            }
        }

        public void GridBinding()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Patient", con);
            sqlDataAdapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
   
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridBinding();
           
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //dt.Rows.RemoveAt(e.RowIndex);
            Label id = GridView1.Rows[e.RowIndex].FindControl("lblIdPatient") as Label;
            SqlCommand cmd = new SqlCommand("Delete from Patient where Id= '" + int.Parse(id.Text) + "'", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblShowMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
            GridBinding();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = GridView1.Rows[e.RowIndex].FindControl("lblIdPatient") as Label;
            TextBox name = GridView1.Rows[e.RowIndex].FindControl("tbNamePatient") as TextBox;
            TextBox age = GridView1.Rows[e.RowIndex].FindControl("tbAgePatient") as TextBox;
            //con = new SqlConnection(c);
            SqlCommand cmd = new SqlCommand("Update Patient set Name='" + name.Text + "',Age='" + age.Text + "' where ID='" + int.Parse(id.Text) +"'", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblShowMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
            GridView1.EditIndex = -1;
            GridBinding();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Insert")
            {
                //TextBox id = GridView1.FooterRow.FindControl("txtIdPatient") as TextBox;
                TextBox name = GridView1.FooterRow.FindControl("txtNamePatient") as TextBox;
                TextBox age = GridView1.FooterRow.FindControl("txtAgePatient") as TextBox;
                //con = new SqlConnection(c);
                SqlCommand cmd = new SqlCommand("Insert Into Patient Values ('" + name.Text + "','" + age.Text + "')", con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    lblShowMsg.Text = ex.Message;
                }
                finally
                {
                    con.Close();
                }
                
                GridBinding();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridBinding();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}