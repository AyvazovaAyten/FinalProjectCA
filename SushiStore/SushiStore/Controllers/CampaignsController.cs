using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using SushiStore.Models;
using SushiStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Controllers
{
    public class CampaignsController : BaseController
    {
        private readonly AppDbContext _context;
        public CampaignsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.IntroSliders.ToListAsync());
        }
        public async Task<IActionResult> Campaign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IntroSlider campaign = await _context.IntroSliders.FindAsync(id);

            if (campaign == null)
            {
                return NotFound();
            }

            CampaignVM campaignVM = new CampaignVM()
            {
                Campaign = campaign,
                OtherCampaigns = await _context.IntroSliders.Where(c=>c.Id != id).ToListAsync()
            };

            

            return View(campaignVM);
        }
    }
}
