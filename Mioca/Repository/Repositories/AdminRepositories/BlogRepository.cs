using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.AdminRepositories
{
  
    public interface IBlogRepository
    {
       IEnumerable<Blog>GetBlog();
       Blog GetBlogById(int id);
    }
    public class BlogRepository : IBlogRepository
    {
        public readonly MiocaDbContext _context;

        public BlogRepository(MiocaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Blog> GetBlog()
        {
            return _context.Blogs.Include("Category")
                 .Include("User")
                 .Include("Comments")
                  .Include("Comments")
                   .Include("TagToBlogs")
                    .Include("TagToBlogs.Tag")
                    .Include("Socials")
                    .Include("Socials.Social")
                     .OrderByDescending(p => p.AddedDate)
                                      .ToList();
                    
        }

        public Blog GetBlogById(int id)
        {
           return _context.Blogs.Include("Category")
                                       .Include("User")
                                       .Include("Comments")      
                                       .Include("Comments.User")
                                       .Include("TagToBlogs")
                                       .Include("TagToBlogs.Tag")
                                       .Include("Socials")
                                       .Include("Socials.Social")
                                       .FirstOrDefault(p => p.Status && p.Id == id);
        }
    }
}
