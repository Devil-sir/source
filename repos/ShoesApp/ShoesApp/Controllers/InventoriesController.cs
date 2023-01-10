using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoesApp.Models;

namespace ShoesApp.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly ShoesContext _context;

        public InventoriesController(ShoesContext context)
        {
            _context = context;
        }

        // GET: Inventories
        /*public JsonResult FilterProducts(int id)
        {
            var plist = _context.products.Where(e => e.categId == id).Select(e => new {
                id = e.id,
                name = e.name
            });
            return Json(plist);
        }*/
        public async Task<IActionResult> Index()
        {
            var shoesContext = _context.inventories.Include(i => i.categ).Include(i => i.product);
            return View(await shoesContext.ToListAsync());
        }

        // GET: Inventories/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.inventories == null)
            {
                return NotFound();
            }

            var inventory = await _context.inventories
                .Include(i => i.categ)
                .Include(i => i.product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }
*/
        // GET: Inventories/Create
        /*public IActionResult Create()
        {
            ViewData["categId"] = new SelectList(_context.categories, "id", "name");
            ViewData["productId"] = new SelectList(_context.products, "id", "name");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,qty,productId,categId")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categId"] = new SelectList(_context.categories, "id", "id", inventory.categId);
            ViewData["productId"] = new SelectList(_context.products, "id", "id", inventory.productId);
            return View(inventory);
        }
*/
        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.inventories == null)
            {
                return NotFound();
            }

            var inventory = await _context.inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            ViewData["categId"] = new SelectList(_context.categories, "id", "name", inventory.categId);
            ViewData["productId"] = new SelectList(_context.products, "id", "name", inventory.productId);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,qty,productId,categId")] Inventory inventory)
        {
            if (id != inventory.id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["categId"] = new SelectList(_context.categories, "id", "id", inventory.categId);
            //ViewData["productId"] = new SelectList(_context.products, "id", "id", inventory.productId);
            //return View(inventory);
        }

        // GET: Inventories/Delete/5
        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.inventories == null)
            {
                return NotFound();
            }

            var inventory = await _context.inventories
                .Include(i => i.categ)
                .Include(i => i.product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }*/

        // POST: Inventories/Delete/5
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.inventories == null)
            {
                return Problem("Entity set 'ShoesContext.inventories'  is null.");
            }
            var inventory = await _context.inventories.FindAsync(id);
            if (inventory != null)
            {
                _context.inventories.Remove(inventory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
*/
        private bool InventoryExists(int id)
        {
          return _context.inventories.Any(e => e.id == id);
        }
        /*public async Task<IActionResult> InventoryProduct(int id)
        {
            var products = _context.products.Where(e => e.categId == id);
            return View(await products.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SelectProduct(List<Product> pList)
        {
            try

            {
                foreach (Product p in pList)
                {
                    if (p.check)
                    {
                        Cart c = new Cart()
                        {
                            categId = p.categId,
                            productId = p.id,
                            qty = p.qty
                        };
                        _context.carts.Add(c);
                    }
                }
                await _context.SaveChangesAsync();
                //TempData["Message"] = "Successful";
                return RedirectToAction("Index", "Carts");
            }
            catch
            {
                return View(pList);
            }
        }*/
    }
}
