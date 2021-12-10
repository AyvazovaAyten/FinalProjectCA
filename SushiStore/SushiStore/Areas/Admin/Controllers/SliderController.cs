using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using SushiStore.DAL;
using SushiStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using SushiStore.Services;

namespace WebAppDBConnection.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Admin")]
    public class SliderController:Controller
    {
        
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.IntroSliders.ToListAsync());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            IntroSlider slider = await _context.IntroSliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IntroSlider slider)
        { 
            if(slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Şəkil mütləq seçilməlidir.");
                return View(slider);
            }

            if (!slider.ImageFile.CheckFileType("image/"))
            {
                ModelState.AddModelError("ImageFile", "Yalniz sekil secile biler");
                return View(slider);
            }
            if (slider.ImageFile.CheckFileSize(600))
            {
                ModelState.AddModelError("ImageFile", "Faylin olcusu 600 KB-dan kicik olmalidir");
                return View(slider);
            }

            slider.Image = await slider.ImageFile.SaveFileAsync(_env.WebRootPath, Path.Combine("assets", "images", "campaigns"));
            
             
            await _context.IntroSliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            IntroSlider slider = await _context.IntroSliders.FindAsync(id);
            if (slider == null) return NotFound();
            
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int? id)
        {
            if (id == null) return NotFound();
            IntroSlider slider = await _context.IntroSliders.FindAsync(id);
            if (slider == null) return NotFound();
            if(slider.Image != null)
            {
                FileCheck.DeleteFile(slider.Image, _env.WebRootPath, Path.Combine("assets", "images", "campaigns"));
            }

            _context.IntroSliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            IntroSlider slider = await _context.IntroSliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, IntroSlider slider)
        {
            if (id == null) return NotFound();
            IntroSlider dbslider = await _context.IntroSliders.FindAsync(id);
            if (dbslider == null) return NotFound();

            if (slider.ImageFile != null)
            {
                if (!slider.ImageFile.CheckFileType("image/"))
                {
                    ModelState.AddModelError("ImageFile", "Yalniz sekil secile biler");
                    return View(slider);
                }
                if (slider.ImageFile.CheckFileSize(600))
                {
                    ModelState.AddModelError("imageFile", "Faylin olcusu 600 kb-dan az olmalidir.");
                    return View(slider);
                }
                //FileCheck.DeleteFile(slider.Image, _env.WebRootPath, Path.Combine("assets", "images", "campaigns"));

                string fileName = await slider.ImageFile.SaveFileAsync(_env.WebRootPath, Path.Combine("assets", "images", "campaigns"));
                dbslider.Image = fileName;
            }   

            
            dbslider.SliderText = slider.SliderText;
            dbslider.Description = slider.Description;
            dbslider.Duration = slider.Duration;
            dbslider.Details = slider.Details;
            

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
