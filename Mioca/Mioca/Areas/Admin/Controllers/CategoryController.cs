using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mioca.Areas.Admin.Models.Shopping;
using Repository.Constants;
using Repository.Extensions;
using Repository.Models;
using Repository.Repositories.ShoppingRepositories;
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
    public class CategoryController : Controller
    {
      
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _category;

        public CategoryController(IMapper mapper, ICategoryRepository category)
        {
            _mapper = mapper;
            _category = category;
        }

        public IActionResult Index()
        {
            var category = _category.Getcategory();
            var model = _mapper.Map < IEnumerable<Category>,IEnumerable<VmCategory>> (category);
            return View(model);
        }
        public IActionResult Detail(int id)
        {
            var category =  _category.CategoryById(id);
            if (category == null) return NotFound();
            return View(category);
        }
        public IActionResult Create()
        {
            VmCategory model = new VmCategory
            {

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VmCategory model)
        {
            //main image
            if (!model.LogoFile.IsOkay())
            {
                ModelState.AddModelError(nameof(VmCategory.LogoFile), "There is a problem in your file");
                return View(model);
            }

                Category cat = new Category
                {
                    Name = model.Name,
                    Logo = FileUtils.Create(FileConstants.ImagePath, model.LogoFile),
                    Status=model.Status

                };

            _category.CreateCategory(cat);

            return RedirectToAction(nameof(Index));

            
        }
        public IActionResult Update(int id)
        {
            var category = _category.CategoryById(id);

            if (category == null) return NotFound();
            VmCategory model = new VmCategory
            {
                Name = category.Name,
                Status=category.Status
                
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, VmCategory model)
        {
            var category = _category.CategoryById(id);
            if (category == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            //main image
            if (model.LogoFile != null)
            {
                if (!model.LogoFile.IsOkay())
                {
                    ModelState.AddModelError(nameof(VmCategory.LogoFile), "There is a problem in your file");
                    return View(model);
                }
                FileUtils.Delete(Path.Combine(FileConstants.ImagePath, category.Logo));
            }


            category.Name = model.Name;
            category.Status = model.Status;
            category.Logo = model.LogoFile != null ? FileUtils.Create(FileConstants.ImagePath, model.LogoFile) : category.Logo;

            _category.UpdateCategory(category);

           

            return RedirectToAction(nameof(Index));


        }
        public IActionResult Delete(int id)
        {
            var category = _category.CategoryById(id);
            if (category == null) return NotFound();

            FileUtils.Delete(category.Logo);

            _category.DeleteCategory(category);
           

            return RedirectToAction(nameof(Index));

        }


    }
}
