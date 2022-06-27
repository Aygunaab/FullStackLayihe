using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mioca.Models;
using Repository.Models;
using Repository.Repositories.ContentRepositories;
using System;
using System.Linq;


namespace Mioca.Controllers
{
    public class ContactController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IContentRepository _content;
        private readonly IAccountRepository _account;

        public ContactController(UserManager<User> userManager, 
                                 SignInManager<User> signInManager, 
 
                                 IContentRepository content,
                                 IAccountRepository account)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _content = content;
            _account = account;
        }

        public IActionResult Index(int id)
        {

            var contact = _content.GetContact();
           

            ContactViewModel model = new ContactViewModel()
            {
               Contact=contact.FirstOrDefault(),
                Setting = _content.Getset(),

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel model)
        {
            if (_signInManager.IsSignedIn(User))
            {
                
                string userId = _userManager.GetUserId(User);
                User user = _account.GetUserByid(userId);

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
                _content.CreateMessage(message);
                Notify("Mesajınız uğurla göndərildi");
                return RedirectToAction("index", "home");
            }
            model.Setting = _content.GetSetting().FirstOrDefault();
            return View(model);
        }


        public JsonResult addSubscribe(string email)
        {
            if (email == null)
            {
                return Json(404);
            }

            bool isExist = _content.Subscribe(email);

            if (isExist)
            {
                return Json(505);
            }

            Subscribe subscribe = new Subscribe()
            {
                Email = email,
                AddedDate = DateTime.Now
            };

            _content.AddSubscribe(subscribe);

            return Json(200);
        }
    }
}
