using Ecommerace.Models;
using Ecommerace.Repositories;
using Ecommerace.Repositories.Product;

namespace Ecommerace.Services.Product
{
    public class SkusService : ISkusService
    {
        ISkusRepository skusRepository;
        public SkusService(ISkusRepository skusRepository)
        {
            this.skusRepository = skusRepository;
        }

        public void Create(Skus entity)
        {
            skusRepository.Create(entity);
            skusRepository.Save();
        }

        public void Delete(int id)
        {
            skusRepository.Delete(id);
            skusRepository.Save();
        }

        public List<Skus> GetAll()
        {
            return skusRepository.GetAll();
        }

        public Skus GetById(int id)
        {
            return skusRepository.GetById(id);
        }

        public void Save()
        {
            skusRepository.Save();
        }

        public void Update(Skus entity)
        {
            skusRepository.Update(entity);
            skusRepository.Save();
        }
    }
}
