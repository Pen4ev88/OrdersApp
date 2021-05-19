using OrdersDataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrdersDataAccess
{
    public class OrderSeeder
    {
        private readonly OrderDbContext orderDbContext;

        public OrderSeeder(OrderDbContext orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        public async Task SeedAsync()
        {
            orderDbContext.Database.EnsureCreated();

            if (!orderDbContext.Orders.Any())
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "orders.json");
                var json = File.ReadAllText(filePath);
                var orders = JsonSerializer.Deserialize<List<Order>>(json);

                orderDbContext.Orders.AddRange(orders);

                //for (int i = 0; i < orders.Count(); i++)
                //{
                //    var orderToAdd = orders.ElementAt(i);

                //    Order order = new Order()
                //    {
                //        Id = orderToAdd.Id,
                //        Name = orderToAdd.Name,
                //        Price = orderToAdd.Price,
                //        Volume = orderToAdd.Volume,
                //        CreatedData = orderToAdd.CreatedData
                //    };

                //    orderDbContext.Orders.Add(order);
                //}

                await orderDbContext.SaveChangesAsync();
            }
        }
    }
}
