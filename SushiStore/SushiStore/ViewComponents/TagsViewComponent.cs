using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using SushiStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.ViewComponents
{
    public class TagsViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public TagsViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<MetaTag> metatags = await _context.MetaTags.Include(m=>m.Page).Where(m=>m.Page.Name.Trim().ToLower()=="common").ToListAsync();
            return View(await Task.FromResult(metatags));
        }
    }
}
