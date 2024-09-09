using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureSellingCore.Migrations
{
    /// <inheritdoc />
    public partial class carti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomName",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_ItemRequestId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ItemRequestId",
                table: "CartItem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Order",
                type: "datetime(6)",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 5, 0, 46, 2, 317, DateTimeKind.Local).AddTicks(1748),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 1, 37, 0, 164, DateTimeKind.Local).AddTicks(4129));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Order",
                type: "datetime(6)",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 1, 37, 0, 164, DateTimeKind.Local).AddTicks(4129),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 5, 0, 46, 2, 317, DateTimeKind.Local).AddTicks(1748));

            migrationBuilder.AddColumn<int>(
                name: "ItemRequestId",
                table: "CartItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ItemRequestId",
                table: "CartItem",
                column: "ItemRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomName",
                table: "CartItem",
                column: "ItemRequestId",
                principalTable: "ItemRequest",
                principalColumn: "Id");
        }
    }
}
