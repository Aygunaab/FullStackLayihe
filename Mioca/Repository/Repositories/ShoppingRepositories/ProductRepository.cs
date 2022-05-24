using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.ShoppingRepositories
{
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
                                    .Include("Categories")
                                    .Include("Categories.Category")
                                    .Include("Discounts")
                                    .Include("Discounts.Discount")
                                    .Where(p => p.Status)
                                    .Where(p => p.IsBestSeellers)
                                    .OrderByDescending(p => p.AddedDate)
                                    .Take(limit)
                                    .ToList();
        }
    }
}
