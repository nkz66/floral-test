using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class InventoryStatus
    {
        public int Id { get; set; }
        public string statusName{ get; set; }
        public int inOrOut{ get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
        public List<Inventory>inventories{get;set;}
    }
}
