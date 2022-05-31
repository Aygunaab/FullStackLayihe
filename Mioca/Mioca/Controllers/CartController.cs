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
    public class CartController : Controller
    {
        private readonly IBasketRepository _basket;
        private readonly IMapper _mapper;

        public CartController(IBasketRepository basket, IMapper mapper)
        {
            _basket = basket;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            Request.Cookies.TryGetValue("token", out string token);
            var basket = _basket.GetBasketByToken(token);
           
            if (basket == null) return NotFound();
            
            var basketModel = _mapper.Map<IEnumerable<Basket>, IEnumerable<BasketViewModel>>(basket);
           
          
            return View(basketModel);
        }

        public IActionResult Emptycart()
        {
            return View();
        }

        public IActionResult Remove(int Id)
        {
            var basket = _basket.GetBasketById(Id);
            if (basket == null) return NotFound();

            Request.Cookies.TryGetValue("token", out string token);
            if (basket.Token != token) return NotFound();
            _basket.Remove(basket);
            var basketItem = _basket.GetBasketByToken(token);
            var basketModel = _mapper.Map<IEnumerable<Basket>, IEnumerable<BasketViewModel>>(basketItem);

            return PartialView("Basket/_NavbarBasket", basketModel);
        }

        public IActionResult AddBasket(int Id)
        {
            Request.Cookies.TryGetValue("token", out string token);
            var basketitem =_basket.GetBasketProductIdAndToken(Id, token);
            if (basketitem == null)
            {
                Basket basket = new Basket
                {
                    ProductId = Id,
                    Token = token,
                    Count = 1,
                    AddedBy = "System",
                    ModifiedBy = "System",

                };
                _basket.CreateBasket(basket);
            }
            else{
                _basket.ChangeCount(basketitem, basketitem.Count+1);
            }

            var basketItem = _basket.GetBasketByToken(token);
            var basketModel = _mapper.Map<IEnumerable<Basket>, IEnumerable<BasketViewModel>>(basketItem);
            return PartialView("Basket/_NavbarBasket", basketModel);
        }
    }
}
