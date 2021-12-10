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
    public class EditPageController : Controller
    {
        private readonly AppDbContext _context;

        public EditPageController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddJS()
        {
            return View(await _context.JSCodes.FirstOrDefaultAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddJS(string code)
        {
            
            JSCode dbcode = await _context.JSCodes.FirstOrDefaultAsync();
            dbcode.Code = code;

            await _context.SaveChangesAsync();

            return RedirectToAction("AddJS");
        }
        public async Task<IActionResult> AddCSS()
        {
            return View(await _context.CSSCodes.FirstOrDefaultAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddCSS(string code)
        {
            CSSCode dbcode = await _context.CSSCodes.FirstOrDefaultAsync();
            dbcode.Code = code;

            await _context.SaveChangesAsync();

            return RedirectToAction("AddCSS");
        }
    }
}
