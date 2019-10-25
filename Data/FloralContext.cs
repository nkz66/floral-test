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
        public DbSet<InventoryStatus> inventoryStatus { get; set; }
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
        public DbSet<ShoppingCart> shoppingCart { get; set; }
        public DbSet<ShoppingCartItem> shoppingCartItem { get; set; }
        public DbSet<Supplier> supplier { get; set; }
        public DbSet<Tag> tag { get; set; }
        public DbSet<TagType> tagType { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<UserDeliveryAddress> userDeliveryAddresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //supplier
            modelBuilder.Entity<Supplier>().HasKey(s => s.Id);
            modelBuilder.Entity<Supplier>().HasIndex(s => s.campanyName).IsUnique();
            modelBuilder.Entity<Supplier>().HasMany(s => s.Item);
            modelBuilder.Entity<Supplier>().Property(s => s.phoneNum).HasMaxLength(500);
            modelBuilder.Entity<Supplier>().Property(s => s.address).HasMaxLength(500);
            modelBuilder.Entity<Supplier>().Property(s => s.email).HasMaxLength(500);
            modelBuilder.Entity<Supplier>().Property(s => s.website).HasMaxLength(500);
            modelBuilder.Entity<Supplier>().Property(s => s.remark).HasMaxLength(700);
            modelBuilder.Entity<Supplier>().Property(s => s.bank).HasMaxLength(500);
            modelBuilder.Entity<Supplier>().Property(s => s.bankAcc).HasMaxLength(500);
            modelBuilder.Entity<Supplier>().Property(s => s.phoneNum).HasMaxLength(500);
            modelBuilder.Entity<Supplier>().Property(s => s.createDateTime).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.updateDateTime).HasMaxLength(500).IsRequired();

            //item
            modelBuilder.Entity<Item>().HasKey(i => i.Id);
            modelBuilder.Entity<Item>().HasIndex(i => new { i.name, i.code });
            modelBuilder.Entity<Item>().Property(i => i.name).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.code).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.sellingPrice).HasMaxLength(300);
            modelBuilder.Entity<Item>().Property(i => i.description).HasMaxLength(500);
            modelBuilder.Entity<Item>().Property(i => i.image).HasMaxLength(500);
            modelBuilder.Entity<Item>().Property(i => i.stock).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.cost).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.discount).HasMaxLength(500);
            modelBuilder.Entity<Item>().Property(i => i.isSellingItem).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.isTag).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.isPackage).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.isStock).IsRequired();
            modelBuilder.Entity<Item>().HasOne(i => i.Supplier).WithMany(s => s.Item).HasForeignKey(i => i.supplierId);
            modelBuilder.Entity<Item>().HasOne(i => i.FlowerPackage).WithOne(p => p.Item).HasForeignKey<Item>(i => i.packageId);
            modelBuilder.Entity<Item>().HasOne(i => i.ShoppingCartItem).WithOne(s => s.Item).HasForeignKey<ShoppingCartItem>(c => c.itemId);
            modelBuilder.Entity<Item>().HasOne(i => i.OrderItem).WithOne(o => o.item).HasForeignKey<OrderItem>(o => o.itemId);
            modelBuilder.Entity<Item>().HasOne(i => i.PackageItem).WithOne(p => p.item).HasForeignKey<PackageItem>(p => p.itemId);
            modelBuilder.Entity<Item>().HasMany(i => i.Inventory).WithOne();
            //modelBuilder.Entity<Item>().HasMany(i => i.ItemMmItemGroups);记得问
            modelBuilder.Entity<Item>().HasMany(i => i.PackageItems).WithOne();
            // modelBuilder.Entity<Item>().HasMany(i => i.ItemTags);记得问
            modelBuilder.Entity<Item>().HasMany(i => i.OrderItems).WithOne();
            modelBuilder.Entity<Item>().HasMany(i => i.ShoppingCardItems).WithOne();
            modelBuilder.Entity<Item>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.updateDateTime).IsRequired();

            //item-itemGroup
            modelBuilder.Entity<ItemMmItemGroup>().HasKey(ig => new { ig.itemId, ig.itemGroupId });
            modelBuilder.Entity<ItemMmItemGroup>().HasOne(ig => ig.item).WithMany(i => i.ItemMmItemGroups).HasForeignKey(ig => ig.itemId);
            modelBuilder.Entity<ItemMmItemGroup>().HasOne(ig => ig.itemGroup).WithMany(ig => ig.ItemMmItemGroups).HasForeignKey(ig => ig.itemGroupId);
            modelBuilder.Entity<ItemMmItemGroup>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<ItemMmItemGroup>().Property(i => i.updateDateTime).IsRequired();

            //itemGroup
            modelBuilder.Entity<ItemGroup>().HasKey(ig => ig.Id);
            modelBuilder.Entity<ItemGroup>().Property(ig => ig.name).HasMaxLength(500).IsRequired();
            //modelBuilder.Entity<ItemGroup>().HasMany(ig => ig.ItemMmItemGroups);记得问
            modelBuilder.Entity<ItemGroup>().Property(ig => ig.createDateTime).IsRequired();
            modelBuilder.Entity<ItemGroup>().Property(ig => ig.updateDateTime).IsRequired();

            //inventory
            modelBuilder.Entity<Inventory>().HasKey(i => i.Id);
            modelBuilder.Entity<Inventory>().Property(i => i.remark).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<Inventory>().Property(i => i.quantity).IsRequired();
            modelBuilder.Entity<Inventory>().Property(i => i.stock).IsRequired();
            modelBuilder.Entity<Inventory>().HasOne(i => i.Item).WithMany(i => i.Inventory).HasForeignKey(i => i.itemId);
            modelBuilder.Entity<Inventory>().HasOne(i => i.InventoryStatus).WithMany(i => i.Inventory).HasForeignKey(i => i.inventoryStatusId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Inventory>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<Inventory>().Property(i => i.updateDateTime).IsRequired();


            //inventory status
            modelBuilder.Entity<InventoryStatus>().HasKey(s => s.Id);
            modelBuilder.Entity<InventoryStatus>().Property(s => s.statusName).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<InventoryStatus>().Property(s => s.inOrOut).IsRequired();
            modelBuilder.Entity<InventoryStatus>().HasMany(s => s.Inventory).WithOne();
            modelBuilder.Entity<InventoryStatus>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<InventoryStatus>().Property(i => i.updateDateTime).IsRequired();

            //package item
            modelBuilder.Entity<PackageItem>().HasKey(p => p.Id);
            // modelBuilder.Entity<PackageItem>().HasOne(p=>p.item).WithOne(i=>i.PackageItem).HasForeignKey<Item>(I=>I.)记得问
            modelBuilder.Entity<PackageItem>().HasOne(p => p.flowerPackage).WithMany(fp => fp.packageItem).HasForeignKey(p => p.flowerPackageId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PackageItem>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<PackageItem>().Property(i => i.updateDateTime).IsRequired();


            //flower Package
            modelBuilder.Entity<FlowerPackage>().HasKey(fp => fp.Id);
            modelBuilder.Entity<FlowerPackage>().HasOne(fp => fp.packageType).WithMany(pt => pt.FlowerPackage).HasForeignKey(fp => fp.PackageTypeId);
            modelBuilder.Entity<FlowerPackage>().HasOne(fp => fp.Item).WithOne(i => i.FlowerPackage).HasForeignKey<Item>(i => i.packageId);
            modelBuilder.Entity<FlowerPackage>().HasMany(fp => fp.packageItem).WithOne();
            modelBuilder.Entity<FlowerPackage>().HasMany(fp => fp.FlowerQuantityOrSize).WithOne();
            modelBuilder.Entity<FlowerPackage>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<FlowerPackage>().Property(i => i.updateDateTime).IsRequired();

            //packageItem type
            modelBuilder.Entity<PackageType>().HasKey(pt => pt.Id);
            modelBuilder.Entity<PackageType>().Property(pt => pt.name).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<PackageType>().HasMany(pt => pt.FlowerPackage).WithOne();
            modelBuilder.Entity<PackageType>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<PackageType>().Property(i => i.updateDateTime).IsRequired();

            //flower quantity or size
            modelBuilder.Entity<FlowerQuantityOrSize>().HasKey(f => f.Id);
            modelBuilder.Entity<FlowerQuantityOrSize>().Property(f => new { f.isQuantity, f.isSize, f.quantity, f.size }).IsRequired();
            modelBuilder.Entity<FlowerQuantityOrSize>().HasOne(f => f.FlowerPackage).WithMany(fp => fp.FlowerQuantityOrSize).HasForeignKey(f => f.PackageId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FlowerQuantityOrSize>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<FlowerQuantityOrSize>().Property(i => i.updateDateTime).IsRequired();

            //itemTag
            modelBuilder.Entity<ItemTag>().HasKey(it => new { it.itemId, it.tagId });
            modelBuilder.Entity<ItemTag>().HasOne(it => it.item).WithMany(i => i.ItemTags).HasForeignKey(it => it.itemId);
            modelBuilder.Entity<ItemTag>().HasOne(it => it.tag).WithMany(ig => ig.ItemTag).HasForeignKey(it => it.tagId);
            modelBuilder.Entity<ItemTag>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<ItemTag>().Property(i => i.updateDateTime).IsRequired();

            //tag
            modelBuilder.Entity<Tag>().HasKey(t => t.Id);
            modelBuilder.Entity<Tag>().Property(t => t.name).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<Tag>().HasOne(t => t.tagType).WithMany(tt => tt.Tag).HasForeignKey(t => t.tagTypeId);
            //modelBuilder.Entity<Tag>().HasMany(t => t.ItemTag);
            //modelBuilder.Entity<Tag>().HasMany(t => t.MessageCard).WithOne();
            modelBuilder.Entity<Tag>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<Tag>().Property(i => i.updateDateTime).IsRequired();

            //tag type
            modelBuilder.Entity<TagType>().HasKey(tt => tt.Id);
            modelBuilder.Entity<TagType>().Property(tt => tt.name).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<TagType>().HasMany(tt => tt.Tag).WithOne();
            modelBuilder.Entity<TagType>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<TagType>().Property(i => i.updateDateTime).IsRequired();


            //order item
            modelBuilder.Entity<OrderItem>().HasKey(oi => oi.Id);
            modelBuilder.Entity<OrderItem>().Property(oi => new { oi.quantity, oi.price }).IsRequired();
            //modelBuilder.Entity<OrderItem>().HasOne(oi=>oi.item).WithOne(i=>i.OrderItem).HasForeignKey<>
            modelBuilder.Entity<OrderItem>().HasOne(oi => oi.order).WithMany(o => o.OrderItem).HasForeignKey(oi => oi.orderId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderItem>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<OrderItem>().Property(i => i.updateDateTime).IsRequired();

            //order
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().Property(o => o.totalPrice).IsRequired();
            modelBuilder.Entity<Order>().HasOne(o => o.user).WithMany(u => u.Order).HasForeignKey(o => o.userId);
            modelBuilder.Entity<Order>().HasOne(o => o.delivery).WithOne(d => d.Order).HasForeignKey<Order>(o => o.deliveryId);
            modelBuilder.Entity<Order>().HasOne(o => o.messageCard).WithOne(mc => mc.Order).HasForeignKey<Order>(o => o.messageCardId);
            modelBuilder.Entity<Order>().HasOne(o => o.paymentOption).WithOne(po => po.Order).HasForeignKey<Order>(o => o.paymentOptionId);
            modelBuilder.Entity<Order>().HasMany(o => o.OrderItem).WithOne();
            modelBuilder.Entity<Order>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<Order>().Property(i => i.updateDateTime).IsRequired();

            //message card
            modelBuilder.Entity<MessageCard>().HasKey(m => m.Id);
            modelBuilder.Entity<MessageCard>().Property(m => new { m.place, m.recipient }).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<MessageCard>().Property(m => m.message).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<MessageCard>().HasOne(m => m.Order).WithOne(o => o.messageCard).HasForeignKey<Order>(o => o.messageCardId);
            modelBuilder.Entity<MessageCard>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<MessageCard>().Property(i => i.updateDateTime).IsRequired();

            //shopping card item
            modelBuilder.Entity<ShoppingCartItem>().HasKey(s => s.Id);
            modelBuilder.Entity<ShoppingCartItem>().Property(s => s.quantity).IsRequired();
            modelBuilder.Entity<ShoppingCartItem>().HasOne(s => s.Item).WithOne(i => i.ShoppingCartItem).HasForeignKey<ShoppingCartItem>(s => s.itemId);
            modelBuilder.Entity<ShoppingCartItem>().HasOne(s => s.ShoppingCart).WithMany(sc => sc.ShoppingCartItem).HasForeignKey(s => s.shoppingCartId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ShoppingCartItem>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<ShoppingCartItem>().Property(i => i.updateDateTime).IsRequired();

            //shopping cart
            modelBuilder.Entity<ShoppingCart>().HasKey(s => s.Id);
            modelBuilder.Entity<ShoppingCart>().HasOne(s => s.user).WithMany(u => u.ShoppingCart).HasForeignKey(s => s.userId);
            modelBuilder.Entity<ShoppingCart>().HasMany(s => s.ShoppingCartItem).WithOne();
            modelBuilder.Entity<ShoppingCart>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<ShoppingCart>().Property(i => i.updateDateTime).IsRequired();

            //delivery
            modelBuilder.Entity<Delivery>().HasKey(d => d.Id);
            modelBuilder.Entity<Delivery>().Property(d => new { d.isDelivery,d.deliveryPrice,d.deliveryTime }).IsRequired();
            modelBuilder.Entity<Delivery>().HasOne(d => d.Order).WithOne(o => o.delivery).HasForeignKey<Order>(o => o.deliveryId).OnDelete(DeleteBehavior.Cascade);//ask
            modelBuilder.Entity<Delivery>().HasOne(d => d.userDeliveryAddress).WithOne(ud => ud.Delivery).HasForeignKey<Delivery>(d => d.userDeliveryAddressId);
            modelBuilder.Entity<Delivery>().HasOne(d => d.Driver).WithMany(d => d.Delivery).HasForeignKey(d => d.driverId);
            modelBuilder.Entity<Delivery>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<Delivery>().Property(i => i.updateDateTime).IsRequired();

            //payment option
            modelBuilder.Entity<PaymentOption>().HasKey(p => p.Id);
            modelBuilder.Entity<PaymentOption>().Property(p=>p.name).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<PaymentOption>().HasOne(p => p.Order).WithOne(o => o.paymentOption).HasForeignKey<Order>(o => o.paymentOptionId);
            modelBuilder.Entity<PaymentOption>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<PaymentOption>().Property(i => i.updateDateTime).IsRequired();

            //driver
            modelBuilder.Entity<Driver>().HasKey(d => d.Id);
            modelBuilder.Entity<Driver>().Property(d => new { d.name, d.password, d.email ,d.phoneNumber}).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<Driver>().HasMany(d => d.Delivery).WithOne();
            modelBuilder.Entity<Driver>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<Driver>().Property(i => i.updateDateTime).IsRequired();

            //delivery time
            modelBuilder.Entity<DeliveryTime>().HasKey(d => d.Id);
            modelBuilder.Entity<DeliveryTime>().Property(d => d.name).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<DeliveryTime>().Property(d => d.price).IsRequired();
            modelBuilder.Entity<DeliveryTime>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<DeliveryTime>().Property(i => i.updateDateTime).IsRequired();

            //delivery address
            modelBuilder.Entity<UserDeliveryAddress>().HasKey(ud => ud.Id);
            modelBuilder.Entity<UserDeliveryAddress>().Property(ud => new { ud.streetAddress, ud.postcode, ud.city, ud.state, ud.recipient, ud.recipientPhoneNumber }).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<UserDeliveryAddress>().HasOne(ud => ud.User).WithMany(u => u.UserDeliveryAddress).HasForeignKey(ud => ud.UserId);
            modelBuilder.Entity<UserDeliveryAddress>().HasOne(ud => ud.Delivery).WithOne(d => d.userDeliveryAddress).HasForeignKey<Delivery>(d => d.userDeliveryAddressId);
            modelBuilder.Entity<UserDeliveryAddress>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<UserDeliveryAddress>().Property(i => i.updateDateTime).IsRequired();


            //user
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => new { u.password, u.name, u.email, u.phoneNumber }).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<User>().HasMany(u => u.UserDeliveryAddress).WithOne();
            modelBuilder.Entity<User>().HasMany(u => u.Order).WithOne();
            modelBuilder.Entity<User>().HasMany(u => u.ShoppingCart).WithOne();
            modelBuilder.Entity<User>().Property(i => i.createDateTime).IsRequired();
            modelBuilder.Entity<User>().Property(i => i.updateDateTime).IsRequired();

        }
    }
}


