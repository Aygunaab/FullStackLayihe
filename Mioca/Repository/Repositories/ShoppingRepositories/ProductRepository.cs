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
        IEnumerable<Product> GetProductBestSeeling();
        IEnumerable<Product> GetProductShop(int limit);
        IEnumerable<Product> GetproductsByCategoryId(IEnumerable<Product> product, int skip, int take, ProductListing orderBy);
       int GetProductsCountByCategoryid(int CategoryId);
        Product GetProductByDetailsId(int id);
        IEnumerable<Product> GetFilterProduct(IEnumerable<Product> product,decimal? MinPrice, decimal? MaxPrice);
        IEnumerable<Product> GetProductSingleBanner();
        IEnumerable<Product> GetProductPopularSeeling();
        IEnumerable<Product> GetProductBanner();
        IEnumerable<Product> SearchProducts(string searchString);
        IEnumerable<Product> GetProductCategoryid(int id);
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        Product GetProductByIdCheck(int id);
        Product GetProductId(int? id);
        void Delete(Product product);
        IEnumerable<Product> GetproductsRelatedByCategoryId(int id, int skip, int take, ProductListing neness);
    }
    public  class ProductRepository:IProductRepository
    {
        private readonly MiocaDbContext _context;

        public ProductRepository(MiocaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetFilterProduct(IEnumerable<Product>product,decimal? MinPrice, decimal? MaxPrice)
        {
           
                 return product
                        .Where(p => (MinPrice != null ? p.Price >= MinPrice : true) && (MaxPrice != null ? p.Price <= MaxPrice : true))
                                      .Where(p => p.Status);
            
        }

        public IEnumerable<Product> GetProductBestSeeling()
        {
            return _context.Products.Include("Photos")
                                    .Include("Label")
                                    .Include("Category")
                                    .Include("Discounts")
                                    .Include("Discounts.Discount")
                                    .Where(p => p.Status)
                                    .Where(p => p.IsBestSeellers)
                                    .OrderByDescending(p =>p.AddedDate)
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
        public Product GetProductByIdCheck(int id)
        {
            return _context.Products .Include("Discounts")
                                     .Include("Discounts.Discount")
                                     .FirstOrDefault(p => p.Status && p.Id == id);
        }
    

        public IEnumerable<Product> GetproductsByCategoryId(IEnumerable<Product> product, int skip, int take, ProductListing orderBy)
        {
            var products= product
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

        public Product GetProductId(int? id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include("Photos")
                                      .Include("Label")
                                      .Include("Category")
                                      .OrderByDescending(p=>p.AddedDate)
                                      .ToList();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChangesAsync();
        }

        public IEnumerable<Product> GetProductBanner()
        {
           return _context.Products.Include("Photos")
                                    .Include("Label")
                                    .Include("Category")
                                    .Include("Discounts")
                                    .Include("Discounts.Discount")
                                    .Where(p => p.Status)
                                    .Where(p => p.IsSingleBanner)
                                    .OrderByDescending(p =>p.AddedDate)                                   
                                    .ToList();
        }

        public IEnumerable<Product> GetProductPopularSeeling()
        {
            return _context.Products.Include("Photos")
                                   .Include("Label")
                                   .Include("Category")
                                   .Include("Discounts")
                                   .Include("Discounts.Discount")
                                   .Where(p => p.Status)
                                   .Where(p => p.IsPopularCategory)
                                   .OrderByDescending(p => p.AddedDate)
                                   .ToList();
        }

        public IEnumerable<Product> GetProductSingleBanner()
        {
            return _context.Products
                                   
                                   .Include("Category")
                                   .Include("Discounts")
                                   .Include("Discounts.Discount")
                                   .Where(p => p.Status)
                                   .Where(p => p.IsSingleBanner)
                                   .OrderByDescending(p => p.AddedDate)
                                   .Take(1)
                                   .ToList();
        }

        public IEnumerable<Product> GetproductsRelatedByCategoryId(int categoryId, int skip, int take, ProductListing orderBy)
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

        public IEnumerable<Product> GetProductCategoryid(int id)
        {
            return  _context.Products.Include("Photos")
                                      .Include("Label")
                                      .Include("Discounts")
                                      .Include("Discounts.Discount")
                                      .Where(p => p.Categoryid == id)
                                      .ToList();
        }

       
    }
}
