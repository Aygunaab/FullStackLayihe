using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mioca.Areas.Admin.Models;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly MiocaDbContext _context;
        private readonly UserManager<User> _usermanager;
        private readonly RoleManager<IdentityRole> _roleMangaer;
        private readonly SignInManager<User> _signinManager;

        public UserController(MiocaDbContext context, UserManager<User> usermanager, RoleManager<IdentityRole> roleMangaer, SignInManager<User> signinManager)
        {
            _context = context;
            _usermanager = usermanager;
            _roleMangaer = roleMangaer;
            _signinManager = signinManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            List<VmUser> userList = new List<VmUser>();
            foreach (var user in users)
            {
                userList.Add(new VmUser
                {
                    Id = user.Id,
                   Name=user.Name,
                   SurName=user.Surname,
                    Username = user.UserName,
                    Roles = string.Join(",", (await _usermanager.GetRolesAsync(user))),
                    IsActive = user.IsActive
                });


            }
            return View(userList);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
  
        public async Task<IActionResult> Login(LoginVm model)
        {
            if (!ModelState.IsValid) return View();

            var user = await _usermanager.FindByNameAsync(model.Login);
            if (user == null) user = await _usermanager.FindByEmailAsync(model.Login);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View();
            }

            if (!user.IsActive)
            {
                ModelState.AddModelError("", "Your account was blocked by admin");
                return View();
            }

            var signinResult = await _signinManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (!signinResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Credentials");
                return View();
            }

            return RedirectToAction("Index", "product");

        }

        public async Task<IActionResult> GetRoles(string Id)
        {
            var user = await _usermanager.FindByIdAsync(Id);
            if (user == null) return NotFound();

            var roles = await _usermanager.GetRolesAsync(user);

            ViewBag.Name = user.Name;
            ViewBag.UserId = user.Id;
            return View(roles);
        }
        public async Task<IActionResult> RemoveRole(string id, string roleName)
        {
            var user = await _usermanager.FindByIdAsync(id);
            if (user == null) return NotFound();
            await _usermanager.RemoveFromRoleAsync(user, roleName);

            return RedirectToAction(nameof(GetRoles), new { user.Id });
        }
        public async Task<IActionResult> AddRole(string id)
        {
            var roles = await _context.Roles.Select(r => r.Name).ToListAsync();

            AddRoleVm model = new AddRoleVm
            {
                UserId = id,
                Roles = roles
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(string id, AddRoleVm model)
        {
            var user = await _usermanager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (!ModelState.IsValid) return View(model);

            await _usermanager.AddToRoleAsync(user, model.RoleName);

            return RedirectToAction(nameof(GetRoles), new { id });

        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await _usermanager.FindByIdAsync(id);
            if (user == null) return NotFound();
            ViewBag.Name = user.Name;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string id, ChangePasswordVm model)
        {
            var user = await _usermanager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (!ModelState.IsValid) return View();

            if (!await _usermanager.CheckPasswordAsync(user, model.OldPassword))
            {
                ModelState.AddModelError(nameof(ChangePasswordVm.OldPassword), "Old Password is not correct");
                return View();
            }

            var idResult = await _usermanager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!idResult.Succeeded)
            {
                foreach (var error in idResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> ToggleBlockUser(string id)
        {
            var user = await _usermanager.FindByIdAsync(id);
            if (user == null) return NotFound();

            user.IsActive = !user.IsActive;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
      
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("login", "user");
        }
    }
}

