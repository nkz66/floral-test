using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class ItemGroup
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<ItemMmItemGroup>Item_ItemGroups { get; set; }
    }
}
