using OrdersBusinessLogic;
using OrdersDataAccess;
using System;
using System.Threading.Tasks;

namespace OrdersApp
{
    public static class Program
    {
        public static async Task Main()
        {
            using (var context = new OrderDbContextFactory().CreateDbContext())
            {
                OrderSeeder orderSeeder = new OrderSeeder(context);
                await orderSeeder.SeedAsync();

                await new App(new OrderService(new OrderRepository(context))).Run();                
            }           
        }
    }
}
