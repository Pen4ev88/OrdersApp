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
            List<OrdersBusinessLogic.Models.Order> orders = await orderService.GetAllOrders();

            int startIndex = 0;
            int endIndex = startIndex;
            while(true)
            { 
                Console.WriteLine("Enter command N, P, A or Exit!");
                string command = Console.ReadLine();

                if(command == "Exit")
                {
                    break;
                }
                
                switch (command)
                {
                    case "A":
                        {
                            startIndex = orders.IndexOf(orders.First());
                            endIndex = orders.IndexOf(orders.Last());
                            PrintOrdersds(orders, startIndex, endIndex);
                        } 
                        break;
                    case "N":
                        {
                            startIndex += 2;
                            endIndex = startIndex +1;

                            if(startIndex > (orders.IndexOf(orders.Last()) - 1) )
                            {
                                startIndex = orders.IndexOf(orders.First());
                                endIndex = startIndex + 1;
                            }
                            PrintOrdersds(orders, startIndex, endIndex);
                        }
                        break;
                    case "P":
                        {
                            endIndex = startIndex - 1;
                            startIndex -= 2;                            

                            if (startIndex < (orders.IndexOf(orders.First())))
                            {
                                startIndex = orders.IndexOf(orders.Last()) - 1;
                                endIndex = startIndex + 1;
                            }
                            PrintOrdersds(orders, startIndex, endIndex);
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private void PrintOrdersds(List<OrdersBusinessLogic.Models.Order> orders, int starIndex, int endIndex)
        {
            for (int i = starIndex; i <= endIndex; i++)
            {
                Console.WriteLine(orders.ElementAt(i).Id);
                Console.WriteLine(orders.ElementAt(i).Name);
                Console.WriteLine(orders.ElementAt(i).Price);
                Console.WriteLine(orders.ElementAt(i).Volume);
                Console.WriteLine(orders.ElementAt(i).CreatedData);
                Console.WriteLine();
            }
        }
    }
}
