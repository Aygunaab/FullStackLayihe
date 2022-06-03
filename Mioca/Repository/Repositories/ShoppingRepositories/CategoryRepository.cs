using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.ShoppingRepositories
{

    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category CategoryById(int Id);
        IEnumerable<Category> Getcategory();
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MiocaDbContext _context;

        public CategoryRepository(MiocaDbContext context)
        {
            _context = context;
        }

        public Category CategoryById(int Id)
        {
            return _context.Categories.Find(Id);
        }

        public IEnumerable<Category>GetCategories()
        {
            return _context.Categories.Where(c=>c.Status).ToList();
        }

        public IEnumerable<Category> Getcategory()
        {

            return _context.Categories.ToList();
        }
    }
}
