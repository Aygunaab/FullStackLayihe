using Microsoft.AspNetCore.Mvc;
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

        public CartController(IBasketRepository basket)
        {
            _basket = basket;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Emptycart()
        {
            return View();
        }

        public IActionResult Remove(int id)
        {
            var basket = _basket.GetBasketById(id);
        }
    }
}
