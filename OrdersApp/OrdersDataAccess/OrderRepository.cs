using Microsoft.EntityFrameworkCore;
using OrdersBusinessLogic.Interfaces;
using OrdersDataAccess.Mapper;
using OrdersDataAccess.Models;
//using OrdersBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDataAccess
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext orderDbContext;

        public OrderRepository(OrderDbContext orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        public async Task<OrdersBusinessLogic.Models.Order> CreateOrder(OrdersBusinessLogic.Models.Order order)
        {
            var entity = order.ToEntity();
            orderDbContext.Add(entity);
            await orderDbContext.SaveChangesAsync();
            return entity.ToBusinessModel();
        }

        public async Task DeleteOrder(int orderId)
        {
            Order entity = await GetOrderEntity(orderId);

            orderDbContext.Orders.Remove(entity); //=> how to remove entity from DB

            await orderDbContext.SaveChangesAsync();
        }

        public async Task<List<OrdersBusinessLogic.Models.Order>> GetAllOrders()
        {
            var entities = await orderDbContext.Orders
                .ToListAsync();

            return entities.Select(e => e.ToBusinessModel()).ToList();
        }

        public async Task<bool> OrderExists(int orderId) => await orderDbContext.Orders.AnyAsync(c => c.Id == orderId);

        public async Task<Order> GetOrderEntity(int orderId)
        {
            return await orderDbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<OrdersBusinessLogic.Models.Order> GetOrder(int courseId)
        {
            var entity = await GetOrderEntity(courseId);
            return entity.ToBusinessModel();
        }
    }
}
