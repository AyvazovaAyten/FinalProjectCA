using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SushiStore.DAL;
using SushiStore.Models;
using SushiStore.Services;
using SushiStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Controllers
{
    [Authorize]
    public class AuthController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

       
        public AuthController(AppDbContext context,UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _usermanager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
           
        }
  
        public async Task CreateRole()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                });
            if (!await _roleManager.RoleExistsAsync("Member"))
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Member"
                });
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            //await CreateRole();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            User user = new User()
            {
                UserName = registerVM.Email,
                Email = registerVM.Email,
                FirstName=registerVM.FirstName,
                SurName = registerVM.SurName,
                Adress=registerVM.Adress,
                AdressLine = registerVM.AdressLine
            };
            
            IdentityResult identityResult = await _usermanager.CreateAsync(user, registerVM.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);

            }
            // generating token for user

            var code = await _usermanager.GenerateEmailConfirmationTokenAsync(user);

            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Auth",
                new { userId = user.Id, code = code },
                protocol: HttpContext.Request.Scheme);

            EmailService emailService = new EmailService();
           

            await emailService.SendEmailAsync(registerVM.Email, "Email Confirmation",
                       "To complete registration click:: <a href=\""
                                                       + callbackUrl + "\">here!</a>");

            await _usermanager.AddToRoleAsync(user, "Member");
            

            return View("MailConfirm");

        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return NotFound();
            }
            var user = await _usermanager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _usermanager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                return NotFound();
            }

            await _signInManager.SignInAsync(user, true);

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(string returnUrl = null)
        {
            return View(new LoginVM { ReturnUrl = returnUrl ,
                Page = await _context.Pages.Include(p => p.PageIntro).
                Include(p => p.Title).Include(p => p.MetaTags).
                Where(p => p.Name.Trim().ToLower() == "login").FirstOrDefaultAsync(),
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            User user = await _usermanager.FindByEmailAsync(loginVM.Email);
            
            if (user == null)
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
                return View();
            }
            
            if (!await _usermanager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Confirm your email adress");
                return View(loginVM);
            }
            if (user.IsDeleted)
            {
                ModelState.AddModelError("", "Account is deleted.");
                return View(loginVM);
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
                return View();
            }

            List<CartProduct> cartProducts = await _context.CartProducts.Where(c => c.UserId == user.Id).ToListAsync();

            if (cartProducts.Count > 0)
            {

                Response.Cookies.Append("cart", JsonConvert.SerializeObject(cartProducts), new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(20),
                    IsEssential = true
                });
            }

            return RedirectToAction("Index", "Home");
        }

        
        public async Task<IActionResult> LogOut()
        {
            if (Request.Cookies["cart"] != null)
            {
                List<CartProduct> cartItems = JsonConvert.DeserializeObject<List<CartProduct>>(Request.Cookies["cart"]);

                User currentUser = await _usermanager.GetUserAsync(HttpContext.User);

                List<CartProduct> dbProducts = await _context.CartProducts.Where(p => p.UserId == currentUser.Id).ToListAsync();

                _context.CartProducts.RemoveRange(dbProducts);

                foreach (CartProduct cartItem in cartItems)
                {
                    CartProduct newItem = new CartProduct();
                    
                        newItem = new CartProduct()
                        {
                            UserId=currentUser.Id,
                            ProductId=cartItem.ProductId,
                            Image=cartItem.Image,
                            Quantity=cartItem.Quantity,
                            CurrentPrice=cartItem.CurrentPrice,
                            OldPrice=cartItem.OldPrice,
                            Name=cartItem.Name
                        };

                        await _context.CartProducts.AddAsync(newItem);                                   

                }
                 await _context.SaveChangesAsync();

                Response.Cookies.Delete("cart");

            }

            await _signInManager.SignOutAsync();
            
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            User user = await _usermanager.FindByEmailAsync(model.Email);


                if (user == null || !(await _usermanager.IsEmailConfirmedAsync(user)))
                {
                    return View("ForgotPasswordConfirmation");
                }

           

            string code = await _usermanager.GeneratePasswordResetTokenAsync(user);

                var callbackUrl = Url.Action("ResetPassword", "Auth", new { Email = model.Email, Code = code }, Request.Scheme);

                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(model.Email, "Reset Password",
                    $"Click to link to reset password: <a href='{callbackUrl}'>link</a>");
                return View("ForgotPasswordConfirmation");

        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code, string email)
        {
            if (code == null || email==null)
            {
                ModelState.AddModelError("", "Invalid email or token!");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = await _usermanager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email is incorrect!");
                return View();
            }


            IdentityResult result = await _usermanager.ResetPasswordAsync(user, model.Code, model.Password);


            if (result.Succeeded)
            {
                return View("ResetPasswordConfirmation");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
    }
}
