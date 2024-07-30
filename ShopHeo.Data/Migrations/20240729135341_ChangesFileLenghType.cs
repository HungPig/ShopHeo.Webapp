using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopHeo.Data.Migrations
{
    public partial class ChangesFileLenghType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Slide",
                table: "Slide");

            migrationBuilder.RenameTable(
                name: "Slide",
                newName: "Slides");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slides",
                table: "Slides",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0c2d301-9457-4d06-94b9-8274dd80a7be", "AQAAAAIAAYagAAAAEKEdqxP9Z24dn0ar+K5QcaQQpygPWLvIak6ZPwQKM8cMDmindiI5cFwvoqQe7kE+Pw==" });

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
                value: new DateTime(2024, 7, 29, 20, 53, 40, 672, DateTimeKind.Local).AddTicks(2140));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Slides",
                table: "Slides");

            migrationBuilder.RenameTable(
                name: "Slides",
                newName: "Slide");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slide",
                table: "Slide",
                column: "Id");

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
    }
}
