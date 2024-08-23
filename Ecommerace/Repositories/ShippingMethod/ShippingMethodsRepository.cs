using Ecommerace.Models;

namespace Ecommerace.Repositories.ShippingMethod;

public class ShippingMethodsRepository : IShippingMethodsRepository
{
    MVCECommeraceContext context;

    public ShippingMethodsRepository(MVCECommeraceContext _context)
    {
        context = _context;
    }

    public List<ShippingMethods> GetAll()
    {
        List<ShippingMethods> ShippingMethods = context.ShippingMethods.ToList();
        return ShippingMethods;
    }
    public ShippingMethods GetById(int Id)
    {
        ShippingMethods shippingMethods = context.ShippingMethods.FirstOrDefault(p => p.Id==Id);
        return shippingMethods;
    }
    public void Create(ShippingMethods shippingMethods) 
    {
        context.Add(shippingMethods);
        Save();
    }
    public void Update(ShippingMethods ShippingMethods) 
    {
        ShippingMethods shippingMethodsData = context.ShippingMethods.FirstOrDefault(p => p.Id == ShippingMethods.Id);
        if (shippingMethodsData != null)
        {
            shippingMethodsData.Name = ShippingMethods.Name;
            shippingMethodsData.Description = ShippingMethods.Description;
            shippingMethodsData.EstimatedDeliveryTime = ShippingMethods.EstimatedDeliveryTime;
            shippingMethodsData.Cost = ShippingMethods.Cost;
            shippingMethodsData.CreatedAt = ShippingMethods.CreatedAt;
            shippingMethodsData.UpdatedAt = DateTime.Now;
            context.Update(shippingMethodsData);
            Save();

        }
    }
    public void Delete(int Id) 
    {
        ShippingMethods shippingMethods = context.ShippingMethods.FirstOrDefault(p => p.Id == Id);
        if (shippingMethods != null)
        {
            context.Remove(shippingMethods);
            Save();
        }
    }
    public void Save()
    {
        context.SaveChanges();
    }

    List<ShippingMethods> IShippingMethodsRepository.GetByName(string Search)
    {
        List<ShippingMethods> ShippingMethods = context.ShippingMethods.Where(p => p.Name.ToLower().Contains(Search.ToLower())).ToList();
        return ShippingMethods;
    }
}
