using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopHeo.Data.Migrations
{
    public partial class ASPIdentityCore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fcc83b51-254b-4fb4-8900-eb481d6956b8", "AQAAAAIAAYagAAAAEMGzr2VZ8spEifKaH+tKYnayz9ngvIsRwSzYdm4qkpbu/Ke2+spVHtMYFkgd5KTEJQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 7, 18, 17, 51, 21, 154, DateTimeKind.Local).AddTicks(8760));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f69c4b52-d572-4785-8587-bd39b023b0d3", "AQAAAAIAAYagAAAAEMqVR6p1wVoSoyDs5eiqEi7LNCrsqX8jj4WqS9XM8sGkAuDzJfDByKNdDJ+3B5BFbw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 7, 18, 17, 45, 54, 502, DateTimeKind.Local).AddTicks(6045));
        }
    }
}
