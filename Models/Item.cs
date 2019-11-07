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
        public Supplier Supplier { get; set; }
        public FlowerPackage FlowerPackage { get; set; }
        //one to one
        public ShoppingCartItem ShoppingCartItem { get; set; }
        public OrderItem OrderItem { get; set; }
        //public PackageItem PackageItem { get; set; }
       // public ItemTag itemTag { get; set; }
        //one to many
        public List<Inventory> Inventory { get; set; }
        public List<ItemMmItemGroup> ItemMmItemGroups { get; set; }
        public List<ItemTag> ItemTags { get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
        
    }
}