using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mioca.Areas.Admin.Models;
using Repository.Constants;
using Repository.Data;
using Repository.Extensions;
using Repository.Models;
using Repository.Repositories.ShoppingRepositories;
using Repository.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;
        private readonly MiocaDbContext _context;

        public ProductController(IMapper mapper,
                                IProductRepository product,
                                ICategoryRepository category,
                                MiocaDbContext context)
        {
            _mapper = mapper;
            _product = product;
            _category = category;
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _product.GetProducts();
            var model = _mapper.Map<IEnumerable<Product>, IEnumerable<VmProduct>>(list);
            return View(model);
        }


        public IActionResult Detail(int id)
        {
            var product = _product.GetProductByDetailsId(id);

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            VmProductPost model = new VmProductPost
            {
               
                Categories = await _context.Categories.ToListAsync(),
                Label = await _context.Labels.ToListAsync(),


            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(VmProductPost model)
        {
           
            model.Categories = await _context.Categories.ToListAsync();
            model.Label = await _context.Labels.ToListAsync();

            if (!ModelState.IsValid) return View(model);



            //category
            var categ = await _context.Categories.FindAsync(model.CategoryId);
            if (categ == null)
            {
                ModelState.AddModelError(nameof(VmProductPost.CategoryId), "Choose a valid category");
                return View(model);
            }
         
            //label
            var label = await _context.Labels.FindAsync(model.LabelId);
            if (label == null)
            {
                ModelState.AddModelError(nameof(VmProductPost.LabelId), "Choose a valid label");
                return View(model);
            }

            if (!model.MainImage.IsOkay())
            {
                ModelState.AddModelError(nameof(VmProductPost.MainImage), "There is a problem in your file");
                return View(model);
            }


            List<ProductPhoto> images = new List<ProductPhoto>();
            foreach (var image in model.Images)
            {
                if (!image.IsOkay())
                {
                    ModelState.AddModelError(nameof(VmProductPhotos.Image), $"There is a problem in your {image.FileName} file");
                    return View(model);
                }
                images.Add(new ProductPhoto
                {
                    Image = FileUtils.Create(FileConstants.ImagePath, image)
                });
            }

            Product produc = new Product
            {
                Status = model.Status,
                Name = model.Name,
                Price = (decimal)model.Price,
                Description = model.Desc,
                Text = model.SubText,
                MainImage = FileUtils.Create(FileConstants.ImagePath, model.MainImage),
                Photos = images,
                Category = categ,
                Label = label,
                IsBestSeellers = model.IsBestSeellers,
                IsPopularCategory = model.IsPopularCategory,
                IsSingleBanner=model.IsSingleBanner,
                Quantity = model.Quantity,
                StarCount = model.StarCount,
                AddedDate = DateTime.Now,
            };

            await _context.Products.AddAsync(produc);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));



        }



        public async Task<IActionResult> updateProduct(int id)
        {
            var product = _product.GetProductByDetailsId(id);


            if (product == null) return NotFound();

            VmProductPost model = new VmProductPost
            {
                CategoryId = product.Categoryid,
                Name = product.Name,
                Desc = product.Description,
                Status = product.Status,
                Price = product.Price,
                SubText = product.Text,
                IsBestSeellers = product.IsBestSeellers,
                IsPopularCategory = product.IsPopularCategory,
                Quantity = product.Quantity,
                StarCount = product.StarCount,
                AddedDate = DateTime.Now,
                Categories = await _context.Categories.ToListAsync(),
                Label = await _context.Labels.ToListAsync(),
                Image = product.MainImage,
                Photos = product.Photos.Select(p => p.Image).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> updateProduct(int id, VmProductPost model)
        {
            var products = _product.GetProductByDetailsId(id);
            if (products == null) return NotFound();

            model.Categories = await _context.Categories.ToListAsync();
          if (!ModelState.IsValid) return View(model);



            //category
            var categ = await _context.Categories.FindAsync(model.CategoryId);
            if (categ == null)
            {
                ModelState.AddModelError(nameof(VmProductPost.CategoryId), "Choose a valid category");
                return View(model);
            }
            //label
            var label = await _context.Labels.FindAsync(model.LabelId);
            if (label == null)
            {
                ModelState.AddModelError(nameof(VmProductPost.LabelId), "Choose a valid label");
                return View(model);
            }

            if (model.MainImage != null)
            {
                if (!model.MainImage.IsOkay())
                {
                    ModelState.AddModelError(nameof(VmProductPost.MainImage), "There is a problem in your file");
                    return View(model);
                }
                FileUtils.Delete(Path.Combine(FileConstants.ImagePath, products.MainImage));
            }

            List<ProductPhoto> images = new List<ProductPhoto>();
            if (model.Images != null)
            {

                foreach (var image in model.Images)
                {
                    if (!image.IsOkay())
                    {
                        ModelState.AddModelError(nameof(VmProductPost.Images), "There is a problem in your file");
                        return View(model);
                    }
                    images.Add(new ProductPhoto { ProductId = products.Id, Image = FileUtils.Create(FileConstants.ImagePath, image) });
                };

                foreach (var image in products.Photos)
                {
                    FileUtils.Delete(image.Image);
                }
            }

            products.Name = model.Name;
            products.Description = model.Desc;
            products.Price = model.Price;
            products.Category = categ;
            products.Photos = images.Count > 0 ? images : products.Photos;
            products.MainImage = model.MainImage != null ? FileUtils.Create(FileConstants.ImagePath, model.MainImage) : products.MainImage;


            _context.Products.Update(products);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var product = _product.GetProductByDetailsId(id);
            if (product == null) return NotFound();


            foreach (var image in product.Photos)
            {
                FileUtils.Delete(image.Image);
            }

            FileUtils.Delete(product.MainImage);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }



    }
}



