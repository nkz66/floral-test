using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public int itemId { get; set; }
        public int shoppingCartId { get; set; }
        public Item Item { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
