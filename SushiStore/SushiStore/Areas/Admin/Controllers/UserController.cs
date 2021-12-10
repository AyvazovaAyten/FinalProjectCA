using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SushiStore.DAL;
using SushiStore.Models;
using SushiStore.ViewModels;
using SushiStore.DTO.User;
using AutoMapper;

namespace WebAppDBConnection.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public UserController(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<User> Users = await _userManager.Users.ToListAsync();
            List<UserDto> userDtos = new List<UserDto>();

            foreach (User appUser in Users)
            {
                UserDto userDto = _mapper.Map<UserDto>(appUser);
                userDto.Role = (await _userManager.GetRolesAsync(appUser))[0];


                userDtos.Add(userDto);
            }
            return View(userDtos);
        }

        public async Task<IActionResult> ChangeStatus(string id)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            UserDto userDto = _mapper.Map<UserDto>(user);
            userDto.Role = (await _userManager.GetRolesAsync(user))[0];

            return View(userDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus(string id, bool Status)
        {
            if (id == null) return NotFound();

            User user = await _userManager.FindByIdAsync(id);

            if (user == null) return NotFound();

            user.IsDeleted = Status;
            user.DeletedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ChangeRole(string id)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            UserDto userDto = _mapper.Map<UserDto>(user);
            userDto.Role = (await _userManager.GetRolesAsync(user))[0];
            userDto.Roles = new List<string> { "Admin", "Member" };

            return View(userDto);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(string id, string Role, UserDto userDto)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if(!await _roleManager.RoleExistsAsync(Role))
            {
                return NotFound();
            }
            
            string oldRole = (await _userManager.GetRolesAsync(user))[0];

            await _userManager.RemoveFromRoleAsync(user, oldRole);
            await _userManager.AddToRoleAsync(user, Role);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();


            UserDto userDto = _mapper.Map<UserDto>(user);
            userDto.Role = (await _userManager.GetRolesAsync(user))[0];

            return View(userDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ChangePassword(string id, string NewPassword)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            IdentityResult result = await _userManager.ResetPasswordAsync(user, token, NewPassword);

            if (!result.Succeeded)
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(user);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
