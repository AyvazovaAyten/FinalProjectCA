using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using SushiStore.Models;
using SushiStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;
        public MenuController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            Page menupage = await _context.Pages.
                Include(p=>p.Title).
                Include(p => p.MetaTags).Where(p => p.Name.Trim().ToLower() == "menu").FirstOrDefaultAsync();

            return View(menupage);
        }

        public async Task<IActionResult> GetProducts(int? CategoryId)
        {
            if (CategoryId == null)
            {
                return NotFound();
            }

            Category category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == CategoryId);

            if (category == null)
            {
                return NotFound();
            }


            TempData["ProductsCount"] = category.Products.Where(p=>!p.IsDeleted).Count();

            return PartialView("_ProductsPartial", await _context.Products.Where(p => !p.IsDeleted && p.CategoryId == CategoryId)
               .Include(p => p.Category).
               Include(p => p.Prices).
               Include(p=>p.Ratings).
               Take(12).
               ToListAsync());

        }


        public async Task<IActionResult> Load(int skipCount, int CategoryId)
        {

            Category category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == CategoryId);

            if (category == null)
            {
                return NotFound();
            }
            TempData["ProductsCount"] = category.Products.Count();

            return PartialView("_ProductsPartial", await _context.Products.Where(p => !p.IsDeleted && p.CategoryId == CategoryId)
                .Include(p => p.Category).
                Include(p=>p.Prices).
                Include(p => p.Ratings).
                Skip(skipCount).
                Take(12).
                ToListAsync());

        }



        public async Task<IActionResult> Product(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = await _context.Products.FindAsync(id);
            if (product == null || product.IsDeleted)
            {
                return NotFound();
            }
          
            return View(await _context.Products.Where(p =>p.Id == id)
                .Include(p => p.Nutrition)
                .Include(p => p.Prices)
                .Include(p=>p.Ratings)
                .Include(p => p.Category)
                .ThenInclude(c => c.Products)
                .ThenInclude(p=>p.Prices).FirstOrDefaultAsync());
        }
    }
}
