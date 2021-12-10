using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using SushiStore.Models;
using SushiStore.ViewModels;

namespace SushiStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.Where(c=>c.IsDeleted == false).Include(c => c.Products).ToListAsync());
        }



        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !(c.IsDeleted));

            if (category == null) return NotFound();

            CategoryVM categoryVM = new CategoryVM()
            {
                Category = category,
                Products = await _context.Products.Where(p => p.CategoryId == id && !p.IsDeleted).ToListAsync()
            
            };

            return View(categoryVM);
        }



        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => !c.IsDeleted && c.Id == id);

            if(category==null) return NotFound();

            return View(category);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id, Category category)
        {

            if (id == null) return NotFound();

            Category dbcategory = await _context.Categories.FirstOrDefaultAsync(c => !c.IsDeleted && c.Id == id);

            if (dbcategory == null) return NotFound();


            if (!ModelState.IsValid)
            {
                return View();
            }


            if (await _context.Categories.AnyAsync(c => c.Name.ToLower() == category.Name.ToLower() && c.Id != id))
            {
                ModelState.AddModelError("Name", "Bu ad artiq movcuddur");
                return View();
            }

            dbcategory.Name = category.Name;
            dbcategory.LastUpdateDate = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !(c.IsDeleted));

            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !(c.IsDeleted));
            
            if (category == null) return NotFound();

            category.IsDeleted = true;

            List<Product> products = await _context.Products.Where(p => p.CategoryId == id && !p.IsDeleted).ToListAsync();

            foreach(Product product in products)
            {
                product.IsDeleted = true;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            if (await _context.Categories.AnyAsync(c=>c.IsDeleted == false && c.Name.ToLower() == category.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Bu adda kateqoriya artiq movcuddur");
                return View(category);
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
