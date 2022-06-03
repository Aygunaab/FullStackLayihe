
using AutoMapper;
using EduHome.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mioca.Models;
using Repository.Data;
using Repository.Models;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly MiocaDbContext _contet;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
     



        public AccountController(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, IMailService mailService, IMapper mapper, MiocaDbContext contet)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mailService = mailService;
            _mapper = mapper;
            _contet = contet;
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

            var user = await _userManager.FindByNameAsync(model.Login);

            if (user == null) user = await _userManager.FindByEmailAsync(model.Login);

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

            var signinResult = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe,false);
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
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(register.UserName);
            if (user != null)
            {
                ModelState.AddModelError("UserName", "Bu adda user movcuddur");
                return View();
            }
            var newuser = _mapper.Map<RegisterViewModel, CustomUser>(register);
           var identityresult = await _userManager.CreateAsync(newuser, register.Password);
            if (identityresult.Succeeded)
            {
                await _signInManager.SignInAsync(newuser, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in identityresult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newuser);
            var link = Url.Action(nameof(ConfirmEmail), "Account", new { newuser.UserName, token }, Request.Scheme);
            await _mailService.SendEmailAsync(new MailRequest
            {
                ToEmail = newuser.Email,
                Subject = "Complete registration",
                Body = link
            });

            return View("Index", "Home");
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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
