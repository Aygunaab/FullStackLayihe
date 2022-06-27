using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mioca.Models;
using Repository.Data;
using Repository.Enums;
using Repository.Models;
using Repository.Repositories.ContentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class BlogController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MiocaDbContext _context;
        private readonly IContentRepository _content;
        private readonly IMapper _mapper;

        public BlogController(UserManager<User> userManager, 
                              SignInManager<User> signInManager, 
                              RoleManager<IdentityRole> roleManager, 
                              MiocaDbContext context,
                              IContentRepository content,
                              IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _content = content;
            _mapper = mapper;
        }

        public IActionResult Index(int? id, int? tagId, int? year, int? month, BlogVm blogfilter, string searchData, int page = 1)
        {
            var setting = _content.GetSetting();
            var userId = _userManager.GetUserId(User);
            decimal pageItemCount = 6;
            ViewBag.UserId = userId;

            ViewBag.categoryId = id;
            IList<Blog> blogs = _context.Blogs.Include(u => u.User)
                                              .Where(b => (id != null ? b.CategoryId == id : true) &&
                                               (tagId != null ? b.TagToBlogs.Any(t => t.TagId == tagId) : true) &&
                                               (year != null ? b.AddedDate.Year == year : true) &&
                                               (month != null ? b.AddedDate.Month == month : true) &&
                                               (b.Status ))
                                               .Where(sr =>
                                               ((searchData != null ? sr.Title.Contains(searchData) : true) || 
                                               (searchData != null ? sr.Category.Name.Contains(searchData) : true)) &&
                                               (blogfilter.catId != null ? sr.CategoryId == blogfilter.catId : true))
                                                     .ToList();


            decimal b = Math.Ceiling(blogs.Count / pageItemCount);
            ViewBag.PageCount = Convert.ToInt32(b);
            ViewBag.ActivePage = page;
            ViewBag.prewPage = page - 1;
            ViewBag.nextPage = page + 1;

            List<Blog> blog = blogs.OrderBy(p => p.Id)
                                       .OrderByDescending(added => added.AddedDate)
                                        .Skip((page - 1) * (int)pageItemCount)
                                        .Take((int)pageItemCount)
                                        .ToList();
            BlogVm model = new BlogVm()
            {
                
                
                Categories = _context.BlogCategorys.Include(b => b.Blogs)
                                                   .Where(bb => bb.Blogs
                                                   .Any(s => s.Status))
                                                   .ToList(),
                Comments = _context.BlogComments.ToList(),

                Setting = _content.Getset(),

            };

            return View(model);
        }



        public IActionResult Details(int Id)
        {
           
            var UserId = _userManager.GetUserId(User);
            Blog blog = _context.Blogs.Include(c => c.User)          
                 .Include(b => b.Comments)
                .ThenInclude(c => c.User)
                .Include(b => b.TagToBlogs)
                 .ThenInclude(c => c.Tag)
                  .Include(b => b.Category)
                 
                 .FirstOrDefault(b => b.Id == Id);


            if (blog == null) return NotFound();
            BlogCommentViewModel model = new BlogCommentViewModel
            {
                Blog = blog,
                Setting = _content.Getset(),
                Categories = _context.BlogCategorys.Include(b => b.Blogs).ToList(),
                Blogs = _context.Blogs.OrderByDescending(b => b.AddedDate).Take(4).ToList()
            };



            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddComment(int Id, BlogCommentViewModel model)
        {
            var blog = await _context.Blogs.Include(c => c.User)
                .Include(c => c.Comments)
                .ThenInclude(c => c.User)

                 .FirstOrDefaultAsync(c => c.Id == Id);
            if (blog == null) return NotFound();


            if (!ModelState.IsValid)
            {
                model.Blog = blog;
                return View();
            }
            BlogComment comment = new BlogComment
            {
                Subject = model.Review.Subject,
               Mesage= model.Review.Mesage,
                UserId = _userManager.GetUserId(User),
                BlogId = Id,
                

            };

            await _context.BlogComments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { Id });
        }
    }


}

