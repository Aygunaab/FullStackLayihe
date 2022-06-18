using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mioca.Models;
using Newtonsoft.Json;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.ViewComponents
{
    public class NavViewComponent : ViewComponent
    {
        private readonly MiocaDbContext _context;

        public NavViewComponent(MiocaDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync();

            string cart = Request.Cookies["cart"];
            if (cart == null)
            {
                return View();
            }
            List<string> prdList = cart.Split("/").ToList();
            List<BasketViewModel> products = new List<BasketViewModel>();

            foreach (var item in prdList)
            {
                int prdId = Convert.ToInt32(item.Split("-")[0]);
                int prdQuantity = Convert.ToInt32(item.Split("-")[1]);
                BasketViewModel prd = new BasketViewModel();
                Product product = _context.Products.FirstOrDefault(c => c.Id == prdId);
                if (product == null)
                {
                    return View();
                }

                prd.Id = product.Id;
                prd.MainImage = product.MainImage;
                prd.Name = product.Name;
                prd.Price = product.Price;
                prd.Quantity = prdQuantity;

                products.Add(prd);
            }

            ViewBag.Count = products.Sum(b => b.Count);
            NavViewModel model = new NavViewModel
            {
                Setting = setting,
                Basket = products

            };

            return View(model);
        }
    }
}
