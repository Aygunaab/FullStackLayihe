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
    public class TopSellerViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;

        public TopSellerViewComponent(IMapper mapper, IProductRepository product)
        {
            _mapper = mapper;
            _product = product;
        }
        public IViewComponentResult Invoke()
        {
            var products = _product.GetProductPopularSeeling();
            var model = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return View(model);
        }
    }
}
