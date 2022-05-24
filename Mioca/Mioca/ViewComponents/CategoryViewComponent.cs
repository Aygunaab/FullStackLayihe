using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mioca.Models;
using Repository.Models;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _category;

        public CategoryViewComponent(IMapper mapper, ICategoryRepository category)
        {
            _mapper = mapper;
            _category = category;
        }

        public IViewComponentResult Invoke()
        {
            var category = _category.GetCategories();
            var model = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(category);
            return View(model);
        }
    }
}
