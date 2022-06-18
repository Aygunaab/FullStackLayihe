using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mioca.Models;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class ProdDetailController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;
        private readonly UserManager<User> _usermanager;
        private readonly MiocaDbContext _context;

        public ProdDetailController(IMapper mapper, IProductRepository product, UserManager<User> usermanager, MiocaDbContext context)
        {
            _mapper = mapper;
            _product = product;
            _usermanager = usermanager;
            _context = context;
        }

        public IActionResult Index(int id)
        {
           
            var products = _product.GetProductByDetailsId(id);
            if (products == null) return NotFound();
            
            
            var model = _mapper.Map<Product, ProductViewModel>(products);

          
            
            var relatedProducts = _product.GetproductsByCategoryId(products.Category.Id, 0, 10, Repository.Enums.ProductListing.neness);
            ViewBag.RelatedProducts=_mapper.Map<IEnumerable<Product>,IEnumerable < ProductViewModel >> (relatedProducts);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddComment(int id, CommentViewModel model)
        {
            var products = _product.GetProductByDetailsId(id);
            if (products == null) return NotFound();

           

            var comment = new ProductReview
            {
                Subject=model.Review.Subject,
                Mesage = model.Review.Mesage,
                UserId = _usermanager.GetUserId(User),
                ProductId = id
            };

            await _context.ProductReviews.AddAsync(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { id });
        }



    }
}
