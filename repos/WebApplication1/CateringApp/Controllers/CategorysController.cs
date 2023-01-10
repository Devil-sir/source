using CateringApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CateringApp.Controllers
{
    public class CategorysController : Controller
    {
        // GET: Categorys
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CateringAppConnection"].ToString());
        public ActionResult Index()
        {
            List<Category> categoriesList = new List<Category>();
            SqlDataAdapter adapter = new SqlDataAdapter("EXEC displayData", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Category category = new Category()
                {
                    CategoryId = int.Parse(dr["CategoryId"].ToString()),
                    CategoryName = dr["CategoryName"].ToString(),
                    CategoryPhotoPath = dr["CategoryPhotoPath"].ToString()
                };
                categoriesList.Add(category);
            }

            return View(categoriesList);
        }
        public ActionResult InsertData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertData(Category category)
        {
            SqlCommand sqlCommand = new SqlCommand("EXEC insertData '"+ category.CategoryName +"', '"+ category.CategoryPhotoPath +"'", con);
            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(category);
            }
            finally
            {
                con.Close();
            }

        }
        public ActionResult UpdateData(int? id)
        {
            SqlCommand sqlCmd = new SqlCommand("updateData",con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@categoryId", id);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Category cat = new Category();
            cat.CategoryId = int.Parse(dt.Rows[0]["CategoryId"].ToString());
            cat.CategoryName = dt.Rows[0]["CategoryName"].ToString();
            cat.CategoryPhotoPath = dt.Rows[0]["CategoryPhotoPath"].ToString();
            return View(cat);
        }

        [HttpPost]
        public ActionResult UpdateData(Category cat)
        {
            SqlCommand sqlCommand = new SqlCommand("EXEC updateCat @categoryName='"+ cat.CategoryName +"',@categoryPhotoPath='"+ cat.CategoryPhotoPath +"',@categoryId='"+ cat.CategoryId +"'", con);
            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(cat);
            }
            finally
            {
                con.Close();
            }
        }
        public ActionResult Delete(int? id)
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC updateData '" + id + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Category cat = new Category();
            cat.CategoryId = int.Parse(dt.Rows[0]["CategoryId"].ToString());
            cat.CategoryName = dt.Rows[0]["CategoryName"].ToString();
            cat.CategoryPhotoPath = dt.Rows[0]["CategoryPhotoPath"].ToString();
            return View(cat);
        }

        [HttpPost]
        [ActionName ("Delete")]
        public ActionResult DeleteData(int? id)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from Category where CategoryId = '" + id + "'", con);
            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(id);
            }
            finally
            {
                con.Close();
            }
        }

    }
}