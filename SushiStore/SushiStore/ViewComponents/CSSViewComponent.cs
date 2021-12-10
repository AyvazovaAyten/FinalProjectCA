using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using SushiStore.Models;
using System.Threading.Tasks;

namespace SushiStore.ViewComponents
{
    public class CSSViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public CSSViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            CSSCode code = await _context.CSSCodes.FirstOrDefaultAsync();
            return View(await Task.FromResult(code));
        }
    }
}
