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
    public class BestSellerViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;

        public BestSellerViewComponent(IMapper mapper, IProductRepository product)
        {
            _mapper = mapper;
            _product = product;
        }
        public IViewComponentResult Invoke()
        {
            var products = _product.GetProductBestSeeling();
            var model = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return View(model);
        }
    }
}
