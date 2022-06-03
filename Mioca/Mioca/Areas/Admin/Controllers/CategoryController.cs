using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mioca.Areas.Admin.Models.Shopping;
using Repository.Models;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VmCategory model)
        {
            if (ModelState.IsValid)
            {
                Category category = _mapper.Map<VmCategory, Category>(model);
                return Ok(category);
            }
           
            
            return View(model);
        }
    }
}
