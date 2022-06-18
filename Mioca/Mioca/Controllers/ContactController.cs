using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mioca.Models;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class ContactController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MiocaDbContext _context;

        public ContactController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, MiocaDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var contact = _context.Contacts.Include(c => c.Socials).ToList();

            ContactViewModel model = new ContactViewModel()
            {
               Contact=contact.FirstOrDefault(),

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel model)
        {
            if (_signInManager.IsSignedIn(User))
            {
                
                string userId = _userManager.GetUserId(User);
                User user = _context.Users.Find(userId);

                model.Name = user.Name;
                model.Surname = user.Surname;
                model.Email = user.Email;
                model.Phone = user.Phone;
            }

            if (ModelState.IsValid)
            {
                ContactMessage message = new ContactMessage()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    Phone = model.Phone,
                    Message = model.Message
                };

                _context.contactMessages.Add(message);
                _context.SaveChanges();

               

                return RedirectToAction("index", "home");
            }

            return View(model);
        }


        public JsonResult addSubscribe(string email)
        {
            if (email == null)
            {
                return Json(404);
            }

            bool isExist = _context.Subscribes.Any(e => e.Email == email);

            if (isExist)
            {
                return Json(505);
            }

            Subscribe subscribe = new Subscribe()
            {
                Email = email,
                AddedDate = DateTime.Now
            };

            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();

            return Json(200);
        }
    }
}
