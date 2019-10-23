using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public double sellingPrice { get; set; }
        public long description { get; set; }
        public string image { get; set; }
        public int stock { get; set; }
        public double cost { get; set; }      
        public Boolean isSellingItem { get; set; }
        public Boolean isTag { get; set; }
        public Boolean isStock { get; set; }
        public Boolean isPackage { get; set; }
        public Supplier supplier { get; set; }
        public double discount { get; set; }
        public FlowerPackage flowerPackage { get; set; }      
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public ICollection<Inventory>Inventories { get; set; }
        public ICollection<Item_ItemGroup>Item_ItemGroups { get; set; }
        public ICollection<ItemTag>ItemTags { get; set; }
        public ICollection<OrderItem>OrderItems { get; set; }
        public ICollection<ShoppingCardItem>ShoppingCardItems { get; set; }
    }
}
