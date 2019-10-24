using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Floral.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    createTime = table.Column<DateTimeOffset>(nullable: false),
                    updateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    statusName = table.Column<string>(nullable: true),
                    inOrOut = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    campanyName = table.Column<string>(nullable: true),
                    phoneNum = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    bank = table.Column<string>(nullable: true),
                    bankAcc = table.Column<string>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    password = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowerPackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PackageTypeId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowerPackage_PackageType_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalTable: "PackageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    tagTypeId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_TagType_tagTypeId",
                        column: x => x.tagTypeId,
                        principalTable: "TagType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCard_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDeliveryAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    streetAddress = table.Column<string>(nullable: true),
                    postcode = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    recipient = table.Column<string>(nullable: true),
                    recipientPhoneNumber = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeliveryAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDeliveryAddress_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowerQuantityOrSize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isQuantity = table.Column<bool>(nullable: false),
                    isSize = table.Column<bool>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    size = table.Column<int>(nullable: false),
                    PackageId = table.Column<int>(nullable: false),
                    flowerPackageId = table.Column<int>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerQuantityOrSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowerQuantityOrSize_FlowerPackage_flowerPackageId",
                        column: x => x.flowerPackageId,
                        principalTable: "FlowerPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    sellingPrice = table.Column<decimal>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    stock = table.Column<int>(nullable: false),
                    cost = table.Column<decimal>(nullable: false),
                    discount = table.Column<decimal>(nullable: false),
                    isSellingItem = table.Column<bool>(nullable: false),
                    isTag = table.Column<bool>(nullable: false),
                    isStock = table.Column<bool>(nullable: false),
                    isPackage = table.Column<bool>(nullable: false),
                    supplierId = table.Column<int>(nullable: false),
                    packageId = table.Column<int>(nullable: false),
                    flowerPackageId = table.Column<int>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_FlowerPackage_flowerPackageId",
                        column: x => x.flowerPackageId,
                        principalTable: "FlowerPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Supplier_supplierId",
                        column: x => x.supplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    place = table.Column<string>(nullable: true),
                    recipient = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false),
                    TagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageCard_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelivery = table.Column<bool>(nullable: false),
                    deliveryPrice = table.Column<decimal>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false),
                    deliverTimeId = table.Column<int>(nullable: false),
                    userDeliveryAddressId = table.Column<int>(nullable: false),
                    driverId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_Driver_driverId",
                        column: x => x.driverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delivery_UserDeliveryAddress_userDeliveryAddressId",
                        column: x => x.userDeliveryAddressId,
                        principalTable: "UserDeliveryAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    remark = table.Column<long>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    stock = table.Column<int>(nullable: false),
                    inventoryStatusId = table.Column<int>(nullable: false),
                    itemId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryStatus_inventoryStatusId",
                        column: x => x.inventoryStatusId,
                        principalTable: "InventoryStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Item_itemId",
                        column: x => x.itemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemMmItemGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    itemId = table.Column<int>(nullable: true),
                    itemGroupId = table.Column<int>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMmItemGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemMmItemGroup_ItemGroup_itemGroupId",
                        column: x => x.itemGroupId,
                        principalTable: "ItemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemMmItemGroup_Item_itemId",
                        column: x => x.itemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    itemId = table.Column<int>(nullable: false),
                    tagId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTag_Item_itemId",
                        column: x => x.itemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTag_Tag_tagId",
                        column: x => x.tagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    itemId = table.Column<int>(nullable: false),
                    flowerPackageId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageItem_FlowerPackage_flowerPackageId",
                        column: x => x.flowerPackageId,
                        principalTable: "FlowerPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageItem_Item_itemId",
                        column: x => x.itemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCardItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<int>(nullable: false),
                    itemId = table.Column<int>(nullable: false),
                    ShoppingCardId = table.Column<int>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCardItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCardItem_ShoppingCard_ShoppingCardId",
                        column: x => x.ShoppingCardId,
                        principalTable: "ShoppingCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCardItem_Item_itemId",
                        column: x => x.itemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    totalPrice = table.Column<decimal>(nullable: false),
                    deliveryId = table.Column<int>(nullable: false),
                    messageCardId = table.Column<int>(nullable: false),
                    paymentOptionId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Delivery_deliveryId",
                        column: x => x.deliveryId,
                        principalTable: "Delivery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_MessageCard_messageCardId",
                        column: x => x.messageCardId,
                        principalTable: "MessageCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_PaymentOption_paymentOptionId",
                        column: x => x.paymentOptionId,
                        principalTable: "PaymentOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    orderId = table.Column<int>(nullable: false),
                    itemId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Item_itemId",
                        column: x => x.itemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_orderId",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_driverId",
                table: "Delivery",
                column: "driverId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_userDeliveryAddressId",
                table: "Delivery",
                column: "userDeliveryAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlowerPackage_PackageTypeId",
                table: "FlowerPackage",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerQuantityOrSize_flowerPackageId",
                table: "FlowerQuantityOrSize",
                column: "flowerPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_inventoryStatusId",
                table: "Inventory",
                column: "inventoryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_itemId",
                table: "Inventory",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_flowerPackageId",
                table: "Item",
                column: "flowerPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_supplierId",
                table: "Item",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMmItemGroup_itemGroupId",
                table: "ItemMmItemGroup",
                column: "itemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMmItemGroup_itemId",
                table: "ItemMmItemGroup",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTag_itemId",
                table: "ItemTag",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTag_tagId",
                table: "ItemTag",
                column: "tagId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageCard_TagId",
                table: "MessageCard",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_deliveryId",
                table: "Order",
                column: "deliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_messageCardId",
                table: "Order",
                column: "messageCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_paymentOptionId",
                table: "Order",
                column: "paymentOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_userId",
                table: "Order",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_itemId",
                table: "OrderItem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_orderId",
                table: "OrderItem",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageItem_flowerPackageId",
                table: "PackageItem",
                column: "flowerPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageItem_itemId",
                table: "PackageItem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCard_userId",
                table: "ShoppingCard",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCardItem_ShoppingCardId",
                table: "ShoppingCardItem",
                column: "ShoppingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCardItem_itemId",
                table: "ShoppingCardItem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_tagTypeId",
                table: "Tag",
                column: "tagTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDeliveryAddress_UserId",
                table: "UserDeliveryAddress",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryTime");

            migrationBuilder.DropTable(
                name: "FlowerQuantityOrSize");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "ItemMmItemGroup");

            migrationBuilder.DropTable(
                name: "ItemTag");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "PackageItem");

            migrationBuilder.DropTable(
                name: "ShoppingCardItem");

            migrationBuilder.DropTable(
                name: "InventoryStatus");

            migrationBuilder.DropTable(
                name: "ItemGroup");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ShoppingCard");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "MessageCard");

            migrationBuilder.DropTable(
                name: "PaymentOption");

            migrationBuilder.DropTable(
                name: "FlowerPackage");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "UserDeliveryAddress");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "PackageType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TagType");
        }
    }
}
