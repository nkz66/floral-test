using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class ShoppingCard
    {
        public int ID{ get; set; }
        public User user{ get; set; }
        public ICollection<ShoppingCardItem>shoppingCardItems{ get; set; }
         public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}
