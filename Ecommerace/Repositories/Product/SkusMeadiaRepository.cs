using Ecommerace.Models;

namespace Ecommerace.Repositories.Product
{
    public class SkusMeadiaRepository : ISkuMediaRepository
    {
        MVCECommeraceContext _context;
        public SkusMeadiaRepository(MVCECommeraceContext context) 
        { 
            _context = context;
        }

        public void Create(SkuMedia entity)
        {
          _context.SkuMedia.Add(entity);
        }

        public void Delete(int id)
        {
            SkuMedia sku = GetById(id);
            _context.SkuMedia.Remove(sku);
        }

        public List<SkuMedia> GetAll()
        {
           return _context.SkuMedia.ToList();
        }

        public SkuMedia GetById(int id)
        {
            return _context.SkuMedia.FirstOrDefault(s=> s.Id==id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(SkuMedia entity)
        {
            _context.Update(entity); 
        }
    }
}
