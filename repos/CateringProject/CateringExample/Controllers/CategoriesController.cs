using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CateringExample.Models;

namespace CateringExample.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CateringContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;


        public CategoriesController(CateringContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
              return View(await _context.Caterings.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Caterings == null)
            {
                return NotFound();
            }

            var category = await _context.Caterings
                .FirstOrDefaultAsync(m => m.id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //get file extension
            FileInfo fileInfo = new FileInfo(category.imgPath.FileName);
            //string fileName = category.imgPath.FileName + fileInfo.Extension;
            string fileNameWithPath = Path.Combine(path, category.imgPath.FileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                category.imgPath.CopyTo(stream);
            }
            Category c = new Category()
            {
                id = category.id,
                name = category.name,
                photoPath = "Images/" + category.imgPath.FileName
            };  
                _context.Add(c);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          
            //return View(category);
        }


       
        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Caterings == null)
            {
                return NotFound();
            }

            var category = await _context.Caterings.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,photoPath")] Category category)
        {
            if (id != category.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.id))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Caterings == null)
            {
                return NotFound();
            }

            var category = await _context.Caterings
                .FirstOrDefaultAsync(m => m.id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Caterings == null)
            {
                return Problem("Entity set 'CateringContext.Caterings'  is null.");
            }
            var category = await _context.Caterings.FindAsync(id);
            if (category != null)
            {
                _context.Caterings.Remove(category);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return _context.Caterings.Any(e => e.id == id);
        }
    }
}
