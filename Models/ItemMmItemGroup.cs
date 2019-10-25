using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class ItemMmItemGroup
    {
        public int Id { get; set; }
        public Item item { get; set; }
        public int itemId { get; set; }
        public ItemGroup itemGroup { get; set; }
        public int itemGroupId { get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
