using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class ShoppingCard
    {
        public int Id{ get; set; }
        public int userId{ get; set;}
        public User user{ get; set; }
        public List<ShoppingCardItem>ShoppingCardItems{ get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
