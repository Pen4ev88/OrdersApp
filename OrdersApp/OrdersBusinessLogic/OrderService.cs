using OrdersBusinessLogic.Interfaces;
using OrdersBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersBusinessLogic
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public Task<Order> CreateOrder(Order orders) => orderRepository.CreateOrder(orders);

        public Task DeleteOrder(int orderId) => orderRepository.DeleteOrder(orderId);

        public Task<List<Order>> GetAllOrders() => orderRepository.GetAllOrders();

        public Task<bool> OrderExists(int Id) => orderRepository.OrderExists(Id);
 
    }
}
