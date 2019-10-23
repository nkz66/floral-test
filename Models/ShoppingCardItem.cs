using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class ShoppingCardItem
    {
        public int ID { get; set; }
        public int quantity { get; set; }
        public Item item { get; set; }
        public ShoppingCard ShoppingCard { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}
