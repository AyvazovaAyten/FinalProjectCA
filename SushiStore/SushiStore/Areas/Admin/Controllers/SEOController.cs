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
    public class SEOController : Controller
    {
        private readonly AppDbContext _context;

        public SEOController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Titles.Include(t=>t.Page).ToListAsync());
        }
       
        [HttpPost]
        public async Task<IActionResult> UpdateTitle(int? id,string titletext)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (titletext == null || titletext.Trim().Length<1)
            {
                TempData["Error"] = "Title cannot be null!";
                return RedirectToAction("Index");
            }

            Title dbtitle = await _context.Titles.FindAsync(id);

            if (dbtitle==null)
            {
                return NotFound();
            }
            dbtitle.Text = titletext;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MetaTags()
        {
            return View(await _context.Pages.Include(p=>p.MetaTags).ToListAsync());
        }
        public async Task<IActionResult> UpdateTag(int? id, string Tag)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(Tag == null)
            {
                TempData["Error"] = "Tag field must be filled.";
                return RedirectToAction("MetaTags");
            }
            MetaTag tag = await _context.MetaTags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            tag.Tag = Tag;

            await _context.SaveChangesAsync();

            return RedirectToAction("MetaTags");
        }
        public async Task<IActionResult> DeleteTag(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            MetaTag tag = await _context.MetaTags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.MetaTags.Remove(tag);
            await _context.SaveChangesAsync();

            return RedirectToAction("MetaTags");
        }
        public async Task<IActionResult> AddTag(string ModelTag, string page)
        {
            if(ModelTag==null || page == null)
            {
                TempData["TagError"] = "Tag and page fields must be filled.";
                return RedirectToAction("MetaTags");
            }
            Page dbpage = await _context.Pages.Where(p => p.Name.Trim().ToLower() == page.Trim().ToLower()).FirstOrDefaultAsync();

            if (dbpage == null)
            {
                TempData["TagError"] = "Page doesn't exist.";
                return RedirectToAction("MetaTags");
            }
            MetaTag newtag = new MetaTag()
            {
                PageId = dbpage.Id,
                Tag = ModelTag
            };
            await _context.MetaTags.AddAsync(newtag);
            await _context.SaveChangesAsync();

            return RedirectToAction("MetaTags");
        }
    }
}
