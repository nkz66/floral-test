using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Floral.Models;//link model
using Microsoft.EntityFrameworkCore;//must use

namespace Floral.Data
{

    public class FloralContext : DbContext
    {
        public FloralContext(DbContextOptions<FloralContext> options) : base(options) { }

        public DbSet<Supplier> supplier { get; set; }
        public DbSet<ItemGroup> itemGroup { get; set; }
        public DbSet<InventoryStatus> inventoryStatus { get; set; }
        public DbSet<FlowerQuantityOrSize> flowerQuantityOrSize { get; set; }
        public DbSet<PackageType> packageType { get; set; }
        public DbSet<Item> item { get; set; }
        public DbSet<ItemMmItemGroup> itemMmItemGroup { get; set; }
        public DbSet<Inventory> inventory { get; set; }
        public DbSet<FlowerPackage> flowerPackage { get; set; }
        public DbSet<PackageItem> packageItem { get; set; }
        public DbSet<Driver> driver { get; set; }
        public DbSet<DeliveryTime> deliveryTime { get; set; }
        public DbSet<Delivery> delivery { get; set; }
        public DbSet<TagType> tagType { get; set; }
        public DbSet<Tag> tag { get; set; }
        public DbSet<ItemTag> itemTag { get; set; }
        public DbSet<MessageCard> messageCard { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderItem> orderItem { get; set; }
        public DbSet<PaymentOption> paymentOption { get; set; }
        public DbSet<ShoppingCart> shoppingCart { get; set; }
        public DbSet<ShoppingCartItem> shoppingCartItem { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<UserDeliveryAddress> userDeliveryAddresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //supplier
            modelBuilder.Entity<Supplier>().HasKey(s => s.Id);
            modelBuilder.Entity<Supplier>().HasIndex(s => s.campanyName);
            modelBuilder.Entity<Supplier>().Property(s => s.campanyName).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Supplier>().Property(s => s.phoneNum).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Supplier>().Property(s => s.address).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Supplier>().Property(s => s.email).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Supplier>().Property(s => s.website).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Supplier>().Property(s => s.remark).HasMaxLength(500).IsRequired(true);
            modelBuilder.Entity<Supplier>().Property(s => s.bank).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Supplier>().Property(s => s.bankAcc).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Supplier>().Property(s => s.phoneNum).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Supplier>().Property(s => s.createDateTime).IsRequired(true);
            modelBuilder.Entity<Supplier>().Property(s => s.updateDateTime).IsRequired(true);
            //modelBuilder.Entity<Supplier>().HasMany(s => s.Item);

            //item
            //modelBuilder.Entity<Item>().HasKey(i => i.Id);
            modelBuilder.Entity<Item>().HasIndex(i => i.name);
            modelBuilder.Entity<Item>().HasIndex(i => i.code);
            modelBuilder.Entity<Item>().Property(i => i.name).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.code).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.sellingPrice).HasColumnType("decimal(9,2)").IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.description).HasMaxLength(500).IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.image).HasMaxLength(500).IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.stock).IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.cost).HasColumnType("decimal(9,2)").IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.discount).HasColumnType("decimal(9,2)").IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.isSellingItem).IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.isTag).IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.isPackage).IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.isStock).IsRequired(true);
            modelBuilder.Entity<Item>().HasOne(i => i.Supplier).WithMany(s => s.Item).HasForeignKey(i => i.supplierId);
            //modelBuilder.Entity<Item>().HasOne(i => i.ShoppingCartItem).WithOne(s => s.Item).HasForeignKey<ShoppingCartItem>(c => c.itemId);
            //modelBuilder.Entity<Item>().HasOne(i => i.OrderItem).WithOne(o => o.item).HasForeignKey<OrderItem>(o => o.itemId);
            //modelBuilder.Entity<Item>().HasOne(i => i.PackageItem).WithOne(p => p.item).HasForeignKey<PackageItem>(p => p.itemId);
            //modelBuilder.Entity<Item>().HasMany(i => i.Inventory).WithOne();
            //modelBuilder.Entity<Item>().HasMany(i => i.ItemMmItemGroups);记得问
            //modelBuilder.Entity<Item>().HasMany(i => i.PackageItems).WithOne();
            //modelBuilder.Entity<Item>().HasMany(i => i.ItemTags);记得问
            //modelBuilder.Entity<Item>().HasMany(i => i.OrderItems).WithOne();
            //modelBuilder.Entity<Item>().HasMany(i => i.ShoppingCardItems).WithOne();
            modelBuilder.Entity<Item>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<Item>().Property(i => i.updateDateTime).IsRequired(true);

            //item-itemGroup
            //modelBuilder.Entity<ItemMmItemGroup>().HasKey(ig => new { ig.itemId, ig.itemGroupId });
            modelBuilder.Entity<ItemMmItemGroup>().HasOne(ig => ig.item).WithMany(i => i.ItemMmItemGroups).HasForeignKey(ig => ig.itemId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ItemMmItemGroup>().HasOne(ig => ig.itemGroup).WithMany(ig => ig.ItemMmItemGroups).HasForeignKey(ig => ig.itemGroupId);
            modelBuilder.Entity<ItemMmItemGroup>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<ItemMmItemGroup>().Property(i => i.updateDateTime).IsRequired(true);

            // 
            // modelBuilder.Entity<ItemGroup>().HasKey(ig => ig.Id);
            modelBuilder.Entity<ItemGroup>().Property(ig => ig.name).HasMaxLength(300).IsRequired(true);
            //modelBuilder.Entity<ItemGroup>().HasMany(ig => ig.ItemMmItemGroups);记得问
            modelBuilder.Entity<ItemGroup>().Property(ig => ig.createDateTime).IsRequired(true);
            modelBuilder.Entity<ItemGroup>().Property(ig => ig.updateDateTime).IsRequired(true);

            //inventory
            //modelBuilder.Entity<Inventory>().HasKey(i => i.Id);
            modelBuilder.Entity<Inventory>().Property(i => i.remark).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Inventory>().Property(i => i.quantity).IsRequired(true);
            modelBuilder.Entity<Inventory>().Property(i => i.stock).IsRequired(true);
            modelBuilder.Entity<Inventory>().HasOne(i => i.Item).WithMany(i => i.Inventory).HasForeignKey(i => i.itemId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Inventory>().HasOne(i => i.InventoryStatus).WithMany(i => i.Inventory).HasForeignKey(i => i.inventoryStatusId);
            modelBuilder.Entity<Inventory>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<Inventory>().Property(i => i.updateDateTime).IsRequired(true);


            //inventory status
            //modelBuilder.Entity<InventoryStatus>().HasKey(s => s.Id);
            modelBuilder.Entity<InventoryStatus>().Property(s => s.statusName).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<InventoryStatus>().Property(s => s.inOrOut).IsRequired(true);
            //modelBuilder.Entity<InventoryStatus>().HasMany(s => s.Inventory).WithOne();
            modelBuilder.Entity<InventoryStatus>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<InventoryStatus>().Property(i => i.updateDateTime).IsRequired(true);

            //package item
            //modelBuilder.Entity<PackageItem>().HasKey(p => p.Id);
            //modelBuilder.Entity<PackageItem>().HasOne(p => p.item).WithOne(i => i.PackageItem).HasForeignKey<PackageItem>(p => p.itemId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PackageItem>().Property(p => p.itemId).IsRequired(true);
            modelBuilder.Entity<PackageItem>().HasOne(p => p.flowerPackage).WithMany(fp => fp.packageItem).HasForeignKey(p => p.flowerPackageId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PackageItem>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<PackageItem>().Property(i => i.updateDateTime).IsRequired(true);


            //flower Package
            //modelBuilder.Entity<FlowerPackage>().HasKey(fp => fp.Id);
            modelBuilder.Entity<FlowerPackage>().HasOne(fp => fp.packageType).WithMany(pt => pt.FlowerPackage).HasForeignKey(fp => fp.PackageTypeId);
            modelBuilder.Entity<FlowerPackage>().HasOne(fp => fp.Item).WithOne(i => i.FlowerPackage).HasForeignKey<FlowerPackage>(fp=>fp.itemId);
            //modelBuilder.Entity<FlowerPackage>().HasMany(fp => fp.packageItem).WithOne();
            //modelBuilder.Entity<FlowerPackage>().HasMany(fp => fp.FlowerQuantityOrSize).WithOne();
            modelBuilder.Entity<FlowerPackage>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<FlowerPackage>().Property(i => i.updateDateTime).IsRequired(true);

            //package type
            //modelBuilder.Entity<PackageType>().HasKey(pt => pt.Id);
            modelBuilder.Entity<PackageType>().Property(pt => pt.name).HasMaxLength(300).IsRequired(true);
            //modelBuilder.Entity<PackageType>().HasMany(pt => pt.FlowerPackage).WithOne();
            modelBuilder.Entity<PackageType>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<PackageType>().Property(i => i.updateDateTime).IsRequired(true);

            //flower quantity or size
            //modelBuilder.Entity<FlowerQuantityOrSize>().HasKey(f => f.Id);
            modelBuilder.Entity<FlowerQuantityOrSize>().Property(f => f.isQuantity).IsRequired(true);
            modelBuilder.Entity<FlowerQuantityOrSize>().Property(f => f.isSize).IsRequired(true);
            modelBuilder.Entity<FlowerQuantityOrSize>().Property(f => f.quantity).IsRequired(true);
            modelBuilder.Entity<FlowerQuantityOrSize>().Property(f => f.size).IsRequired(true);
            modelBuilder.Entity<FlowerQuantityOrSize>().HasOne(f => f.FlowerPackage).WithMany(fp => fp.FlowerQuantityOrSize).HasForeignKey(f => f.PackageId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FlowerQuantityOrSize>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<FlowerQuantityOrSize>().Property(i => i.updateDateTime).IsRequired(true);

            //itemTag
            //modelBuilder.Entity<ItemTag>().HasKey(it => new { it.itemId, it.tagId });
            modelBuilder.Entity<ItemTag>().HasOne(it => it.item).WithMany(i => i.ItemTags).HasForeignKey(it => it.itemId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ItemTag>().HasOne(it => it.tag).WithMany(ig => ig.ItemTag).HasForeignKey(it => it.tagId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ItemTag>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<ItemTag>().Property(i => i.updateDateTime).IsRequired(true);

            //tag
            //modelBuilder.Entity<Tag>().HasKey(t => t.Id);
            modelBuilder.Entity<Tag>().Property(t => t.name).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Tag>().HasOne(t => t.tagType).WithMany(tt => tt.Tag).HasForeignKey(t => t.tagTypeId);
            //modelBuilder.Entity<Tag>().HasMany(t => t.ItemTag);
            //modelBuilder.Entity<Tag>().HasMany(t => t.MessageCard).WithOne();
            modelBuilder.Entity<Tag>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<Tag>().Property(i => i.updateDateTime).IsRequired(true);

            //tag type
            //modelBuilder.Entity<TagType>().HasKey(tt => tt.Id);
            modelBuilder.Entity<TagType>().Property(tt => tt.name).HasMaxLength(300).IsRequired(true);
            //modelBuilder.Entity<TagType>().HasMany(tt => tt.Tag).WithOne();
            modelBuilder.Entity<TagType>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<TagType>().Property(i => i.updateDateTime).IsRequired(true);


            //order item
            //modelBuilder.Entity<OrderItem>().HasKey(oi => oi.Id);
            modelBuilder.Entity<OrderItem>().Property(oi => oi.price).HasColumnType("decimal(9,2)").IsRequired(true);
            modelBuilder.Entity<OrderItem>().Property(oi => oi.quantity).IsRequired(true);
            modelBuilder.Entity<OrderItem>().HasOne(oi => oi.item).WithOne(i => i.OrderItem).HasForeignKey<OrderItem>(i => i.itemId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderItem>().HasOne(oi => oi.order).WithMany(o => o.OrderItem).HasForeignKey(oi => oi.orderId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderItem>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<OrderItem>().Property(i => i.updateDateTime).IsRequired(true);

            //order
            //modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().Property(o => o.totalPrice).HasColumnType("decimal(9,2)").IsRequired(true);
            modelBuilder.Entity<Order>().Property(o => o.orderStatus).IsRequired(true);
            modelBuilder.Entity<Order>().HasOne(o => o.user).WithMany(u => u.Order).HasForeignKey(o => o.userId);
            //modelBuilder.Entity<Order>().HasOne(o => o.delivery).WithOne(d => d.Order).HasForeignKey<Order>(o => o.deliveryId);
            //modelBuilder.Entity<Order>().HasOne(o => o.messageCard).WithOne(mc => mc.Order).HasForeignKey<Order>(o => o.messageCardId);
            //modelBuilder.Entity<Order>().HasOne(o => o.paymentOption).WithOne(po => po.Order).HasForeignKey<Order>(o => o.paymentOptionId);
            //modelBuilder.Entity<Order>().HasMany(o => o.OrderItem).WithOne();
            modelBuilder.Entity<Order>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<Order>().Property(i => i.updateDateTime).IsRequired(true);


            //message card
            //modelBuilder.Entity<MessageCard>().HasKey(m => m.Id);
            modelBuilder.Entity<MessageCard>().Property(m => m.place).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<MessageCard>().Property(m => m.recipient).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<MessageCard>().Property(m => m.message).HasMaxLength(500).IsRequired(true);
            modelBuilder.Entity<MessageCard>().HasOne(m => m.Order).WithOne(o => o.messageCard).HasForeignKey<MessageCard>(m=>m.orderId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MessageCard>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<MessageCard>().Property(i => i.updateDateTime).IsRequired(true);

            //shopping card item
            //modelBuilder.Entity<ShoppingCartItem>().HasKey(s => s.Id);
            modelBuilder.Entity<ShoppingCartItem>().Property(s => s.quantity).IsRequired(true);
            modelBuilder.Entity<ShoppingCartItem>().HasOne(s => s.Item).WithOne(i => i.ShoppingCartItem).HasForeignKey<ShoppingCartItem>(s => s.itemId);
            modelBuilder.Entity<ShoppingCartItem>().HasOne(s => s.ShoppingCart).WithMany(sc => sc.ShoppingCartItem).HasForeignKey(s => s.shoppingCartId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ShoppingCartItem>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<ShoppingCartItem>().Property(i => i.updateDateTime).IsRequired(true);

            //shopping cart
            //modelBuilder.Entity<ShoppingCart>().HasKey(s => s.Id);
            modelBuilder.Entity<ShoppingCart>().HasOne(s => s.user).WithMany(u => u.ShoppingCart).HasForeignKey(s => s.userId);
            //modelBuilder.Entity<ShoppingCart>().HasMany(s => s.ShoppingCartItem).WithOne();
            modelBuilder.Entity<ShoppingCart>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<ShoppingCart>().Property(i => i.updateDateTime).IsRequired(true);

            //delivery
            //modelBuilder.Entity<Delivery>().HasKey(d => d.Id);
            modelBuilder.Entity<Delivery>().Property(d => d.isDelivery).IsRequired(true);
            modelBuilder.Entity<Delivery>().Property(d => d.deliveryPrice).HasColumnType("decimal(9,2)").IsRequired(true);
            modelBuilder.Entity<Delivery>().Property(d => d.deliveryTime).IsRequired(true);
            modelBuilder.Entity<Delivery>().Property(d => d.streetAddress).HasMaxLength(700).IsRequired(true);
            modelBuilder.Entity<Delivery>().Property(d => d.postcode).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Delivery>().Property(d => d.city).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Delivery>().Property(d => d.state).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Delivery>().Property(d => d.recipient).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Delivery>().Property(d => d.recipientPhoneNumber).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Delivery>().HasOne(d => d.Order).WithOne(o => o.delivery).HasForeignKey<Delivery>(o => o.orderId).OnDelete(DeleteBehavior.Cascade);//ask
            //modelBuilder.Entity<Delivery>().HasOne(d => d.userDeliveryAddress).WithOne(ud => ud.Delivery).HasForeignKey<Delivery>(d => d.userDeliveryAddressId);
            modelBuilder.Entity<Delivery>().HasOne(d => d.Driver).WithMany(d => d.Delivery).HasForeignKey(d => d.driverId);
            modelBuilder.Entity<Delivery>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<Delivery>().Property(i => i.updateDateTime).IsRequired(true);

            //payment option
            //modelBuilder.Entity<PaymentOption>().HasKey(p => p.Id);
            modelBuilder.Entity<PaymentOption>().Property(p => p.name).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<PaymentOption>().HasOne(p => p.Order).WithOne(o => o.paymentOption).HasForeignKey<PaymentOption>(p => p.orderId).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<PaymentOption>().HasOne(p => p.Order).WithOne(o => o.paymentOption).HasForeignKey<Order>(o => o.paymentOptionId);
            modelBuilder.Entity<PaymentOption>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<PaymentOption>().Property(i => i.updateDateTime).IsRequired(true);

            //driver
            //modelBuilder.Entity<Driver>().HasKey(d => d.Id);
            modelBuilder.Entity<Driver>().Property(d => d.name).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Driver>().Property(d => d.password).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Driver>().Property(d => d.email).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<Driver>().Property(d => d.phoneNumber).HasMaxLength(300).IsRequired(true);
            //modelBuilder.Entity<Driver>().HasMany(d => d.Delivery).WithOne();
            modelBuilder.Entity<Driver>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<Driver>().Property(i => i.updateDateTime).IsRequired(true);

            //delivery time
            //modelBuilder.Entity<DeliveryTime>().HasKey(d => d.Id);
            modelBuilder.Entity<DeliveryTime>().Property(d => d.name).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<DeliveryTime>().Property(d => d.price).HasColumnType("decimal(9,2)").IsRequired(true);
            modelBuilder.Entity<DeliveryTime>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<DeliveryTime>().Property(i => i.updateDateTime).IsRequired(true);

            //delivery address
            //modelBuilder.Entity<UserDeliveryAddress>().HasKey(ud => ud.Id);
            modelBuilder.Entity<UserDeliveryAddress>().Property(ud => ud.streetAddress).HasMaxLength(700).IsRequired(true);
            modelBuilder.Entity<UserDeliveryAddress>().Property(ud => ud.postcode).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<UserDeliveryAddress>().Property(ud => ud.city).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<UserDeliveryAddress>().Property(ud => ud.state).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<UserDeliveryAddress>().Property(ud => ud.recipient).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<UserDeliveryAddress>().Property(ud => ud.recipientPhoneNumber).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<UserDeliveryAddress>().HasOne(ud => ud.User).WithMany(u => u.UserDeliveryAddress).HasForeignKey(ud => ud.UserId);
            //modelBuilder.Entity<UserDeliveryAddress>().HasOne(ud => ud.Delivery).WithOne(d => d.userDeliveryAddress).HasForeignKey<Delivery>(d => d.userDeliveryAddressId);
            modelBuilder.Entity<UserDeliveryAddress>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<UserDeliveryAddress>().Property(i => i.updateDateTime).IsRequired(true);


            //user
            //modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasIndex(u => u.name);
            modelBuilder.Entity<User>().Property(u => u.password).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<User>().Property(u => u.name).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<User>().Property(u => u.email).HasMaxLength(300).IsRequired(true);
            modelBuilder.Entity<User>().Property(u => u.phoneNumber).HasMaxLength(300).IsRequired(true);
            //modelBuilder.Entity<User>().HasMany(u => u.UserDeliveryAddress).WithOne();
            //modelBuilder.Entity<User>().HasMany(u => u.Order).WithOne();
            //modelBuilder.Entity<User>().HasMany(u => u.ShoppingCart).WithOne();
            modelBuilder.Entity<User>().Property(i => i.createDateTime).IsRequired(true);
            modelBuilder.Entity<User>().Property(i => i.updateDateTime).IsRequired(true);

        }
    }
}


