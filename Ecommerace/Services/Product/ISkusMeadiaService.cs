using Ecommerace.Models;

namespace Ecommerace.Services.Product
{
    public interface ISkusMeadiaService:IService
    {
        List<SkuMedia> GetAll();
        SkuMedia GetById(int id);
        void Create(SkuMedia entity);
        void Update(SkuMedia entity);
        void Delete(int id);
        void Save();
    }
}
