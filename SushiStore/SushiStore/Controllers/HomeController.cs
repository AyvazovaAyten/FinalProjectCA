using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using SushiStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Controllers
{
    public class HomeController : BaseController
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index() {

            HomeVM model = new HomeVM
            {
                Intros = await _context.Intros.FirstOrDefaultAsync(),
                Sliders = await _context.IntroSliders.ToListAsync(),
                AppParts = await _context.AppParts.FirstOrDefaultAsync(),
                Page = await _context.Pages.
                Include(p=>p.MetaTags).
                Include(p => p.PageIntro).
                Include(p => p.Title).Where(p => p.Name.Trim().ToLower() == "home").FirstOrDefaultAsync()
            };

            CartCount();

            return View(model);
        }

    }
}
