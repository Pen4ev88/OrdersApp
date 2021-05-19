using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersBusinessLogic.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public DateTime CreatedData { get; set; }
    }
}
