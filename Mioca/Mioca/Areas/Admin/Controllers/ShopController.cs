using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Mioca.Areas.Admin.Models;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.AdminRepositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Mioca.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ShopController : Controller
    {
        private readonly MiocaDbContext _context;
        private readonly IProductAdminRepository _product;
        private readonly IMapper _mapper;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public ShopController(MiocaDbContext context, 
                              IHostingEnvironment hostingEnvironment,
                               IProductAdminRepository product,
                               IMapper mapper)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _product = product;
            _mapper = mapper;
        }

        public IActionResult Sale()
        {

            var sale = _product.GetSales();
            var model = _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleViewmodel>>(sale);
            return View(model);
        
        }

        public IActionResult SaleItem(int? saleId)
        {
            var saleitem = _product.GetSalesItemById(saleId);
            var model = _mapper.Map<IEnumerable<SaleItem>, IEnumerable<SaleItemViewModel>>(saleitem);
            return View(model);
           
        }

        public IActionResult Tax()
        {
            var tax = _product.Gettax();
            var model = _mapper.Map<IEnumerable<Tax>, IEnumerable<TaxVievModel>>(tax);
            return View(model.FirstOrDefault());

           
        }

        public IActionResult CreateTax()
        {
            TaxVievModel model = new TaxVievModel { };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateTax(TaxVievModel model)
        {
            if (!ModelState.IsValid) return View();

            Tax tax = new Tax
            {
                Status = model.Status,
             Percent=model.Percent,
             PriceLimit=model.PriceLimit


            };


            _product.CreateTax(tax);

            return RedirectToAction(nameof(Tax));
        }

        public IActionResult UpdateTax(int id)
        {
            var tax = _product.GetTaxById(id);

            if (tax == null) return NotFound();
            TaxVievModel model = new TaxVievModel
            {
              Status=tax.Status,
              PriceLimit=tax.PriceLimit,
              Percent=tax.Percent

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateTax(int id, TaxVievModel model)
        {
            var tax = _product.GetTaxById(id);

            if (tax == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
         

            tax.Status = model.Status;
            tax.PriceLimit = model.PriceLimit;
            tax.Percent = model.Percent;

            _product.UpdateTax(tax);



            return RedirectToAction(nameof(Tax));


        }

        public IActionResult DeleteTax(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Tax model = _context.Taxs.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            //delete tax
            _context.Taxs.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("tax", "shop");
        }

    }
}
