using Ecommerace.Models;

namespace Ecommerace.Repositories.Product
{
    public class SkusRepository : ISkusRepository
    {
        MVCECommeraceContext _context;
        public SkusRepository(MVCECommeraceContext context)
        {
            _context = context;
        }

        public void Create(Skus entity)
        {
            _context.Add(entity);
        }

        public void Delete(int id)
        {
            Skus skus = GetById(id);
            _context.Remove(skus);
        }

        public List<Skus> GetAll()
        {
            return _context.Skus.ToList();
        }

        public Skus GetById(int id)
        {
            return _context.Skus.FirstOrDefault(s => s.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Skus entity)
        {
            Update(entity);
        }
    }
}
