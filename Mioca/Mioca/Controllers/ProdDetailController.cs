using AutoMapper;
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
    public class ProdDetailController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;

        public ProdDetailController(IMapper mapper, IProductRepository product)
        {
            _mapper = mapper;
            _product = product;
        }

        public IActionResult Index(int id)
        {
            var products = _product.GetProductByDetailsId(id);
            if (products == null) return NotFound();
            var model = _mapper.Map<Product, ProductViewModel>(products);
            var relatedProducts = _product.GetproductsByCategoryId(products.Category.Id, 0, 10, Repository.Enums.ProductListing.neness);
            ViewBag.RelatedProducts=_mapper.Map<IEnumerable<Product>,IEnumerable < ProductViewModel >> (relatedProducts);
            return View(model);
        }

        public IActionResult LiveRewiev(int id)
        {
            var products = _product.GetProductById(id);
            if (products == null) return NotFound();
            ViewBag.Productid = products.Id;
            ViewBag.ProductName = products.Name;
          
            return View();
        }
    }
}
