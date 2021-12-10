using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SushiStore.DAL;
using SushiStore.Models;
using SushiStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Controllers
{
    public class BaseController : Controller
    {
        public void CartCount()
        {

            if (Request.Cookies["cart"] == null)
            {
                ViewData["CartCount"] = 0;
                ViewData["TotalPrice"] = 0;
            }
            else
            {
                List<CartProduct> products = JsonConvert.DeserializeObject<List<CartProduct>>(Request.Cookies["cart"]);
                
                int TotalCount = products.Sum(p => p.Quantity);
                decimal TotalPrice = products.Sum(p => p.Quantity*p.CurrentPrice);


                ViewData["CartCount"] = TotalCount;

                ViewData["TotalPrice"] = TotalPrice;

                ViewBag.ProductList = products;

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CallRequest(string Name, string Phone, string time)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState.Values.SelectMany(x => x.Errors));
            }
            EmailService emailService = new EmailService();


            await emailService.SendEmailAsync("230420asdfx@gmail.com", 
                "Call Request", " Name:  "+ Name + "  " + " Phone:  " 
                + Phone+ "  "+ "Time Option:  " + time + " Time:  " 
                + DateTime.UtcNow.AddHours(4).ToShortTimeString());

            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

    }
}
