using Ecommerace.Models;

namespace Ecommerace.Repositories.Product
{
    public class ProductsRepository : IProductsRepository
    {
        MVCECommeraceContext _context;
        public ProductsRepository(MVCECommeraceContext context)
        {
            _context = context;
        }

        public void Create(Products entity)
        {
            _context.Add(entity);
        }

        public void Delete(int id)
        {
            Products products = GetById(id);
            _context.Remove(products);
        }

        public Products GetById(int id)
        {
            return _context.Products.FirstOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Products entity)
        {
            _context.Update(entity);

        }

        public List<Products> GetAll()
        {
            return _context.Products.ToList();
        }
    }
}
