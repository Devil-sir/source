using CateringApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CateringApp.Controllers
{
    public class FoodProductsController : Controller
    {
        // GET: FoodProducts
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CateringAppConnection"].ToString());
        public ActionResult Index()
        {
            List<FoodProduct> products = new List<FoodProduct>();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from FoodProduct",con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                FoodProduct foodProduct = new FoodProduct()
                {
                    FoodProductId = int.Parse(dr["FoodProductId"].ToString()),
                    FPCategoryId = int.Parse(dr["FoodProductId"].ToString()),
                    FoodProductName = dr["FoodProductName"].ToString(),
                    FoodProductDescription = dr["FoodProductDescription"].ToString(),
                    FoodProductPhotoPath = dr["FoodProductPhotoPath"].ToString(),
                    FoodProductPrice = float.Parse(dr["FoodProductPrice"].ToString())
                };
                products.Add(foodProduct);
            }
            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FoodProduct prod)
        {
            SqlCommand sqlCommand = new SqlCommand("Insert into FoodProduct Values ('" + prod.FoodProductName + "','" + prod.FPCategoryId + "','" + prod.FoodProductDescription + "','" + prod.FoodProductPrice + "','" + prod.FoodProductPhotoPath + "') ", con);
            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(prod);
            }
            finally
            {
                con.Close();
            }

        }
        public ActionResult UpdateData(int? id)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from FoodProduct where FoodProductId = '" + id + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FoodProduct prod = new FoodProduct();
            prod.FoodProductId = int.Parse(dt.Rows[0]["FoodProductId"].ToString());
            prod.FoodProductName = dt.Rows[0]["FoodProductName"].ToString();
            prod.FPCategoryId = int.Parse(dt.Rows[0]["FPCategoryId"].ToString());
            prod.FoodProductDescription = dt.Rows[0]["FoodProductDescription"].ToString();
            prod.FoodProductPrice = float.Parse(dt.Rows[0]["FoodProductPrice"].ToString());
            prod.FoodProductPhotoPath = dt.Rows[0]["FoodProductPhotoPath"].ToString();
            return View(prod);
        }

        [HttpPost]
        public ActionResult UpdateData(FoodProduct prod)
        {
            SqlCommand sqlCommand = new SqlCommand("Update FoodProduct Set FoodProductName='" + prod.FoodProductName + "',FPCategoryId='" + prod.FPCategoryId + "',FoodProductDescription='" + prod.FoodProductDescription + "',FoodProductPrice='" + prod.FoodProductPrice + "',FoodProductPhotoPath= '"+ prod.FoodProductPhotoPath +"' where FoodProductId='" + prod.FoodProductId + "' ", con);
            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(prod);
            }
            finally
            {
                con.Close();
            }
        }
        public ActionResult Delete(int? id)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from FoodProduct where FoodProductId = '" + id + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FoodProduct prod = new FoodProduct();
            prod.FoodProductId = int.Parse(dt.Rows[0]["FoodProductId"].ToString());
            prod.FoodProductName = dt.Rows[0]["FoodProductName"].ToString();
            prod.FPCategoryId = int.Parse(dt.Rows[0]["FPCategoryId"].ToString());
            prod.FoodProductDescription = dt.Rows[0]["FoodProductDescription"].ToString();
            prod.FoodProductPrice = float.Parse(dt.Rows[0]["FoodProductPrice"].ToString());
            prod.FoodProductPhotoPath = dt.Rows[0]["FoodProductPhotoPath"].ToString();
            return View(prod);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteData(int? id)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from FoodProduct where FoodProductId = '" + id + "'", con);
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