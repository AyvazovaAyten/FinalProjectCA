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
    public class FooterViewComponent: ViewComponent
    {
        private readonly AppDbContext _context;
        public FooterViewComponent(AppDbContext Context)
        {
            _context = Context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Bio bio = await _context.Bios.Include(b => b.PhoneNumbers).FirstOrDefaultAsync();
            return View(await Task.FromResult(bio));
        }
    }
}
