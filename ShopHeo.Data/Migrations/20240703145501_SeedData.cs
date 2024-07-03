using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopHeo.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_order_OrderID",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "Order");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppConfig",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTitle", "This is home page of eShopSolution" },
                    { "HomeKeyword", "This is keyword of eShopSolution" },
                    { "HomeDescription", "This is description of eShopSolution" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "IsShowOnHome", "ParentID", "SortOder" },
                values: new object[,]
                {
                    { 1, true, null, 1 },
                    { 2, true, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "vi", true, "Tiếng Việt" },
                    { "en", false, "English" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "DateCreated", "OriginalPrice", "Price", "SeoAlias" },
                values: new object[] { 1, new DateTime(2024, 7, 3, 21, 55, 0, 754, DateTimeKind.Local).AddTicks(4066), 100000m, 200000m, 0 });

            migrationBuilder.InsertData(
                table: "CategoryTranslation",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, 1, "vi", "Áo nam", "ao-nam", "Sản phẩm áo thời trang nam", "Sản phẩm áo thời trang nam" },
                    { 3, 2, "vi", "Áo nữ", "ao-nu", "Sản phẩm áo thời trang nữ", "Sản phẩm áo thời trang women" },
                    { 2, 1, "en", "Men Shirt", "men-shirt", "The shirt products for men", "The shirt products for men" },
                    { 4, 2, "en", "Women Shirt", "women-shirt", "The shirt products for women", "The shirt products for women" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategory",
                columns: new[] { "ProductID", "CategoryID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductTranslations",
                columns: new[] { "Id", "Description", "Details", "LanguageId", "Name", "ProductId", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, "Áo sơ mi nam trắng Việt Tiến", "Áo sơ mi nam trắng Việt Tiến", "vi", "Áo sơ mi nam trắng Việt Tiến", 1, "ao-so-mi-nam-trang-viet-tien", "Áo sơ mi nam trắng Việt Tiến", "Áo sơ mi nam trắng Việt Tiến" },
                    { 2, "Viet Tien Men T-Shirt", "Viet Tien Men T-Shirt", "en", "Viet Tien Men T-Shirt", 1, "viet-tien-men-t-shirt", "Viet Tien Men T-Shirt", "Viet Tien Men T-Shirt" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: "HomeDescription");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: "HomeKeyword");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "CategoryTranslation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTranslation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryTranslation",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryTranslation",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductInCategory",
                keyColumns: new[] { "ProductID", "CategoryID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "en");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "vi");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "order");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_order_OrderID",
                table: "OrderDetail",
                column: "OrderID",
                principalTable: "order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
