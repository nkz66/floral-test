using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class OrderItem
    {
        public int ID{ get; set; }
            public int quantity{ get; set; }
            public double Price{ get; set; }
            public Item item{ get; set; }
            public Order order{ get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}
