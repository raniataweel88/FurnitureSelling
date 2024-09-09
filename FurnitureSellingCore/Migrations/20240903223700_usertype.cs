using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureSellingCore.Migrations
{
    /// <inheritdoc />
    public partial class usertype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "User",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Order",
                type: "datetime(6)",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 1, 37, 0, 164, DateTimeKind.Local).AddTicks(4129),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 20, 8, 8, 869, DateTimeKind.Local).AddTicks(1859));

            migrationBuilder.AlterColumn<string>(
                name: "DiscountType",
                table: "Item",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Order",
                type: "datetime(6)",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 20, 8, 8, 869, DateTimeKind.Local).AddTicks(1859),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 1, 37, 0, 164, DateTimeKind.Local).AddTicks(4129));

            migrationBuilder.AlterColumn<int>(
                name: "DiscountType",
                table: "Item",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);
        }
    }
}
