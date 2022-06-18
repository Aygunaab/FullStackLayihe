using Mioca.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Models;
using Mioca.Services;
using Microsoft.AspNetCore.Authorization;
using Repository.Data;
using Repository.Repositories.ContentRepositories;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Mioca.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _usermanager;
        private readonly IMailService _mailservice;
        private readonly SignInManager<User> _signinManager;
        private readonly IAccountRepository _userrepo;
        private readonly MiocaDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public AccountController(UserManager<User> usermanager,
                                IMailService mailservice, 
                                SignInManager<User> signinManager,
                                IAccountRepository userrepo, 
                                MiocaDbContext context, 
                                IHostingEnvironment hostingEnvironment)
        {
            _usermanager = usermanager;
            _mailservice = mailservice;
            _signinManager = signinManager;
            _userrepo = userrepo;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
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

            return RedirectToAction("Index", "Home");

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var user = await _usermanager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                ModelState.AddModelError("UserName", "Bu adda user movcuddur");
                return View();
            }
            User newuser = new User
            {
                Name= model.Name,
                Surname=model.Surname,
                UserName = model.UserName,
                Email = model.Email,
               

            };
            IdentityResult identityresult = await _usermanager.CreateAsync(newuser, model.Password);
            if (!identityresult.Succeeded)
            {
                foreach (var error in identityresult.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }
                return View();
            }
            var token = await _usermanager.GenerateEmailConfirmationTokenAsync(newuser);
            var link = Url.Action(nameof(ConfirmEmail), "Account", new { newuser.UserName, token }, Request.Scheme);
            await _mailservice.SendEmailAsync(new MailRequest
            {
                ToEmail = newuser.Email,
                Subject = "Complete registration",
                Body = link
            });

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> ConfirmEmail(string username, string token)
        {
            var user = await _usermanager.FindByNameAsync(username);
            if (user == null) return BadRequest();
            var Identityresult = await _usermanager.ConfirmEmailAsync(user, token);
            if (!Identityresult.Succeeded)
            {
                return BadRequest();
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            string userId = _usermanager.GetUserId(User);
            User user = _context.Users.Find(userId);
            ProfileViewModel model = new ProfileViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName,
                Roles = string.Join(",", (await _usermanager.GetRolesAsync(user))),
                IsActive = user.IsActive,
                Email = user.Email,
                State = user.State,
                Phone = user.Phone,
                Zipcode = user.ZipCode,
                Country = _context.Countries.Find(user.CountryId).Name,
                Adress = user.Address,
                Image = user.Image
            };
              
                   

                


            
            return View(model);


        }

        [Authorize]
        public IActionResult UpdateProfile()
        {
            List<Country> countries = _context.Countries.ToList();
            countries.Insert(0, new Country { Id = 0, Name = "Select*" });
            ViewBag.Country = countries;

            //Useri tap
            string userId = _usermanager.GetUserId(User);
            User user = _context.Users.Find(userId);

            ProfileViewModel model = new ProfileViewModel()
            {
               
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Phone = user.Phone,
                State = user.State,
                Zipcode = user.ZipCode,
                Image = user.Image,
                CountryId = user.CountryId
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [Obsolete]
        public IActionResult UpdateProfile(ProfileViewModel model)
        {
            //Useri tap
            string userId = _usermanager.GetUserId(User);
            User user = _context.Users.Find(userId);

            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/webp" || model.ImageFile.ContentType == "image/gif")
                    {
                        if (model.ImageFile.Length <= 5242880)
                        {
                            if (model.Image != null)
                            {
                                //movcud olan sekili sil
                                string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/User", model.Image);
                                if (System.IO.File.Exists(oldFilePath))
                                {
                                    System.IO.File.Delete(oldFilePath);
                                }
                            }


                            //yeni sekil elave et
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/User", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;

                            user.Name = model.Name;
                            user.Surname = model.Surname;
                            user.Email = model.Email;
                            user.Phone = model.Phone;
                            user.ZipCode = model.Zipcode;
                            user.State = model.State;
                            user.CountryId = (int)model.CountryId;
                            user.Image = model.Image;

                            //yenile
                            _context.Entry(user).State = EntityState.Modified;

                            

                            _context.SaveChanges();
                            return RedirectToAction("profile", "account");
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "The file image exceeds the maximum allowed size (5 MB).");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "You can only upload files in jpeg, png, webp, gif formats.");
                        return View(model);
                    }
                }

                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.Phone = model.Phone;
                user.ZipCode = model.Zipcode;
                user.State = model.State;
                user.CountryId = (int)model.CountryId;
                //yenile
                _context.Entry(user).State = EntityState.Modified;

                _context.SaveChanges();
                return RedirectToAction("profile", "account");

            };


            return View(model);
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel()
            {
               
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _usermanager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login", "account");
                }

                if (model.NewPassword != model.ConfirmNewPassword)
                {
                    
                    ModelState.AddModelError("", "New Password or Confirm Password is incorrect.");
                }
                else
                {
                    var result = await _usermanager.ChangePasswordAsync(user,
                    model.OldPassword, model.NewPassword);

                    if (!result.Succeeded)
                    {
                      
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    await _signinManager.RefreshSignInAsync(user);
                    if (result.Succeeded)
                    {
                       
                        return RedirectToAction("profile", "account");
                    }
                }

            }

      

            return View(model);
        }

    }
}
