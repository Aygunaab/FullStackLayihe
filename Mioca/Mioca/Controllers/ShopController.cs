using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mioca.Models;
using Repository.Models;
using Repository.Repositories.ContentRepositories;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class ShopController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;
        private readonly IContentRepository _content;
        public ShopController(IMapper mapper,
                              IProductRepository product, 
                              ICategoryRepository category, 
                              IContentRepository content)
        {
            _mapper = mapper;
            _product = product;
            _category = category;
            _content = content;
        }
        public IActionResult Index(CategorySearchViewModel search)
        {

            var category = _category.CategoryById(search.Id);
            if (category == null) return NotFound();
            var productcat = _product.GetProductCategoryid(category.Id);
            var filterprod = _product.GetFilterProduct(productcat, search.MinPrice, search.MaxPrice);
            var products= _product.GetproductsByCategoryId(filterprod,((search.Page-1)*search.Limit), search.Limit, Repository.Enums.ProductListing.PriceAsc);
           

            var model = new CategoryListViewModel
            {
                Category = _mapper.Map<Category, CategoryViewModel>(category),
                Products = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products),
                MinPrice = search.MinPrice,
                MaxPrice = search.MaxPrice,
                Count = filterprod.Count(),
                Limit = search.Limit,
                Page = search.Page,
                Setting = _content.Getset(),

            };
           

            return View(model);
        }
     
    }
}
