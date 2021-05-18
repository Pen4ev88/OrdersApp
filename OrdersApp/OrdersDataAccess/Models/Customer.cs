using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDataAccess.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
