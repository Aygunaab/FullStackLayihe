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
        void CreateCategory(Category cat);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
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

        public void CreateCategory(Category cat)
        {
             _context.Categories.Add(cat);
            _context.SaveChanges();

           
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category>GetCategories()
        {
            return _context.Categories.Where(c=>c.Status).ToList();
        }

        public IEnumerable<Category> Getcategory()
        {

            return _context.Categories.ToList();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
             _context.SaveChanges();
        }
    }
}
