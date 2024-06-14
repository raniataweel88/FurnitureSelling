using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureSellingCore.Migrations
{
    /// <inheritdoc />
    public partial class step2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Order",
                type: "datetime(6)",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 14, 18, 46, 8, 978, DateTimeKind.Local).AddTicks(406),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 14, 18, 20, 32, 338, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.AddColumn<string>(
                name: "NoteStor",
                table: "ItemRequest",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "ItemRequest",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Item",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "size",
                table: "Item",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteStor",
                table: "ItemRequest");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ItemRequest");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "size",
                table: "Item");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Order",
                type: "datetime(6)",
                nullable: true,
                defaultValue: new DateTime(2024, 6, 14, 18, 20, 32, 338, DateTimeKind.Local).AddTicks(9180),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 6, 14, 18, 46, 8, 978, DateTimeKind.Local).AddTicks(406));
        }
    }
}
