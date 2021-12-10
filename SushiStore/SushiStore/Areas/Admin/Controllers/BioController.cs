using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using SushiStore.DTO;
using SushiStore.Models;
using SushiStore.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SushiStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BioController : Controller
    {
        private readonly AppDbContext _context;
        public IWebHostEnvironment _env;
        public BioController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Update()
        {
            return View(await _context.Bios.FirstOrDefaultAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Bio newBio)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Bio bio = await _context.Bios.FirstOrDefaultAsync();

            if(bio == null)
            {
                return NotFound();
            }

            if (newBio.LogoFile != null)
            {
                if (newBio.LogoFile.CheckFileSize(300))
                {
                    ModelState.AddModelError("Images", "Faylin olcusu maksimum 300kb ola biler");
                    return View(newBio);
                }

                if (!newBio.LogoFile.CheckFileType("image"))
                {
                    ModelState.AddModelError("Images", "Fayl yalniz sekil ola biler");
                    return View(newBio);
                }


               bio.Logo = await newBio.LogoFile.SaveFileAsync(_env.WebRootPath, Path.Combine("assets", "images"));

                FileCheck.DeleteFile(bio.Logo, _env.WebRootPath, Path.Combine("assets", "images"));
            }

            bio.Adress = newBio.Adress;
            bio.FbLink = newBio.FbLink;
            bio.InstagramLink = newBio.InstagramLink;
            bio.WhatsappLink = newBio.WhatsappLink;
            bio.YoutubeLink = newBio.YoutubeLink;
            bio.WorkingHours = newBio.WorkingHours;



            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Update));
        }
        public async Task<IActionResult> Contacts()
        {
            return View(await _context.PhoneNumbers.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePhoneNumber(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PhoneNumber dbNumber = await _context.PhoneNumbers.FindAsync(id);

            if(dbNumber == null)
            {
                return NotFound();
            }
             _context.PhoneNumbers.Remove(dbNumber);
            await _context.SaveChangesAsync();
            return RedirectToAction("Contacts");
        }

        public async Task<IActionResult> CreatePhonenumber(string number)
        {
            if(Regex.Matches(number, @"[a-zA-Z]").Count()>0 || number==null)
            {
                TempData["Error"] = "Düzgün mobil nömrə daxil edin!";
                return RedirectToAction("Contacts");
            }
            Bio bio = await _context.Bios.FirstOrDefaultAsync();
            PhoneNumber newNumber = new PhoneNumber()
            {
                Number = number,
                BioId=bio.Id
            };
            await _context.PhoneNumbers.AddAsync(newNumber);

            await _context.SaveChangesAsync();
            return RedirectToAction("Contacts");
        }
        public async Task<IActionResult> Footer()
        {
            return View(await _context.Bios.FirstOrDefaultAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Footer(FooterDto footerDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Bio bio = await _context.Bios.FirstOrDefaultAsync();
            if (bio == null)
            {
                return NotFound();
            }
            bio.FooterText = footerDto.FooterText;
            bio.CallText = footerDto.FooterText;
            bio.CopyRight = footerDto.CopyRight;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Update));
        }
    }
}
