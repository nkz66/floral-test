using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class ShoppingCart
    {
        public int Id{ get; set; }
        public int userId{ get; set;}
        public User user{ get; set; }
        public List<ShoppingCartItem>ShoppingCartItem{ get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
