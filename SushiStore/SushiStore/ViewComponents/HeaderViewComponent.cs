using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SushiStore.DAL;
using SushiStore.Models;
using SushiStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Bio bio = await _context.Bios.Include(b=>b.PhoneNumbers).FirstOrDefaultAsync();
            List<ProductVM> cart;

            if (Request.Cookies["cart"] == null)
            {
                cart = new List<ProductVM>();
            }
            else
            {
                cart = JsonConvert.DeserializeObject<List<ProductVM>>(Request.Cookies["cart"]);
            }
            bio.Products = cart;
            return View(await Task.FromResult(bio));
        }
    }
}
