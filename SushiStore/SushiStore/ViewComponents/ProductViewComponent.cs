using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using SushiStore.Models;
using SushiStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            HomeVM homeVM = new HomeVM
            {
                Products = await _context.Products.Include(p => p.Prices).Include(p => p.Ratings).Where(p => !p.IsDeleted && p.CategoryId == 5).Take(12).ToListAsync(),
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync()
            };


            return View(await Task.FromResult(homeVM));
        }
    }
}
