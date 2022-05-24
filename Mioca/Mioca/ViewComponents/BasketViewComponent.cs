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
    public class BasketViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basket;

        public BasketViewComponent(IMapper mapper, IBasketRepository basket)
        {
            _mapper = mapper;
            _basket = basket;
        }
        public IViewComponentResult Invoke()
        {
            Request.Cookies.TryGetValue("token", out string token);
            var basketitem = _basket.GetBasketByToken(token);
            var model = _mapper.Map<IEnumerable<Basket>, IEnumerable<BasketViewModel>>(basketitem);
            return View(model);
        }
    }
}
