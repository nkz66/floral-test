using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public decimal sellingPrice { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int stock { get; set; }
        public decimal cost { get; set; }
        public decimal discount { get; set; }
        public bool isSellingItem { get; set; }
        public bool isTag { get; set; }
        public bool isStock { get; set; }
        public bool isPackage { get; set; }
        public int supplierId { get; set; }
        public int packageId { get; set; }
        public Supplier supplier { get; set; }
        public FlowerPackage flowerPackage { get; set; }
        public List<Inventory> Inventories { get; set; }
        public List<ItemMmItemGroup> ItemMmItemGroups { get; set; }
        public List<PackageItem> packageItems { get; set; }
        public List<ItemTag> itemTags { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public List<ShoppingCardItem> shoppingCardItems { get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
        
    }
}