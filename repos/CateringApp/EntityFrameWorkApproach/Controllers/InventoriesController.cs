using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;

namespace EntityFrameWorkApproach.Controllers
{
    [Authorize(Roles ="admin")]
    public class InventoriesController : Controller
    {
        private CateringAppContext db = new CateringAppContext();

        // GET: Inventories
        public ActionResult Index()
        {
            var inventories = db.inventories.Include(i => i.categ).Include(i => i.fp);
            return View(inventories.ToList());
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public JsonResult FilterProducts(int id)
        {
            /*List<FoodProduct> fplist = db.foodProducts.Where(e => e.FPCategoryId == id).ToList();
            string products = string.Empty;
            foreach(FoodProduct fp in fplist)
            {
                products += fp.FoodProductName + ",";
            }
            products = products.TrimEnd(',');
            return  Json(products,JsonRequestBehavior.AllowGet);
             */
            var plist = db.foodProducts.Where(e => e.FPCategoryId == id).Select(e => new {
                id = e.FoodProductId,
                name = e.FoodProductName
            });
            return Json(plist,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            ViewBag.categId = new SelectList(db.categories, "CategoryId", "CategoryName");
            ViewBag.pId = new SelectList(db.foodProducts, "FoodProductId", "FoodProductName");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryId,pId,categId,qty")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categId = new SelectList(db.categories, "CategoryId", "CategoryName", inventory.categId);
            ViewBag.pId = new SelectList(db.foodProducts, "FoodProductId", "FoodProductName", inventory.pId);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.categId = new SelectList(db.categories, "CategoryId", "CategoryName", inventory.categId);
            ViewBag.pId = new SelectList(db.foodProducts, "FoodProductId", "FoodProductName", inventory.pId);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryId,pId,categId,qty")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categId = new SelectList(db.categories, "CategoryId", "CategoryName", inventory.categId);
            ViewBag.pId = new SelectList(db.foodProducts, "FoodProductId", "FoodProductName", inventory.pId);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.inventories.Find(id);
            db.inventories.Remove(inventory);
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
    }
}
