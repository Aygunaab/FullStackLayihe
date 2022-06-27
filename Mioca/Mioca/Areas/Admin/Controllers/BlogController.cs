using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mioca.Areas.Admin.Models;
using Mioca.Models;
using Repository.Constants;
using Repository.Data;
using Repository.Extensions;
using Repository.Models;
using Repository.Repositories.AdminRepositories;
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
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blog;
        private readonly MiocaDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _usermanager;


        public BlogController(IBlogRepository blog,
                              IMapper mapper,
                              MiocaDbContext context,
                              UserManager<User> usermanager)
        {
            _blog = blog;
            _mapper = mapper;
            _context = context;
            _usermanager = usermanager;
        }


        public IActionResult Blog()
        {
            var blog = _blog.GetBlog();
            var model = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogGetViewModel>>(blog);
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var blog = _blog.GetBlogById(id);

            if (blog == null) return NotFound();

            return View(blog);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            BlogViewModel model = new BlogViewModel
            {

                Category= await _context.BlogCategorys.ToListAsync(),
               
               
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBlog(BlogViewModel model)
        {

            model.Category = await _context.BlogCategorys.ToListAsync();
            model.UserId = _usermanager.GetUserId(User);

            if (!ModelState.IsValid) return View(model);



            //category
            var categ = await _context.BlogCategorys.FindAsync(model.CategoryId);
            if (categ == null)
            {
                ModelState.AddModelError(nameof(BlogViewModel.CategoryId), "Choose a valid category");
                return View(model);
            }

         
            if (!model.ImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(BlogViewModel.ImageFile), "There is a problem in your file");
                return View(model);
            }


            Blog blog = new Blog
            {
                Status = model.Status,
               Title=model.Title,
               TextBottomQuote=model.TextBottomQuote,
               TextTopQuote=model.TextTopQuote,
               SloganUser=model.SloganUser,
                Image = FileUtils.Create(FileConstants.ImagePath, model.ImageFile),
                Category = categ,
                UserId = _usermanager.GetUserId(User),
               
                AddedDate = DateTime.Now,
            };

            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Blog));



        }



        public async Task<IActionResult> UpdateBlog(int id)
        {
            var blog = _blog.GetBlogById(id);


            if (blog == null) return NotFound();

            BlogViewModel model = new BlogViewModel
            {
                CategoryId = blog.CategoryId,
               Title= blog.Title,
                TextTopQuote = blog.TextTopQuote,
                TextBottomQuote=blog.TextBottomQuote,
                Status = blog.Status,
                SloganUser = blog.SloganUser,
                AddedDate = DateTime.Now,
                Category = await _context.BlogCategorys.ToListAsync(),  
                Image = blog.Image,
               
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBlog(int id, BlogViewModel model)
        {
            var blog = _blog.GetBlogById(id);
            if (blog == null) return NotFound();

            model.Category = await _context.BlogCategorys.ToListAsync();
            if (!ModelState.IsValid) return View(model);



            //category
            var categ = await _context.BlogCategorys.FindAsync(model.CategoryId);
            if (categ == null)
            {
                ModelState.AddModelError(nameof(BlogViewModel.CategoryId), "Choose a valid category");
                return View(model);
            }
           

            if (model.ImageFile != null)
            {
                if (!model.ImageFile.IsOkay())
                {
                    ModelState.AddModelError(nameof(BlogViewModel.ImageFile), "There is a problem in your file");
                    return View(model);
                }
                FileUtils.Delete(Path.Combine(FileConstants.ImagePath, blog.Image));
            }

          
            blog.Title = model.Title;
            blog.TextBottomQuote = model.TextBottomQuote;
            blog.TextTopQuote = model.TextTopQuote;
            blog.SloganUser = model.SloganUser;
            blog.Category = categ;
            blog.Image = model.ImageFile != null ? FileUtils.Create(FileConstants.ImagePath, model.ImageFile) : blog.Image;


            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Blog));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var blog = _blog.GetBlogById(id);
            if (blog == null) return NotFound();


            FileUtils.Delete(blog.Image);

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Blog));

        }


    }
}
