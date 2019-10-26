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
                name: "deliveryTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 300, nullable: false),
                    price = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "driver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 300, nullable: false),
                    password = table.Column<string>(maxLength: 300, nullable: false),
                    email = table.Column<string>(maxLength: 300, nullable: false),
                    phoneNumber = table.Column<string>(maxLength: 300, nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "inventoryStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    statusName = table.Column<string>(maxLength: 300, nullable: false),
                    inOrOut = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventoryStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "itemGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 300, nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "packageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 300, nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    campanyName = table.Column<string>(maxLength: 300, nullable: false),
                    phoneNum = table.Column<string>(maxLength: 300, nullable: false),
                    address = table.Column<string>(maxLength: 300, nullable: false),
                    email = table.Column<string>(maxLength: 300, nullable: false),
                    website = table.Column<string>(maxLength: 300, nullable: false),
                    remark = table.Column<string>(maxLength: 500, nullable: false),
                    bank = table.Column<string>(maxLength: 300, nullable: false),
                    bankAcc = table.Column<string>(maxLength: 300, nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tagType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 300, nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tagType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    password = table.Column<string>(maxLength: 300, nullable: false),
                    name = table.Column<string>(maxLength: 300, nullable: false),
                    email = table.Column<string>(maxLength: 300, nullable: false),
                    phoneNumber = table.Column<string>(maxLength: 300, nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "flowerPackage",
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
                    table.PrimaryKey("PK_flowerPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flowerPackage_packageType_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalTable: "packageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 300, nullable: false),
                    tagTypeId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tag_tagType_tagTypeId",
                        column: x => x.tagTypeId,
                        principalTable: "tagType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    totalPrice = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    userId = table.Column<int>(nullable: false),
                    orderStatus = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shoppingCart",
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
                    table.PrimaryKey("PK_shoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingCart_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "flowerQuantityOrSize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isQuantity = table.Column<bool>(nullable: false),
                    isSize = table.Column<bool>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    size = table.Column<int>(nullable: false),
                    PackageId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flowerQuantityOrSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flowerQuantityOrSize_flowerPackage_PackageId",
                        column: x => x.PackageId,
                        principalTable: "flowerPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 300, nullable: false),
                    code = table.Column<string>(maxLength: 300, nullable: false),
                    sellingPrice = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    description = table.Column<string>(maxLength: 500, nullable: false),
                    image = table.Column<string>(maxLength: 500, nullable: false),
                    stock = table.Column<int>(nullable: false),
                    cost = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    isSellingItem = table.Column<bool>(nullable: false),
                    isTag = table.Column<bool>(nullable: false),
                    isStock = table.Column<bool>(nullable: false),
                    isPackage = table.Column<bool>(nullable: false),
                    supplierId = table.Column<int>(nullable: false),
                    packageId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_item_flowerPackage_packageId",
                        column: x => x.packageId,
                        principalTable: "flowerPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_supplier_supplierId",
                        column: x => x.supplierId,
                        principalTable: "supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "packageItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    flowerPackageId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packageItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_packageItem_flowerPackage_flowerPackageId",
                        column: x => x.flowerPackageId,
                        principalTable: "flowerPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelivery = table.Column<bool>(nullable: false),
                    deliveryPrice = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    streetAddress = table.Column<string>(maxLength: 700, nullable: false),
                    postcode = table.Column<string>(maxLength: 300, nullable: false),
                    city = table.Column<string>(maxLength: 300, nullable: false),
                    state = table.Column<string>(maxLength: 300, nullable: false),
                    recipient = table.Column<string>(maxLength: 300, nullable: false),
                    recipientPhoneNumber = table.Column<string>(maxLength: 300, nullable: false),
                    deliveryTime = table.Column<DateTimeOffset>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false),
                    driverId = table.Column<int>(nullable: false),
                    orderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_delivery_driver_driverId",
                        column: x => x.driverId,
                        principalTable: "driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_delivery_order_orderId",
                        column: x => x.orderId,
                        principalTable: "order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "messageCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    place = table.Column<string>(maxLength: 300, nullable: false),
                    recipient = table.Column<string>(maxLength: 300, nullable: false),
                    message = table.Column<string>(maxLength: 500, nullable: false),
                    orderId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messageCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_messageCard_order_orderId",
                        column: x => x.orderId,
                        principalTable: "order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paymentOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 300, nullable: false),
                    orderId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_paymentOption_order_orderId",
                        column: x => x.orderId,
                        principalTable: "order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    remark = table.Column<long>(maxLength: 300, nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    stock = table.Column<int>(nullable: false),
                    inventoryStatusId = table.Column<int>(nullable: false),
                    itemId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_inventoryStatus_inventoryStatusId",
                        column: x => x.inventoryStatusId,
                        principalTable: "inventoryStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_item_itemId",
                        column: x => x.itemId,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itemMmItemGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    itemId = table.Column<int>(nullable: false),
                    itemGroupId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemMmItemGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_itemMmItemGroup_itemGroup_itemGroupId",
                        column: x => x.itemGroupId,
                        principalTable: "itemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemMmItemGroup_item_itemId",
                        column: x => x.itemId,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itemTag",
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
                    table.PrimaryKey("PK_itemTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_itemTag_item_itemId",
                        column: x => x.itemId,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemTag_tag_tagId",
                        column: x => x.tagId,
                        principalTable: "tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    orderId = table.Column<int>(nullable: false),
                    itemId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItem_item_itemId",
                        column: x => x.itemId,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItem_order_orderId",
                        column: x => x.orderId,
                        principalTable: "order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shoppingCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<int>(nullable: false),
                    itemId = table.Column<int>(nullable: false),
                    shoppingCartId = table.Column<int>(nullable: false),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingCartItem_item_itemId",
                        column: x => x.itemId,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shoppingCartItem_shoppingCart_shoppingCartId",
                        column: x => x.shoppingCartId,
                        principalTable: "shoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userDeliveryAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    streetAddress = table.Column<string>(maxLength: 700, nullable: false),
                    postcode = table.Column<string>(maxLength: 300, nullable: false),
                    city = table.Column<string>(maxLength: 300, nullable: false),
                    state = table.Column<string>(maxLength: 300, nullable: false),
                    recipient = table.Column<string>(maxLength: 300, nullable: false),
                    recipientPhoneNumber = table.Column<string>(maxLength: 300, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DeliveryId = table.Column<int>(nullable: true),
                    createDateTime = table.Column<DateTimeOffset>(nullable: false),
                    updateDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDeliveryAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userDeliveryAddresses_delivery_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "delivery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userDeliveryAddresses_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_delivery_driverId",
                table: "delivery",
                column: "driverId");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_orderId",
                table: "delivery",
                column: "orderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_flowerPackage_PackageTypeId",
                table: "flowerPackage",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_flowerQuantityOrSize_PackageId",
                table: "flowerQuantityOrSize",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_inventoryStatusId",
                table: "inventory",
                column: "inventoryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_itemId",
                table: "inventory",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_item_code",
                table: "item",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_item_name",
                table: "item",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_item_packageId",
                table: "item",
                column: "packageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_item_supplierId",
                table: "item",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_itemMmItemGroup_itemGroupId",
                table: "itemMmItemGroup",
                column: "itemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_itemMmItemGroup_itemId",
                table: "itemMmItemGroup",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_itemTag_itemId",
                table: "itemTag",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_itemTag_tagId",
                table: "itemTag",
                column: "tagId");

            migrationBuilder.CreateIndex(
                name: "IX_messageCard_orderId",
                table: "messageCard",
                column: "orderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_userId",
                table: "order",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItem_itemId",
                table: "orderItem",
                column: "itemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderItem_orderId",
                table: "orderItem",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_packageItem_flowerPackageId",
                table: "packageItem",
                column: "flowerPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_paymentOption_orderId",
                table: "paymentOption",
                column: "orderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCart_userId",
                table: "shoppingCart",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCartItem_itemId",
                table: "shoppingCartItem",
                column: "itemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCartItem_shoppingCartId",
                table: "shoppingCartItem",
                column: "shoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_campanyName",
                table: "supplier",
                column: "campanyName");

            migrationBuilder.CreateIndex(
                name: "IX_tag_tagTypeId",
                table: "tag",
                column: "tagTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_name",
                table: "user",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_userDeliveryAddresses_DeliveryId",
                table: "userDeliveryAddresses",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_userDeliveryAddresses_UserId",
                table: "userDeliveryAddresses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deliveryTime");

            migrationBuilder.DropTable(
                name: "flowerQuantityOrSize");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "itemMmItemGroup");

            migrationBuilder.DropTable(
                name: "itemTag");

            migrationBuilder.DropTable(
                name: "messageCard");

            migrationBuilder.DropTable(
                name: "orderItem");

            migrationBuilder.DropTable(
                name: "packageItem");

            migrationBuilder.DropTable(
                name: "paymentOption");

            migrationBuilder.DropTable(
                name: "shoppingCartItem");

            migrationBuilder.DropTable(
                name: "userDeliveryAddresses");

            migrationBuilder.DropTable(
                name: "inventoryStatus");

            migrationBuilder.DropTable(
                name: "itemGroup");

            migrationBuilder.DropTable(
                name: "tag");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "shoppingCart");

            migrationBuilder.DropTable(
                name: "delivery");

            migrationBuilder.DropTable(
                name: "tagType");

            migrationBuilder.DropTable(
                name: "flowerPackage");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "driver");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "packageType");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
