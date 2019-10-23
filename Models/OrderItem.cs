using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public int orderId { get; set; }
        public Item item { get; set; }
        public Order order { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}
