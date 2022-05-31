
using AutoMapper;
using EduHome.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mioca.Models;
using Repository.Models;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basket;



        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMailService mailService, IMapper mapper, IBasketRepository basket)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mailService = mailService;
            _mapper = mapper;
            _basket = basket;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null)
            {
                ModelState.AddModelError(" ", "Invalid credential");
                return View();
            }
            var signinResult = await _signInManager.PasswordSignInAsync(user, login.Password, true, false);
            if (!signinResult.Succeeded)
            {
                ModelState.AddModelError(" ", "Invalid");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(register.UserName);
            if (user != null)
            {
                ModelState.AddModelError("UserName", "Bu adda user movcuddur");
                return View();
            }
            var newuser = _mapper.Map<RegisterViewModel, User>(register);
            IdentityResult identityresult = await _userManager.CreateAsync(newuser, register.Password);
            if (!identityresult.Succeeded)
            {
                foreach (var error in identityresult.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }
                return View();
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newuser);
            var link = Url.Action(nameof(ConfirmEmail), "Account", new { newuser.UserName, token }, Request.Scheme);
            await _mailService.SendEmailAsync(new MailRequest
            {
                ToEmail = newuser.Email,
                Subject = "Complete registration",
                Body = link
            });

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ConfirmEmail(string username, string token)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return BadRequest();
            var Identityresult = await _userManager.ConfirmEmailAsync(user, token);
            if (!Identityresult.Succeeded)
            {
                return BadRequest();
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
