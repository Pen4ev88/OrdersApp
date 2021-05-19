using OrdersBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersBusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order orders);
        Task<bool> OrderExists(int Id);
        Task<List<Order>> GetAllOrders();
        Task DeleteOrder(int orderId);
    }
}
