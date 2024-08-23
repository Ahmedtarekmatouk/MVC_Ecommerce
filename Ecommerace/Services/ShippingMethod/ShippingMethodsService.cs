

using Ecommerace.Models;
using Ecommerace.Repositories.ShippingMethod;

namespace Ecommerace.Services.ShippingMethod;

public class ShippingMethodsService : IShippingMethodsService
{
    IShippingMethodsRepository _shippingMethodsRepository;
    public ShippingMethodsService(IShippingMethodsRepository _shippingMethodsRepository)
    {
        this._shippingMethodsRepository = _shippingMethodsRepository;
    }
    public List<ShippingMethods> GetAll()
    {
        return _shippingMethodsRepository.GetAll();
    }
    public ShippingMethods GetById(int Id)
    {
        return _shippingMethodsRepository.GetById(Id);
    }
    public void Create(ShippingMethods shippingMethods)
    {
        _shippingMethodsRepository.Create(shippingMethods);

    }
    public void Update(ShippingMethods ShippingMethods)
    {
        _shippingMethodsRepository.Update(ShippingMethods);

    }
    public void Delete(int Id)
    {
        _shippingMethodsRepository.Delete(Id);
    }

    public List<ShippingMethods> GetByName(string Name)
    {
        if(Name != null)
        return _shippingMethodsRepository.GetByName(Name);
        return _shippingMethodsRepository.GetAll();
    }
}
