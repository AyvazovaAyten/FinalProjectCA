using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;

namespace P409PractiseAllup.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["OrderCount"] =  _context.Orders.Count();
            ViewData["UserCount"] = _context.Users.Count();
            ViewData["OrderValue"] = _context.Orders.Where(o=>o.Date> DateTime.Now.AddMonths(-1)).Sum(o => o.TotalAmount);

            return View(await _context.Orders.Where(o=>o.Date >DateTime.Now.AddDays(-1)).ToListAsync());
        }
    }
}
