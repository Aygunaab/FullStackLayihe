using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mioca.Models;
using Repository.Models;
using Repository.Repositories.ContentRepositories;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;
        private readonly IContentRepository _content;

        public HomeController(IMapper mapper, 
                              IProductRepository product, 
                              ICategoryRepository category,
                              IContentRepository content)
        {
            _mapper = mapper;
            _product = product;
            _category = category;
            _content = content;
        }

        public IActionResult Index()
        {

            BaseViewModel model = new BaseViewModel
            {
                Setting = _content.Getset(),
            };
            return View(model);
        }
        public IActionResult Search(string searchString)
        {

            var products = _product.SearchProducts(searchString);
            var model = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            if (string.IsNullOrEmpty(searchString))
            {
                return PartialView("Search/_search", new List<Product>());
            }

            return PartialView("Search/_search",model);
        }

        public IActionResult ErrorPage()
        {
            var setting = _content.GetSetting();
            BaseViewModel model = new BaseViewModel
            {
                Setting = setting.FirstOrDefault()
            };
            return View(model);
        }
    }
}
