using OrdersDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDataAccess.Mapper
{
    public static class OrderMapper
    {

        public static OrdersBusinessLogic.Models.Order ToBusinessModel(this Order order)
        {
            var model = new OrdersBusinessLogic.Models.Order
            {
                Id = order.Id,
                Name = order.Name,
                Price = order.Price,
                Volume = order.Volume,
                CreatedData = order.CreatedData
            };

            return model;
       }
        public static Order ToEntity(this OrdersBusinessLogic.Models.Order order)
        {
            var entity = new Order
            {
                Id = order.Id,
                Name = order.Name,
                Price = order.Price,
                Volume = order.Volume,
                CreatedData = order.CreatedData
            };

            return entity;
       }        
    }
}
