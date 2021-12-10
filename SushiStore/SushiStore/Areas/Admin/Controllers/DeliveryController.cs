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
    public class DeliveryController : Controller
    {
        private readonly AppDbContext _context;
        public DeliveryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Update()
        {
            return View(await _context.Deliveries.Include(d => d.DeliveryAdresses).FirstOrDefaultAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            Delivery dbdelivery = await _context.Deliveries.FirstOrDefaultAsync();
            if (dbdelivery == null)
            {
                return NotFound();
            }
            dbdelivery.Info = delivery.Info;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Update));
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDeliveryAdress(DeliveryAdress adress)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Check input fields!";
                return RedirectToAction("Update");
            }
            adress.DeliveryId = _context.Deliveries.FirstOrDefault().Id;

            await _context.DeliveryAdresses.AddAsync(adress);
            await _context.SaveChangesAsync();

            return RedirectToAction("Update");
        }


        public async Task<IActionResult> UpdateDeliveryAdress(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DeliveryAdress adress = await _context.DeliveryAdresses.FindAsync(id);

            if (adress == null)
            {
                return NotFound();
            }
            return View(adress);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDeliveryAdress(int? id, DeliveryAdress adress)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            DeliveryAdress dbadress = await _context.DeliveryAdresses.FindAsync(id);

            if (dbadress == null)
            {
                return NotFound();
            }

            dbadress.Name = adress.Name;
            dbadress.Time = adress.Time;
            dbadress.MinAmount = adress.MinAmount;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Update));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDeliveryAdress(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DeliveryAdress adress = await _context.DeliveryAdresses.FindAsync(id);

            if (adress == null)
            {
                return NotFound();
            }
            _context.DeliveryAdresses.Remove(adress);
            await _context.SaveChangesAsync();
            return RedirectToAction("Update");
        }


    }
}
