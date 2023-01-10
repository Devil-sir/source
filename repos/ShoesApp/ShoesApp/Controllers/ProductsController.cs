using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoesApp.Models;

namespace ShoesApp.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ShoesContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProductsController(ShoesContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        // GET: Products
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var shoesContext = _context.products.Include(p => p.categ);
            return View(await shoesContext.ToListAsync());
        }

        // GET: Products/Details/5
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.categ)
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "admin")]

        public IActionResult Create()
        {
            ViewData["categId"] = new SelectList(_context.categories, "id", "name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Create(Product product)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //get file extension
            FileInfo fileInfo = new FileInfo(product.formFile.FileName);
            //string fileName = category.imgPath.FileName + fileInfo.Extension;
            string fileNameWithPath = Path.Combine(path, product.formFile.FileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                product.formFile.CopyTo(stream);
            }
            Product p = new Product()
            {
                id = product.id,
                name = product.name,
                description = product.description,
                price = product.price,
                categId = product.categId,
                imgPath = "Images/" + product.formFile.FileName
            };
            //if (ModelState.IsValid)
            //{
            _context.Add(p);
            await _context.SaveChangesAsync();

            Inventory inventory = new Inventory()
            {
                categId = p.categId,
                productId = p.id,
                qty = 10
            };
        
            _context.inventories.Add(inventory);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        //}
        //ViewData["categId"] = new SelectList(_context.categories, "id", "name", product.categId);
        //return View(product);}
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["categId"] = new SelectList(_context.categories, "id", "name", product.categId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.id)
            {
                return NotFound();
            }

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //get file extension
            FileInfo fileInfo = new FileInfo(product.formFile.FileName);
            //string fileName = category.imgPath.FileName + fileInfo.Extension;
            string fileNameWithPath = Path.Combine(path, product.formFile.FileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                product.formFile.CopyTo(stream);
            }
            Product p = new Product()
            {
                id = product.id,
                name = product.name,
                description = product.description,
                price = product.price,
                categId = product.categId,
                imgPath = "Images/" + product.formFile.FileName
            };

            //if (ModelState.IsValid)
            //{
            try
                {
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.id))
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
            ViewData["categId"] = new SelectList(_context.categories, "id", "id", product.categId);
           // return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.categ)
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.products == null)
            {
                return Problem("Entity set 'ShoesContext.products'  is null.");
            }
            var product = await _context.products.FindAsync(id);
            if (product != null)
            {
                _context.products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return _context.products.Any(e => e.id == id);
        }
        
        public async Task<IActionResult> SelectProduct(int id)
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
                        Cart c = new Cart() {
                            categId = p.categId,
                            productId = p.id,
                            qty = p.qty,
                            userId = _contextAccessor.HttpContext.User.Identity.Name
                        };
                        _context.carts.Add(c);
                    }
                }
                await _context.SaveChangesAsync();
                //TempData["Message"] = "Successful";
                return RedirectToAction("Index","Carts");
            }
            catch
            {
                return View(pList);
            }
        }
    }
}
