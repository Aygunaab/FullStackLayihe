using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.AdminRepositories
{
    public interface IProductAdminRepository
    {
       IEnumerable<Sale> GetSales();
       SaleItem GetSalebYid(int? saleId);
        IEnumerable<SaleItem> GetSalesItemById(int? saleId);
       IEnumerable<Tax>Gettax();
        void CreateTax(Tax tax);
       Tax GetTaxById(int id);
        void UpdateTax(Tax tax);
    }
    public  class ProductAdminRepository:IProductAdminRepository
    {
        private readonly MiocaDbContext _context;

        public ProductAdminRepository(MiocaDbContext context)
        {
            _context = context;
        }

        public void CreateTax(Tax tax)
        {
            _context.Taxs.Add(tax);
            _context.SaveChanges();
        }

        public SaleItem GetSalebYid(int? saleId)
        {
            return _context.SaleItems.Find(saleId);
        }

        public IEnumerable<Sale> GetSales()
        {
            return _context.Sales.Include("Country")
                                 .Include("User")
                                  .Include("SaleItems")
                                 .OrderBy(p => p.AddedDate)
                                 .ToList();
        }

        public IEnumerable<Tax> Gettax()
        {
            return _context.Taxs.ToList();
        }

        public Tax GetTaxById(int id)
        {
            return _context.Taxs.Find(id);
        }

        public void UpdateTax(Tax tax)
        {
            _context.Taxs.Update(tax);
            _context.SaveChanges();
        }

        IEnumerable<SaleItem> IProductAdminRepository.GetSalesItemById(int? saleId)
        {
          return _context.SaleItems.Include(a => a.Product)
                                   .ThenInclude(pi => pi.Photos)
                                   .Where(item => item.SaleId == saleId)
                                   .ToList();
        }

       
    }
}
