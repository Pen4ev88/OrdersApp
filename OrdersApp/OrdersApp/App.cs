using OrdersBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp
{
    public class App
    {
        private readonly IOrderService orderService;

        public App(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task Run()
        {
            var orders = await orderService.GetAllOrders();

            while(true)
            {
                Console.WriteLine("Enter command N / P / A or Exit!");
                string command = Console.ReadLine();

                if(command == "Exit")
                {
                    break;
                }

                else
                {

                }
            }
        }
    }
}
