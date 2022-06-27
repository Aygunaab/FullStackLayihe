using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mioca.Models;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.ContentRepositories;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class ProdDetailController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;
        private readonly IContentRepository _content;
        private readonly UserManager<User> _usermanager;
       

        public ProdDetailController(IMapper mapper, 
                                   IProductRepository product,
                                   IContentRepository content,
                                   UserManager<User> usermanager)
        {
            _mapper = mapper;
            _product = product;
            _content = content;
            _usermanager = usermanager;
          
        }

        public IActionResult Index(int id)
        {
           
            var products = _product.GetProductByDetailsId(id);
            if (products == null) return NotFound();
            
            
            var model = _mapper.Map<Product, ProductViewModel>(products);

            model.Setting = _content.Getset();
            
            var relatedProducts = _product.GetproductsRelatedByCategoryId(products.Category.Id, 0, 10, Repository.Enums.ProductListing.neness);
            ViewBag.RelatedProducts=_mapper.Map<IEnumerable<Product>,IEnumerable < ProductViewModel >> (relatedProducts);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddComment(int id, CommentViewModel model)
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

            _content.CreateCommentProduct(comment);

            return RedirectToAction(nameof(Index), new { id });
        }



    }
}
