using Microsoft.AspNetCore.Mvc;
using SushiStore.DAL;
using SushiStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.ViewComponents
{
    public class JSViewComponent: ViewComponent
    {
        private readonly AppDbContext _context;
        public JSViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            JSCode code = _context.JSCodes.FirstOrDefault();
            return View(await Task.FromResult(code));
        }
    }
}
