using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;

namespace EntityFrameWorkApproach.Controllers
{
    public class FoodProductsController : Controller
    {
        private CateringAppContext db = new CateringAppContext();

        // GET: FoodProducts
        public ActionResult Index()
        {
            var foodProducts = db.foodProducts.Include(f => f.categ);
            return View(foodProducts.ToList());
        }

        // GET: FoodProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodProduct foodProduct = db.foodProducts.Find(id);
            if (foodProduct == null)
            {
                return HttpNotFound();
            }
            return View(foodProduct);
        }

        // GET: FoodProducts/Create
        public ActionResult Create()
        {
            ViewBag.FPCategoryId = new SelectList(db.categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: FoodProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodProductId,FoodProductName,FPCategoryId,FoodProductDescription,FoodProductPrice")] FoodProduct foodProduct, HttpPostedFileBase[] photoPath)
        {
            var path ="";
            var files = "";
            foreach (var file in photoPath)
            {
                var filename = Path.GetFileName(file.FileName);
                files = "~/Images/" + filename;
                path = Path.Combine(Server.MapPath(files));
                file.SaveAs(path);   
                
            }
            if (ModelState.IsValid)
            {
                foodProduct.FoodProductPhotoPath = files;
                db.foodProducts.Add(foodProduct);
        
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FPCategoryId = new SelectList(db.categories, "CategoryId", "CategoryName", foodProduct.FPCategoryId);
            return View(foodProduct);
        }

        // GET: FoodProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodProduct foodProduct = db.foodProducts.Find(id);
            if (foodProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.FPCategoryId = new SelectList(db.categories, "CategoryId", "CategoryName", foodProduct.FPCategoryId);
            return View(foodProduct);
        }

        // POST: FoodProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodProductId,FoodProductName,FPCategoryId,FoodProductDescription,FoodProductPrice,FoodProductPhotoPath")] FoodProduct foodProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FPCategoryId = new SelectList(db.categories, "CategoryId", "CategoryName", foodProduct.FPCategoryId);
            return View(foodProduct);
        }

        // GET: FoodProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodProduct foodProduct = db.foodProducts.Find(id);
            if (foodProduct == null)
            {
                return HttpNotFound();
            }
            return View(foodProduct);
        }

        // POST: FoodProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodProduct foodProduct = db.foodProducts.Find(id);
            db.foodProducts.Remove(foodProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult SelectedProduct(int id)
        {
            var products = db.foodProducts.Where(e => e.FPCategoryId == id);
            return View(products.ToList());
        }

        [HttpPost]
        public ActionResult SelectedProduct(List<FoodProduct> fpList)
        {
            try
            {
                foreach (FoodProduct fp in fpList)
                {
                    if (fp.check)
                    {
                        Purchase p1 = new Purchase();
                        p1.Name = fp.FoodProductName;
                        //p1.Qty = int.Parse(fc.AllKeys[3]);
                        //fp.Qty = int.Parse(Request.Form["qty"].ToString());
                        p1.Qty = fp.Qty;
                        p1.Price = fp.FoodProductPrice;
                        p1.FoodProductId = fp.FoodProductId;
                        db.purchases.Add(p1);
                    }
                }
                db.SaveChanges();
                //TempData["Message"] = "Successful";
                return RedirectToAction("Index","Purchases");
            }
            catch
            {
                return View(fpList);
            }
        }

    }
}
