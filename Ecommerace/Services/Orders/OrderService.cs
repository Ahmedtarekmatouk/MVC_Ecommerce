using Ecommerace.Models;
using Ecommerace.Repositories;
using System.Collections.Generic;

namespace Ecommerace.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Create(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }
    }
}
