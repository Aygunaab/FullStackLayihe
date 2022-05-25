using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.ShoppingRepositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly MiocaDbContext _context;

        public BasketRepository(MiocaDbContext context)
        {
            _context = context;

        }

        public Basket CreateBasket(Basket basket)
        {
            basket.AddedDate = DateTime.Now;
            basket.ModifiedDate = DateTime.Now;
            _context.Baskets.Add(basket);
            _context.SaveChanges();
            return basket;
        }

        public object GetBasketById(int id)
        {
            return _context.Baskets.Find(id);
        }

        public IEnumerable<Basket> GetBasketByToken(string token)
        {
            return _context.Baskets.Include("Product")
                                    .Include("Product.Discounts")
                                     .Include("Product.Discounts.Discount")
                                    .Include("Product.Photos")
                                    .Where(b => b.Token == token).ToList();
        }
    }
}
