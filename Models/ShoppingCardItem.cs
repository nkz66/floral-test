using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class ShoppingCardItem
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public int itemId { get; set; }
        public Item item { get; set; }
        public ShoppingCard ShoppingCard { get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
