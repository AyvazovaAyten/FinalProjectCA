using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using SushiStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Abouts.FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Update()
        {
            return View(await _context.Abouts.FirstOrDefaultAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(About about )
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (about.AboutBody.Trim().Length < 50)
            {
                ModelState.AddModelError("", "About Body minimum 50 simvoldan ibarət olmalıdır.");
                return View(about);
            }
            About dbAbout = await _context.Abouts.FirstOrDefaultAsync();
            if (dbAbout == null)
            {
                return NotFound();
            }
            dbAbout.Title = about.Title;
            dbAbout.AboutBody = about.AboutBody;
            dbAbout.VideoLink = about.VideoLink;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
