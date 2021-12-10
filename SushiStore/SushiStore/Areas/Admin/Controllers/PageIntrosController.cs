using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using SushiStore.Models;
using SushiStore.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PageIntrosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public PageIntrosController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pages.ToListAsync());
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PageIntro intro = await _context.PageIntros.Where(p => p.PageId == id).FirstOrDefaultAsync();
            if (intro == null)
            {
                return NotFound();
            }
            return View(intro);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(int? id, PageIntro model, IFormFile img)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            PageIntro intro = await _context.PageIntros.Where(p => p.PageId == id).FirstOrDefaultAsync();
            if (intro == null)
            {
                return NotFound();
            }
            if(img != null)
            {
                if (!img.CheckFileType("image/"))
                {
                    ModelState.AddModelError("ImageFile", "Yalniz sekil secile biler");
                    return View(model);
                }

                if (img.CheckFileSize(5000))
                {
                    ModelState.AddModelError("ImageFile", "Maksimum olcu 5MB ola biler.");
                    return View(model);
                }
                FileCheck.DeleteFile(model.Background, _env.WebRootPath, Path.Combine("assets", "images", "covers"));
            }           

            model.Background = await intro.BackgroundImage.SaveFileAsync(_env.WebRootPath, Path.Combine("assets", "images", "covers"));

            return View(intro);
        }
    }
}
