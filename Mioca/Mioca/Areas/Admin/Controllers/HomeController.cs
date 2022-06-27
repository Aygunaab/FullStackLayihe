using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mioca.Areas.Admin.Models;
using Repository.Constants;
using Repository.Extensions;
using Repository.Models;
using Repository.Repositories.ContentRepositories;
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
    public class HomeController : Controller
    {

        private readonly IContentRepository _content;
        private readonly IMapper _mapper;

        public HomeController(IContentRepository content, IMapper mapper)
        {
            _content = content;
            _mapper = mapper;
        }

     
        #region SliderCrud
        public IActionResult Slider()
        {
            var sliders = _content.GetSliderItemAdmin();
            var slidermodel = _mapper.Map<IEnumerable<SliderItem>, IEnumerable<SliderVm>>(sliders);
            return View(slidermodel);
        }
        public IActionResult CreateSlider()
        {

            SliderVm model = new SliderVm
            {
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSlider(SliderVm slider)
        {

            if (!ModelState.IsValid) return View();

            if (!slider.ImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(SliderVm.ImageFile), "File type is unsupported, please select image");
                return View(slider);
            }

            SliderItem slid = new SliderItem
            {
             
              Title=slider.Subtitle,
              Subtitle=slider.Subtitle,
              DiscountPrice=slider.DiscountPrice,
              Price=slider.Price,
              ActionText=slider.ActionText,
              Endpoint=slider.Endpoint,
                Image = FileUtils.Create(FileConstants.ImagePath, slider.ImageFile)


            };
           

             _content.CreateSlider(slid);

          

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var slider = _content.GetSliderItemById(id);

            if (slider == null) return NotFound();
            SliderVm model = new SliderVm 
            {
               Status=slider.Status,
               Title=slider.Title,
               Subtitle=slider.Subtitle,
               ActionText=slider.ActionText,
               Endpoint=slider.Endpoint,
               Price=slider.Price,
               DiscountPrice=slider.DiscountPrice

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, SliderVm model)
        {
            var slider = _content.GetSliderItemById(id);

            if (slider == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            //main image
            if (model.ImageFile != null)
            {
                if (!model.ImageFile.IsOkay())
                {
                    ModelState.AddModelError(nameof(SliderVm.ImageFile), "There is a problem in your file");
                    return View(model);
                }
                FileUtils.Delete(Path.Combine(FileConstants.ImagePath, slider.Image));
            }

            slider.Status = model.Status;
            slider.Title = model.Title;
            slider.Subtitle = model.Subtitle;
            slider.ActionText = model.ActionText;
            slider.Endpoint = model.Endpoint;


            slider.Image = model.ImageFile != null ? FileUtils.Create(FileConstants.ImagePath, model.ImageFile) : slider.Image;

            _content.UpdateSlider(slider);



            return RedirectToAction(nameof(Index));


        }

        public IActionResult Delete(int id)
        {
            var slider = _content.GetSliderItemById(id);
            if (slider == null) return NotFound();

            FileUtils.Delete(slider.Image);

            _content.DeleteSlider(slider);


            return RedirectToAction(nameof(Index));

        }
        #endregion

        #region BannerCrud
        public IActionResult Banner()
        {
            var banner = _content.GetBannersAdmin();
            var Bannermodel = _mapper.Map<IEnumerable<Banner>, IEnumerable<BannerVm>>(banner);
            return View(Bannermodel);
        }
        public IActionResult CreateBanner()
        {

            BannerVm model = new BannerVm
            {
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBanner(BannerVm model)
        {

            if (!ModelState.IsValid) return View();

            if (!model.ImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(BannerVm.ImageFile), "File type is unsupported, please select image");
                return View(model);
            }

            Banner banner = new Banner
            {
                Status=model.Status,
                Title = model.Title,
                SubTitle = model.SubTitle,
               Category=model.Category,
               ActionText=model.ActionText,
               EndPoint=model.EndPoint,
               CardWidth=model.CardWidth,
               IsTopBanner=model.IsTopBanner,
               IsBottomBanner=model.IsBottomBanner,
               AddedDate=DateTime.Now,
                Image = FileUtils.Create(FileConstants.ImagePath, model.ImageFile)


            };


            _content.CreateBanner(banner);



            return RedirectToAction(nameof(Index));
        }

        public IActionResult BannerUpdate(int id)
        {
            var banner = _content.GetBannerById(id);

            if (banner == null) return NotFound();
            BannerVm model = new BannerVm
            {
                Status = banner.Status,
                Title = banner.Title,
                SubTitle = banner.SubTitle,
                ActionText = banner.ActionText,
                EndPoint = banner.EndPoint,
                IsBottomBanner=banner.IsBottomBanner,
                IsTopBanner=banner.IsTopBanner,
                CardWidth=banner.CardWidth,
                Category=banner.Category
                

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BannerUpdate(int id, BannerVm model)
        {
            var banner = _content.GetBannerById(id);

            if (banner == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            //main image
            if (model.ImageFile != null)
            {
                if (!model.ImageFile.IsOkay())
                {
                    ModelState.AddModelError(nameof(BannerVm.ImageFile), "There is a problem in your file");
                    return View(model);
                }
                FileUtils.Delete(Path.Combine(FileConstants.ImagePath, banner.Image));
            }


            banner.Status = model.Status;
                banner.Title = model.Title;
                banner.SubTitle = model.SubTitle;
                banner.ActionText = model.ActionText;
                banner.EndPoint = model.EndPoint;
                banner.IsBottomBanner = model.IsBottomBanner;
                banner.IsTopBanner = model.IsTopBanner;
                banner.CardWidth = model.CardWidth;
                banner.Category = model.Category;

            banner.Image = model.ImageFile != null ? FileUtils.Create(FileConstants.ImagePath, model.ImageFile) : banner.Image;

            _content.UpdateBanner(banner);



            return RedirectToAction(nameof(Index));


        }

        public IActionResult BannerDelete(int id)
        {
            var banner = _content.GetBannerById(id);
            if (banner == null) return NotFound();

            FileUtils.Delete(banner.Image);

            _content.DeleteBanner(banner);


            return RedirectToAction(nameof(Index));

        }
        #endregion
    }
}
