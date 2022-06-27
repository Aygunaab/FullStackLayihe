using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mioca.Areas.Admin.Models;
using Repository.Constants;
using Repository.Extensions;
using Repository.Models;
using Repository.Repositories.AdminRepositories;
using Repository.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LayoutController : Controller
    {
        private readonly IAdminContentRepository _content;
        private readonly IMapper _mapper;

        public LayoutController(IAdminContentRepository content, 
                                IMapper mapper)
        {
            _content = content;
            _mapper = mapper;
        }

        public IActionResult Layout()
        {
            var layout = _content.GetLayout();
            var model = _mapper.Map<IEnumerable<Setting>, IEnumerable<SettingViewModel>>(layout);
            return View(model.FirstOrDefault());
        }
        public IActionResult CreateSetting()
        {

            SettingViewModel model = new SettingViewModel
            {
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSetting(SettingViewModel model)
        {

            if (!ModelState.IsValid) return View();

            if (!model.LogoFile.IsOkay())
            {
                ModelState.AddModelError(nameof(SettingViewModel.LogoFile), "File type is unsupported, please select image");
                return View(model);
            }

            Setting setting = new Setting
            {
                Status = model.Status,
                Email=model.Email,
                Phone=model.Phone,
                Number=model.Number,
                Adress=model.Adress,
                Logo = FileUtils.Create(FileConstants.ImagePath, model.LogoFile)


            };


            _content.CreateSetting(setting);

            return RedirectToAction(nameof(Layout));
        }
        public IActionResult UpdateSetting(int id)
        {
            var setting = _content.GetSettingById(id);

            if (setting == null) return NotFound();
            SettingViewModel model = new SettingViewModel
            {
                Status = setting.Status,
                Email=setting.Email,
                Phone=setting.Phone,
                Number=setting.Number,
                Adress=setting.Adress,
                Logo = setting.Logo

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSetting(int id, SettingViewModel model)
        {
            var setting = _content.GetSettingById(id);

            if (setting == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            //main image
            if (model.LogoFile != null)
            {
                if (!model.LogoFile.IsOkay())
                {
                    ModelState.AddModelError(nameof(SettingViewModel.LogoFile), "There is a problem in your file");
                    return View(model);
                }
                FileUtils.Delete(Path.Combine(FileConstants.ImagePath, setting.Logo));
            }

            setting.Status = model.Status;
            setting.Email = model.Email;
            setting.Phone = model.Phone;
            setting.Number = model.Number;
            setting.Adress = model.Adress;

            setting.Logo = model.LogoFile != null ? FileUtils.Create(FileConstants.ImagePath, model.LogoFile) : setting.Logo;

            _content.UpdateLayout(setting);



            return RedirectToAction(nameof(Layout));


        }

        public IActionResult DeleteSetting(int id)
        {
            var layout = _content.GetSettingById(id);
            if (layout == null) return NotFound();

            FileUtils.Delete(layout.Logo);

            _content.DeleteLayout(layout);


            return RedirectToAction(nameof(Layout));

        }
    }
}
