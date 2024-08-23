using Ecommerace.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace Ecommerace.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        MVCECommeraceContext _context;

        public CategoryRepository(MVCECommeraceContext context)
        {
            _context = context;
        }
        public void Create(Category entity)
        {
            _context.Categories.Add(entity);
        }

        public void Delete(int id)
        {
            var ctgry = GetById(id);
            _context.Categories.Remove(ctgry);
        }
       

        public List<Category> GetAll(int page = 1, int pageSize = 10, string search = "")
        {
            //return _context.Categories.Where(c => c.Parent_Id == null).Include(c => c.SubCategories).ToList();
            var categories = _context.Categories
                .Where(c => c.Name.ToLower().Contains(search.ToLower()))
                .Take(pageSize)
                .Skip((page - 1) * pageSize) 
                .ToList();
            return categories;
        }

        public List<Category> GetAll()
        {
            var categories = _context.Categories
                .Take(10)
                .ToList();
            return categories;
        }

        public Category GetById(int id)
        {
            return _context.Categories.Include(c => c.SubCategories)
                                  .FirstOrDefault(c => c.Id == id);
        }

        public List<Category> GetCategoryTree()
        {
            return _context.Categories.Where(c => c.Parent_Id == null).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category entity)
        {
            _context.Update(entity);
        }
        
    }
}
