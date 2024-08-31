using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureSellingCore.Migrations
{
    /// <inheritdoc />
    public partial class cartsitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Order",
                type: "datetime(6)",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 31, 2, 33, 46, 410, DateTimeKind.Local).AddTicks(7805),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 31, 2, 18, 21, 41, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.AddColumn<float>(
                name: "PriceAfterDiscount",
                table: "Item",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CartItem",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "CartItem",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceAfterDiscount",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "CartItem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Order",
                type: "datetime(6)",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 31, 2, 18, 21, 41, DateTimeKind.Local).AddTicks(7707),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 31, 2, 33, 46, 410, DateTimeKind.Local).AddTicks(7805));
        }
    }
}
