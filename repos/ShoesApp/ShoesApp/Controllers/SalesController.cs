using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShoesApp.Models;

namespace ShoesApp.Controllers
{
    public class SalesController : Controller
    {
        private readonly ShoesContext _context;
        const string checkTotalCost = "_Cost";

        public SalesController(ShoesContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
              return View(await _context.sale.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> SaleAmt()
        {
            //var sale =await _context.sale.ToArrayAsync();
            return View();
        }
        [HttpPost,ActionName("SaleAmt")]
        public async Task<IActionResult> SaleAmtMonth()
        {
            var sale = await _context.sale.ToArrayAsync();
            double amt = 0;
            if (sale != null)
            {
                string[] salesAmt = Request.Form["saleMonth"].ToString().Split('-');
                foreach (var s in sale)
                {
                    if (s.dateOfPurchase.Month == int.Parse(salesAmt[1]))
                    {
                        amt += s.totalAmt;
                    }
                }
            }
            HttpContext.Session.SetString(checkTotalCost, amt.ToString());

            return View();
        }

        // GET: Sales/Create
        /*public IActionResult Create()
        {
            return View();
        }
*/
        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> CustomerListInCurrentMonth()
        {
            List<Sale> slist = new List<Sale>();
            return View(slist);
        }

        [HttpPost,ActionName("CustomerListInCurrentMonth")]
        public async Task<IActionResult> CustomerListMonthly()
        {
            string[] salesAmt = Request.Form["saleMonth"].ToString().Split('-');
            var sale = await _context.sale.Where(e=>e.dateOfPurchase.Month == int.Parse(salesAmt[1])).ToListAsync();
            var item = sale.DistinctBy(e => e.userId);
            return View(item);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> CountOfSaleInCurrentMonth()
        {
            List<ProductsSold> pslist = new List<ProductsSold>();
            return View(pslist);
        }
        [HttpPost,ActionName("CountOfSaleInCurrentMonth")]
        public async Task<IActionResult> CountofSalesMonthly()
        {
            string[] salesAmt = Request.Form["saleMonth"].ToString().Split('-');
            var productSold = await _context.productsSold.Where(e=>e.sale.dateOfPurchase.Month == int.Parse(salesAmt[1])).GroupBy(e => e.productId).Select(x => new
            {
                x.Key,
                Sum = x.Sum(e => e.qty)
            }).ToListAsync();
            List<ProductsSold> pslist = new List<ProductsSold>();
            foreach(var product in productSold)
            {
                Product prod = await _context.products.FindAsync(product.Key);
                ProductsSold p = new ProductsSold()
                {
                    productId = product.Key,
                    product = prod,
                    qty = product.Sum
                };
                pslist.Add(p);
            }    
            return View(pslist);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,userId,totalAmt,dateOfPurchase")] Sale sale)
        {
            if (id != sale.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sale == null)
            {
                return NotFound();
            }

            var sale = await _context.sale
                .FirstOrDefaultAsync(m => m.id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sale == null)
            {
                return Problem("Entity set 'ShoesContext.sale'  is null.");
            }
            var sale = await _context.sale.FindAsync(id);
            if (sale != null)
            {
                _context.sale.Remove(sale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
*/
        private bool SaleExists(int id)
        {
          return _context.sale.Any(e => e.id == id);
        }
    }
}
