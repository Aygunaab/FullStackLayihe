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

namespace Mioca.ViewComponents
{
    public class SingleBannerViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;

        public SingleBannerViewComponent(IMapper mapper, IProductRepository product)
        {
            _mapper = mapper;
            _product = product;
        }

        public IViewComponentResult Invoke()
        {
            var bannerProduct = _product.GetProductSingleBanner();

            var model = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(bannerProduct);

            return View(model);
        }
    }
}

