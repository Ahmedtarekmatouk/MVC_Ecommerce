using Ecommerace.Models;

namespace Ecommerace.Services.ShippingMethod
{
    public interface IShippingMethodsService : IService
    {
        List<ShippingMethods> GetAll();
        ShippingMethods GetById(int id);
        void Create(ShippingMethods entity);
        void Update(ShippingMethods entity);
        void Delete(int id);
        List<ShippingMethods> GetByName(string Name);
    }
}
