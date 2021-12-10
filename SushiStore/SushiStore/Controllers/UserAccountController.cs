using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiStore.DAL;
using SushiStore.DTO.User;
using SushiStore.Models;
using SushiStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Controllers
{
    [Authorize]
    public class UserAccountController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signInManager;


        public UserAccountController(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _usermanager = userManager;
            _signInManager = signInManager;

        }
        public async Task<IActionResult> Index()
        {
            User user = await _usermanager.GetUserAsync(HttpContext.User);
            string id = user.Id;
            CartCount();
            return View(await _context.Users.Include(u => u.Ratings).
                ThenInclude(r => r.Product).Include(user => user.Orders).
                ThenInclude(o => o.OrderProducts).ThenInclude(op => op.Product).
                ThenInclude(p => p.Ratings).FirstOrDefaultAsync(u => u.Id == id));
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Change(string id, UserForChange userDto)
        {
            if (id == null)
            {
                return NotFound();
            }
            User user = await _usermanager.GetUserAsync(HttpContext.User);
            if(id != user.Id)
            {
                return NotFound();
            }
            user.FirstName = userDto.FirstName;
            user.SurName = userDto.SurName;
            user.Adress = userDto.Adress;
            user.AdressLine = userDto.AdressLine;

            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = await _usermanager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return NotFound();
            }
           
           IdentityResult identityResult =  await _usermanager.ChangePasswordAsync(user, model.Password, model.NewPassword);
            if (!identityResult.Succeeded)
            {
                ModelState.AddModelError("Password", "Password is incorrect!");
                return View();
            }
            

            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Rating(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            User user = await _usermanager.GetUserAsync(HttpContext.User);
            Rating rated = await _context.Ratings.Where(r => r.ProductId == id && r.UserId == user.Id).FirstOrDefaultAsync();
            if (rated != null)
            {
                return PartialView("_RatingPartial", rated);
            }

            return PartialView("_RatingPartial", new Rating() {Product=product,ProductId=product.Id });
        }


        public  async Task<string> RateProduct(int? value, int? id)
        {
            if(id==null || value==null || (value < 1 && value > 5))
            {
                return "Not Found!";
            }

           
            Product product = await _context.Products.FirstOrDefaultAsync(p=>p.Id==id);

            User user = await _usermanager.GetUserAsync(HttpContext.User);

            Rating rating = new Rating
            {
                Value=(int)value,
                UserId = user.Id,
                ProductId = product.Id
            };

            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();

            return "Ok";
        }
    }
}
