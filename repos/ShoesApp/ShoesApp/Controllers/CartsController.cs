using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using ShoesApp.Models;


namespace ShoesApp.Controllers
{
    public class CartsController : Controller
    {
        private readonly ShoesContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        //private readonly CancellationToken _cancellationToken =default;

        public CartsController(ShoesContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            //_cancellationToken = cancellationToken;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            string user = _contextAccessor.HttpContext.User.Identity.Name;
            var carts = await _context.carts.Include(e=>e.product).Where(e=>e.userId == user).ToListAsync();
            double totalAmt = 0;
            if (carts != null)
            {
                foreach(var c in carts)
                {
                    totalAmt += (c.qty * c.product.price);
                }
            }

            ViewBag.TotalAmt = totalAmt;
            var shoesContext = _context.carts.Include(c => c.categ).Include(c => c.product).Where(e=>e.userId == user);
             
            return View(await shoesContext.ToListAsync());
        }

        /*public async JsonResult FilterProducts(int id)
        {
            List<Cart> plist = await _context.carts.Where(e=>e.userId == id).ToListAsync();
            float products = 0;
            foreach(Product p in plist)
            {
                products += p.price * p.qty;
            }
            
            return  Json(products);
           
        }*/
        // GET: Carts/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.carts == null)
            {
                return NotFound();
            }

            var cart = await _context.carts
                .Include(c => c.categ)
                .Include(c => c.product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["categId"] = new SelectList(_context.categories, "id", "id");
            ViewData["productId"] = new SelectList(_context.products, "id", "id");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,categId,productId,qty")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categId"] = new SelectList(_context.categories, "id", "id", cart.categId);
            ViewData["productId"] = new SelectList(_context.products, "id", "id", cart.productId);
            return View(cart);
        }*/

        // GET: Carts/Edit/5
        public async Task<IActionResult> Decrement(int? id)
        {
            if (id == null || _context.carts == null)
            {
                return NotFound();
            }

            var cart = await _context.carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            if(cart.qty > 1)
            {
                cart.qty -= 1;
                _context.Update(cart);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
           
           // ViewData["categId"] = new SelectList(_context.categories, "id", "id", cart.categId);
            //ViewData["productId"] = new SelectList(_context.products, "id", "id", cart.productId);
            return RedirectToAction("Index","Carts");
        }
        public async Task<IActionResult> Increment(int? id)
        {
            if (id == null || _context.carts == null)
            {
                return NotFound();
            }

            var cart = await _context.carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            var inventory =await _context.inventories.Where(e => e.productId == cart.productId).ToListAsync();
            if(inventory != null)
            {
                var i = inventory[0];
                if(i.qty > cart.qty)
                {
                    cart.qty += 1;
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
            }
            
            // ViewData["categId"] = new SelectList(_context.categories, "id", "id", cart.categId);
            //ViewData["productId"] = new SelectList(_context.products, "id", "id", cart.productId);
            return RedirectToAction("Index", "Carts");
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,categId,productId,qty")] Cart cart)
        {
            if (id != cart.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.id))
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
            ViewData["categId"] = new SelectList(_context.categories, "id", "id", cart.categId);
            ViewData["productId"] = new SelectList(_context.products, "id", "id", cart.productId);
            return View(cart);
        }*/

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.carts == null)
            {
                return NotFound();
            }

            var cart = await _context.carts
                .Include(c => c.categ)
                .Include(c => c.product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.carts == null)
            {
                return Problem("Entity set 'ShoesContext.carts'  is null.");
            }
            var cart = await _context.carts.FindAsync(id);
            if (cart != null)
            {
                _context.carts.Remove(cart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
          return _context.carts.Any(e => e.id == id);
        }

        public async Task<IActionResult> Checkout()
        {
            var cart = await _context.carts.Include(e=>e.product).Where(e=>e.userId == _contextAccessor.HttpContext.User.Identity.Name).ToListAsync();
            if (cart == null) { return NotFound(); }
                //return NotFound();
            double totalCost = 0;
            if (cart != null)
            {

                foreach (var c in cart)
                {
                    totalCost += (c.qty * c.product.price);
                    var inventory = await _context.inventories.Where(e=>e.productId == c.productId).ToListAsync();
                    foreach(var item in inventory)
                    {
                        item.qty -= c.qty;
                        _context.inventories.Update(item);
                        await _context.SaveChangesAsync();
                        if(item.qty < 5)
                        {
                            var message = new MimeMessage();
                            message.To.Add(new MailboxAddress("Test Admin", "cust6689@gmail.com"));
                            message.From.Add(new MailboxAddress("Test Project","testproject456789@gmail.com"));
                            message.Subject = "Please Reorder";
                            message.Body = new TextPart("plain")
                            {
                                Text = "Please Reorder the Product " +
                                "" + item.product.name
                            };
                            using(var client = new SmtpClient())
                            {
                                client.Connect("smtp.gmail.com", 587, false);
                                await client.AuthenticateAsync("testproject456789@gmail.com", "hjpvtclmpaylevzb").ConfigureAwait(false);
                                await client.SendAsync(message).ConfigureAwait(false);
                                client.Disconnect(true);
                            }
                        }
                    }
                }
                Sale s = new Sale()
                {
                    userId = _contextAccessor.HttpContext.User.Identity.Name,
                    totalAmt = totalCost,
                    dateOfPurchase = DateTime.Now
                };
                _context.sale.AddAsync(s);
                await _context.SaveChangesAsync();

                foreach (var item in cart)
                {
                    ProductsSold ps = new ProductsSold()
                    {
                        productId = item.productId,
                        saleId = s.id,
                        qty = item.qty
                    };
                    _context.productsSold.AddAsync(ps);
                }
                await _context.SaveChangesAsync();


                _context.carts.RemoveRange(cart);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("SelectCategory","Categories");

        }
        public async Task<IActionResult> EmptyCart()
        {
            List<Cart> cart = await _context.carts.Where(e=>e.userId == _contextAccessor.HttpContext.User.Identity.Name).ToListAsync();
            _context.carts.RemoveRange(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction("SelectCategory","Categories");
        }
    }
}
