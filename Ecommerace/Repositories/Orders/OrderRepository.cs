using Ecommerace.Models;

namespace Ecommerace.Repositories.Orders
{

    public class OrderRepository : IRepository<Order>
    {
        private readonly MVCECommeraceContext _context;

        public OrderRepository(MVCECommeraceContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.Find(id);
        }

        public void Create(Order entity)
        {
            _context.Orders.Add(entity);
            Save();
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
            Save();
        }

        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
