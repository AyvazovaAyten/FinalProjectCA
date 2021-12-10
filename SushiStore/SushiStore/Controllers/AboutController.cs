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
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            AboutVM aboutVM = new AboutVM()
            {
                Page = await _context.Pages.Include(p=>p.PageIntro).
                Include(p => p.Title).Include(p => p.MetaTags).
                Where(p => p.Name.Trim().ToLower() == "about").FirstOrDefaultAsync(),
                About = await _context.Abouts.FirstOrDefaultAsync(),
            };

            return View(aboutVM);
        }
    }
}
