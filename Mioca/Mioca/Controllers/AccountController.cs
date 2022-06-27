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
using Repository.Extensions;
using Repository.Utils;
using Repository.Constants;
using Repository.Enums;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace Mioca.Controllers
{
    public class AccountController :BaseController
    {
        private readonly UserManager<User> _usermanager;
        private readonly IMailService _mailservice;
        private readonly SignInManager<User> _signinManager;
        private readonly IAccountRepository _userrepo;
        private readonly IContentRepository _content;
        private readonly MiocaDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public AccountController(UserManager<User> usermanager,
                                IMailService mailservice, 
                                SignInManager<User> signinManager,
                                IAccountRepository userrepo, 
                                MiocaDbContext context, 
                                IHostingEnvironment hostingEnvironment,
                                IContentRepository content)
        {
            _usermanager = usermanager;
            _mailservice = mailservice;
            _signinManager = signinManager;
            _userrepo = userrepo;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _content = content;
        }

        public IActionResult Login()
        {
            var setting = _content.GetSetting();
            LoginViewModel model = new LoginViewModel
            {
                Setting = _content.Getset(),
            };
            return View(model);
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
            var setting = _content.GetSetting();
            RegisterViewModel model = new RegisterViewModel
            {
                Setting = _content.Getset(),
            };
            return View(model);
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
            var setting = _content.GetSetting();
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
                Image = user.Image,
                Setting = _content.Getset(),
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
            var setting = _content.GetSetting();
            ProfileViewModel model = new ProfileViewModel()
            {
               
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Phone = user.Phone,
                State = user.State,
                Zipcode = user.ZipCode,
                Image = user.Image,
                CountryId = user.CountryId,
                Setting = _content.Getset(),


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
                    if (!model.ImageFile.IsOkay())
                    {
                        ModelState.AddModelError(nameof(ProfileViewModel.ImageFile), "There is a problem in your file");
                        return View(model);
                    }
                    FileUtils.Delete(Path.Combine(FileConstants.ImagePath, user.Image));
                }

                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.Phone = model.Phone;
                user.ZipCode = model.Zipcode;
                user.State = model.State;
                user.CountryId = (int)model.CountryId;
                user.Image = model.ImageFile != null ? FileUtils.Create(FileConstants.ImagePath, model.ImageFile) : user.Image;
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
            var setting = _content.GetSetting();
            ChangePasswordViewModel model = new ChangePasswordViewModel()
            {
                Setting = _content.Getset(),
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

        [Authorize]
        public IActionResult Getorder()
        {
            //Find User
            string userId = _usermanager.GetUserId(User);
            User user = _context.Users.Find(userId);

            List<SaleVm> vmOrders = new List<SaleVm>();
            List<Sale> sales = _context.Sales.Where(s => s.UserId == userId).ToList();
            List<SaleItem> saleItems = new List<SaleItem>();

            foreach (var sale in sales)
            {
                List<SaleItem> currentSaleItems = _context.SaleItems.Include(s => s.Sale).Include(p => p.Product).ThenInclude(i => i.Photos).Where(s => s.SaleId == sale.Id).ToList();

                foreach (var saleitem in currentSaleItems)
                {
                    saleItems.Add(saleitem);
                }
            }


            var setting = _content.GetSetting();
            SaleVm model = new SaleVm()
            { 
                SaleItems = saleItems,
                Sales = sales,
                Setting = _content.Getset(),
            };

            return View(model);
        }

        //Forgot Password
        public IActionResult ForgotPassword()
        {
            var setting = _content.GetSetting();
            ForgotPasswordViewModel model = new ForgotPasswordViewModel()
            {
                Setting = _content.Getset(),
            };

            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
          
            if (ModelState.IsValid)
            {

                var user = await _usermanager.FindByEmailAsync(model.Email);
              
                if (user != null )
                {


                    // Generate the reset password token
                    var token = HttpUtility.UrlEncode(await _usermanager.GeneratePasswordResetTokenAsync(user));


                    //Sending mail
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("aygunaab@code.edu.az", "Mioca");
                    mail.To.Add(model.Email);
                    mail.Body = "<h1>Hello!</h1> <br />" +
                        "<p>For resetting password please visit the link below</p>" +
                        "<a href='https://localhost:44392/account/resetpassword?email=" + model.Email + "&token=" + token + "'>Reset password</a>";

                    mail.IsBodyHtml = true;
                    mail.Subject = "Reset password";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("aygunaab@code.edu.az", "Aygun8997");
                  
                    smtpClient.Send(mail);
                    //End of sending mail


                    Notify("Please check your email account for reseting password.");
                }

                return RedirectToAction("login", "account");
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {

            if (token == null || email == null)
            {
                Notify("Invalid password reset token!", notificationType: NotificationType.error);
                ModelState.AddModelError("", "Invalid password reset token");
            }
            var setting = _content.GetSetting();
            ResetPasswordVievModel model = new ResetPasswordVievModel()
            {
                Setting = _content.Getset(),

            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordVievModel model)
        {
            
            if (ModelState.IsValid)
            {

                var user = await _usermanager.FindByEmailAsync(model.Email);

                if (user != null)
                {

                    var result = await _usermanager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        Notify("Password changed successfully");
                        return RedirectToAction("login", "account");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }


                return RedirectToAction("login", "account");
            }

            return View(model);
        }

    }
}
