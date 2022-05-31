using Microsoft.EntityFrameworkCore;
using Repository.Data;
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
        IEnumerable<Product>GetproductsByCategoryId(int categoryId,int take,int skip, ProductListing orderBy);
       int GetProductsCountByCategoryid(int CategoryId);

    }
    public  class ProductRepository:IProductRepository
    {
        private readonly MiocaDbContext _context;

        public ProductRepository(MiocaDbContext context)
        {
            _context = context;
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

       
        public IEnumerable<Product> GetproductsByCategoryId(int categoryId, int take, int skip, ProductListing orderBy)
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
            };
           
            return products.Take(take).Skip(skip).ToList();
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
    }
}
