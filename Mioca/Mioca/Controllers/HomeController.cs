using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mioca.Models;
using Repository.Models;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;

        public HomeController(IMapper mapper, IProductRepository product, ICategoryRepository category)
        {
            _mapper = mapper;
            _product = product;
            _category = category;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
