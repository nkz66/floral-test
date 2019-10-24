using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class Inventory
    {

        public int Id { get; set; }
        public long remark { get; set; }
        public DateTime date { get; set; }
        public int quantity { get; set; }
        public int stock { get; set; }
        public int inventoryStatusId{get;set;}
        public int itemId{get;set;}
        public Item Item { get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }


    }
}
