

using Ecommerace.Models;

namespace Ecommerace.Repositories.ShippingMethod;

public interface IShippingMethodsRepository : IRepository<ShippingMethods>
{
    List<ShippingMethods> GetByName(string Name);
}

