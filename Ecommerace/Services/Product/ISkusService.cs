using Ecommerace.Models;
using Ecommerace.Repositories;

namespace Ecommerace.Services.Product
{
    public interface ISkusService : IService
    {
        List<Skus> GetAll();
        Skus GetById(int id);
        void Create(Skus entity);
        void Update(Skus entity);
        void Delete(int id);
        void Save();


    }
}
