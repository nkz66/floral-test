using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Floral.Models;//link model
using Microsoft.EntityFrameworkCore;//must use

namespace Floral.Data {

    public class FloralContext : DbContext
    {
        public FloralContext(DbContextOptions<FloralContext> options) : base(options) { }

        public DbSet<Delivery> delivery { get; set; }
        public DbSet<DeliveryTime> deliveryTime { get; set; }
        public DbSet<Driver> driver { get; set; }
        public DbSet<FlowerPackage> flowerPackage { get; set; }
        public DbSet<FlowerQuantityOrSize> flowerQuantityOrSize { get; set; }
        public DbSet<Inventory> inventory { get; set; }
        public DbSet<InventoryStatus> inventoryStatuse { get; set; }
        public DbSet<Item> item { get; set; }
        public DbSet<ItemGroup> itemGroup { get; set; }
        public DbSet<ItemMmItemGroup> itemMmItemGroup { get; set; }
        public DbSet<ItemTag> itemTag { get; set; }
        public DbSet<MessageCard> messageCard { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderItem> orderItem { get; set; }
        public DbSet<PackageItem> packageItem { get; set; }
        public DbSet<PackageType> packageType { get; set; }
        public DbSet<PaymentOption> paymentOption { get; set; }
        public DbSet<ShoppingCard> shoppingCard { get; set; }
        public DbSet<ShoppingCardItem> shoppingCardItem { get; set; }
        public DbSet<Supplier> supplier { get; set; }
        public DbSet<Tag> tag { get; set; }
        public DbSet<TagType> tagType { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<UserDeliveryAddress> userDeliveryAddresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>().ToTable("Delivery");
            modelBuilder.Entity<DeliveryTime>().ToTable("DeliveryTime");
            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<FlowerPackage>().ToTable("FlowerPackage");
            modelBuilder.Entity<FlowerQuantityOrSize>().ToTable("FlowerQuantityOrSize");
            modelBuilder.Entity<Inventory>().ToTable("Inventory");
            modelBuilder.Entity<InventoryStatus>().ToTable("InventoryStatus");
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<ItemGroup>().ToTable("ItemGroup");
            modelBuilder.Entity<ItemMmItemGroup>().ToTable("ItemMmItemGroup");
            modelBuilder.Entity<ItemTag>().ToTable("ItemTag");
            modelBuilder.Entity<MessageCard>().ToTable("MessageCard");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
            modelBuilder.Entity<PackageItem>().ToTable("PackageItem");
            modelBuilder.Entity<PackageType>().ToTable("PackageType");
            modelBuilder.Entity<PaymentOption>().ToTable("PaymentOption");
            modelBuilder.Entity<ShoppingCard>().ToTable("ShoppingCard");
            modelBuilder.Entity<ShoppingCardItem>().ToTable("ShoppingCardItem");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<TagType>().ToTable("TagType");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserDeliveryAddress>().ToTable("UserDeliveryAddress");
        }

    }

}


