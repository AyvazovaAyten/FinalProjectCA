using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SushiStore.DAL;
using SushiStore.Helpers;
using SushiStore.Models;
using SushiStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiStore.Controllers
{
    public class CartController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _usermanager;
        public CartController(AppDbContext context,UserManager<User> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }
        public List<CartProduct> GetCart()
        {
            List<CartProduct> products;


            if (Request.Cookies["cart"] == null)
            {
                products = new List<CartProduct>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<CartProduct>>(Request.Cookies["cart"]);
            }
            return products;
        }

        public decimal GetTotalAmount(List<CartProduct> products)
        {
            decimal Total = 0;

            Total = (decimal)(from cartItem in products
                              select cartItem.Quantity *
                              cartItem.CurrentPrice).Sum();
            return Total;
        }
        
        
        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product dbproduct = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
 

            if (dbproduct == null)
            {
                return NotFound();  
            }

            ProductPrice price = await _context.ProductPrices.Where(p => p.ProductId == id).FirstOrDefaultAsync();

            List<CartProduct> products;


            if (Request.Cookies["cart"] == null)
            {
                products = new List<CartProduct>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<CartProduct>>(Request.Cookies["cart"]);
            }

            CartProduct productInCart = products.Find(p => p.ProductId == id);
    

            if (productInCart != null)
            {
                productInCart.Quantity++;
            }
            else
            {
                CartProduct cartItem = new CartProduct
                {
                    ProductId = dbproduct.Id,
                    CurrentPrice=price.CurrentPrice,
                    OldPrice=price.OldPrice,
                    Name=dbproduct.Name,
                    Image=dbproduct.Image,
                    Quantity = 1
                };

                if (User.Identity.IsAuthenticated)
                {
                    User currentUser = await _usermanager.GetUserAsync(HttpContext.User);
                    cartItem.UserId = currentUser.Id;
                }              
                products.Add(cartItem);

            }

            Response.Cookies.Append("cart", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(3) });

           return RedirectToAction("Index", "Home");           

        }


        public IActionResult RemoveFromCart(int? id)
        {
            if (id == null) return NotFound();

            if (Request.Cookies["cart"] == null)
            {
                return Content("Error");
            }

            List<CartProduct> products = JsonConvert.DeserializeObject<List<CartProduct>>(Request.Cookies["cart"]);

            CartProduct cartItem = products.Find(p => p.ProductId == id);

            if (cartItem == null) return NotFound();

           
                products.Remove(cartItem);
            

            Response.Cookies.Append("cart", JsonConvert.SerializeObject(products));


            return RedirectToAction("Index", "Home");

        }
      
        
        public IActionResult IncreaseCount(int? id)
        {
            if (id == null) return NotFound();

            if (Request.Cookies["cart"] == null)
            {
                return NotFound();
            }

            List<CartProduct> products = JsonConvert.DeserializeObject<List<CartProduct>>(Request.Cookies["cart"]);

            CartProduct prToIncrease = products.Find(p => p.ProductId == id);

            if (prToIncrease == null) return NotFound();

            products[products.IndexOf(prToIncrease)].Quantity++;

            string cookies = JsonConvert.SerializeObject(products);
   

            Response.Cookies.Append("cart", cookies);

            return RedirectToAction("Index");
        }

        public IActionResult DecreaseCount(int? id)
        {
            if (id == null) return NotFound();

            if (Request.Cookies["cart"] == null)
            {
                return NotFound();
            }

            List<CartProduct> products = JsonConvert.DeserializeObject<List<CartProduct>>(Request.Cookies["cart"]);

            CartProduct cartItem = products.Find(p => p.ProductId == id);

            if (cartItem == null) return NotFound();

            products[products.IndexOf(cartItem)].Quantity--;


            Response.Cookies.Append("cart", JsonConvert.SerializeObject(products));

            return RedirectToAction("Index");
        }
       
        
        public IActionResult Index()
        {

            if (Request.Cookies["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<CartProduct> cart = GetCart();

            CartCount();

            return View(cart);
        }
       
        
        
        public IActionResult CartSummary()
        {
            CartCount();
            return PartialView("_CartSummaryPartial", GetCart());
        }

        
        public async Task<IActionResult> CheckOut()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            User currentUser = await _usermanager.GetUserAsync(HttpContext.User);

            ShippingDetail shippingDetail = new ShippingDetail()
            {
                Name = currentUser.UserName,
                SurName = currentUser.SurName,
                AdressLine = (currentUser.Adress!=null)? $"{currentUser.Adress.Trim()}" : ""
            };
            return View(shippingDetail);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(ShippingDetail shippingDetails)
        {
            OrderProcessor orderProcessor = new OrderProcessor();
            EmailService emailService = new EmailService();

            List<CartProduct> cart = GetCart();
            if (cart.Count() == 0)
            {
                ModelState.AddModelError("", "The cart is empty!");
            }

            if (!ModelState.IsValid)
            {
                return View(shippingDetails);
            }

            StringBuilder messageBody =orderProcessor.ProcessOrder(cart, shippingDetails);

            
            User currentUser = await _usermanager.GetUserAsync(HttpContext.User);

            ViewData["TotalQuantity"] = cart.Count();

            Order order = new Order()
            {
                Date = DateTime.UtcNow.AddHours(4),
                TotalAmount = GetTotalAmount(cart),
                ShippingAdress = shippingDetails.Adress + " /  " + shippingDetails.AdressLine,
                
            };
            if (currentUser != null)
            {
                order.UserId = currentUser.Id;

                  List<CartProduct> cartItems = await _context.CartProducts.Where(c => c.UserId == currentUser.Id).ToListAsync();

                  _context.CartProducts.RemoveRange(cartItems);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();


            foreach (CartProduct product in cart)
            {    
               await _context.OrderProducts.AddAsync(new OrderProduct { ProductId = product.ProductId, Price = product.CurrentPrice, Quantity = product.Quantity , OrderId=order.Id});
            }
            

            await _context.SaveChangesAsync();

            cart.Clear();

            await emailService.SendEmailAsync("230420asdfx@gmail.com", "New Order", messageBody.ToString());

            if (Request.Cookies["cart"] != null)
            {
                Response.Cookies.Delete("cart");
            }

            return View("Completed", await _context.Orders.Include(o => o.OrderProducts).ThenInclude(op => op.Product).FirstOrDefaultAsync(o => o.Id == order.Id));

        }


    }
}
