using Microsoft.EntityFrameworkCore.Migrations;

namespace Floral.Migrations
{
    public partial class FloralMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "itemId",
                table: "packageItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_packageItem_itemId",
                table: "packageItem",
                column: "itemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_packageItem_item_itemId",
                table: "packageItem",
                column: "itemId",
                principalTable: "item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_packageItem_item_itemId",
                table: "packageItem");

            migrationBuilder.DropIndex(
                name: "IX_packageItem_itemId",
                table: "packageItem");

            migrationBuilder.DropColumn(
                name: "itemId",
                table: "packageItem");
        }
    }
}
