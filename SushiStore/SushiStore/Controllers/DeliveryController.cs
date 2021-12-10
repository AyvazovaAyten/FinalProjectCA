using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly AppDbContext _context;
        public DeliveryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deliveries.Include(d=>d.DeliveryAdresses).FirstOrDefaultAsync());
        }
    }
}
