using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.ShoppingRepositories
{
    public interface IBasketRepository
    {
        IEnumerable<Basket> GetBasketByToken(string token);
        IEnumerable<Basket> GetBasket();
        Basket CreateBasket(Basket basket);
        Basket GetBasketById(int Id);
        void Remove(Basket basket);
        Basket GetBasketProductIdAndToken(int ProductId, string token);
        void ChangeCount(Basket basketitem, int count);
        void GetUdateToken(string Guesttokenn, string usertoken);
    }
    public class BasketRepository : IBasketRepository
    {
        private readonly MiocaDbContext _context;

        public BasketRepository(MiocaDbContext context)
        {
            _context = context;

        }

        public void ChangeCount(Basket basketitem, int count)
        {
            _context.Entry(basketitem).State = EntityState.Modified;
            basketitem.Count = count;
            _context.SaveChanges();
        }

        public Basket CreateBasket(Basket basket)
        {
            basket.AddedDate = DateTime.Now;
            basket.ModifiedDate = DateTime.Now;
            _context.Baskets.Add(basket);
            _context.SaveChanges();
            return basket;
        }

        public IEnumerable<Basket> GetBasket()
        {
            return _context.Baskets.Include("Product")
                                  .Include("Product.Discounts")
                                   .Include("Product.Discounts.Discount")
                                  .Include("Product.Photos")
                                  .ToList();
        }

        public Basket GetBasketById(int Id)
        {
            return _context.Baskets.Find(Id);
        }

        public IEnumerable<Basket> GetBasketByToken(string token)
        {
            return _context.Baskets.Include("Product")
                                    .Include("Product.Discounts")
                                     .Include("Product.Discounts.Discount")
                                    .Include("Product.Photos")
                                    .Where(b => b.Token == token).ToList();
        }

        public Basket GetBasketProductIdAndToken(int ProductId, string token)
        {
            return _context.Baskets.SingleOrDefault(b => b.ProductId == ProductId && b.Token == token);
        }

        public void GetUdateToken(string Guesttokenn, string usertoken)
        {
            foreach (var item in _context.Baskets.Where(b=>b.Token==Guesttokenn).ToList())
            {
                item.Token = usertoken;
            }
            _context.SaveChanges();
        }

        public void Remove(Basket basket)
        {
            _context.Baskets.Remove(basket);
            _context.SaveChanges();
            
        }

       
    }
}
