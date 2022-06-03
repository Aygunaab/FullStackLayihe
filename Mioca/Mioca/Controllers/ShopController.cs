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
    public class ShopController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;

        public ShopController(IMapper mapper, IProductRepository product, ICategoryRepository category)
        {
            _mapper = mapper;
            _product = product;
            _category = category;
        }
        public IActionResult Index(CategorySearchViewModel search)
        {

            var category = _category.CategoryById(search.Id);
            if (category == null) return NotFound();
            var products= _product.GetproductsByCategoryId(category.Id,((search.Page-1)*search.Limit), search.Limit, Repository.Enums.ProductListing.PriceAsc);
            var productCount = _product.GetProductsCountByCategoryid(category.Id);
           
            var model = new CategoryListViewModel
            {
                Category = _mapper.Map<Category, CategoryViewModel>(category),
                Products=_mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products),
                MinPrice = search.MinPrice,
                MaxPrice = search.MaxPrice,
                Count = productCount,
                Limit = search.Limit,
                Page = search.Page,
              
               
                
            };
           

            return View(model);
        }
     
    }
}
