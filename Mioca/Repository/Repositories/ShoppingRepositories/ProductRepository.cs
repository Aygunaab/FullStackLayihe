using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.DTO;
using Repository.Enums;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.ShoppingRepositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductBestSeeling(int limit);
        IEnumerable<Product> GetProductShop(int limit);
        IEnumerable<Product> GetproductsByCategoryId(int categoryId, int skip, int take, ProductListing orderBy);
       int GetProductsCountByCategoryid(int CategoryId);
        Product GetProductByDetailsId(int id);
        IEnumerable<Product> GetFilterbyCategoryid(int categoryId ,decimal? MinPrice, decimal? MaxPrice);
       IEnumerable<Product> SearchProducts(string searchString);
        IEnumerable<Product> GetProductMaxMinPrice(decimal? MinPrice, decimal? MaxPrice);
        Product GetProductById(int id);
    }
    public  class ProductRepository:IProductRepository
    {
        private readonly MiocaDbContext _context;

        public ProductRepository(MiocaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetFilterbyCategoryid(int categoryId, decimal? MinPrice, decimal? MaxPrice)
        {
            var products = _context.Products.Include("Photos")
                                      .Include("Label")
                                      .Include("Discounts")
                                      .Include("Discounts.Discount")
                                      .Where(p => (MinPrice != null ? p.Price >= MinPrice : true) && (MaxPrice != null ? p.Price <= MaxPrice : true))
                                      .Where(p => p.Categoryid == categoryId)
                                      .Where(p => p.Status);
            return products;
        }

        public IEnumerable<Product> GetProductBestSeeling(int limit)
        {
            return _context.Products.Include("Photos")
                                    .Include("Label")
                                    .Include("Category")
                                    .Include("Discounts")
                                    .Include("Discounts.Discount")
                                    .Where(p => p.Status)
                                    .Where(p => p.IsBestSeellers)
                                    .OrderByDescending(p =>p.AddedDate)
                                    .Take(limit)
                                    .ToList();
        }

        public Product GetProductByDetailsId(int id)
        {
            return _context.Products.Include("Photos")
                                     .Include("Label")
                                     .Include("Category")
                                     .Include("Discounts")
                                     .Include("Discounts.Discount")
                                     .Include("Category")
                                     .Include("Reviews")
                                     .Include("Reviews.User")
                                     .Include("Specs")
                                     .Include("Socials")
                                     .Include("Socials.Social")

                                     .FirstOrDefault(p => p.Status && p.Id == id);
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Status && p.Id == id);
        }

        public IEnumerable<Product> GetProductMaxMinPrice(decimal? MinPrice, decimal? MaxPrice)
        {
            var filter = _context.Products.Include("Photos")
                                    .Include("Label")
                                    .Include("Discounts")
                                    .Include("Discounts.Discount")
                                    .Where(p => (MinPrice != null ? p.Price >= MinPrice : true) && (MaxPrice != null ? p.Price <= MaxPrice : true))
                                    .Where(p => p.Status).ToList();
                                    
            return filter;
        }

        public IEnumerable<Product> GetproductsByCategoryId(int categoryId, int skip, int take, ProductListing orderBy)
        {
            var products = _context.Products.Include("Photos")
                                    .Include("Label")
                                    .Include("Discounts")
                                    .Include("Discounts.Discount")
                                    .Where(p => p.Categoryid == categoryId)
                                    .Where(p => p.Status);
           
            switch (orderBy)
            {
                case ProductListing.neness:
                    products.OrderByDescending(p => p.AddedDate);
                    break;
                case ProductListing.PriceAsc:
                    products.OrderBy(p => p.Price);
                    break;
                case ProductListing.PriceDsc:
                    products.OrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }
           


            return products.Skip(skip).Take(take).ToList();
        }

        public int GetProductsCountByCategoryid(int CategoryId)
        {
            return _context.Products.Where(p => p.Categoryid == CategoryId)
                                    .Where(p => p.Status)
                                    .Count();
        }

        public IEnumerable<Product> GetProductShop(int limit)
        {
            return _context.Products.Include("Photos")
                                     .Include("Label")
                                     .Include("Category")
                                     .Include("Discounts")
                                     .Include("Discounts.Discount")
                                     .Where(p => p.Status)
                                     .OrderByDescending(p => p.AddedDate)
                                     .Take(limit)
                                     .ToList();
        }

        public IEnumerable<Product> SearchProducts(string searchString)
        {
            return _context.Products.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
        }
    }
}
