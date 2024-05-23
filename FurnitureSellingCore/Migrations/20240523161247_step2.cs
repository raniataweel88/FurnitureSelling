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
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 23, 19, 12, 47, 853, DateTimeKind.Local).AddTicks(5256),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 5, 21, 20, 46, 36, 461, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItems_OrderId",
                table: "Orders",
                column: "OrderId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItems_OrderId",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 20, 46, 36, 461, DateTimeKind.Local).AddTicks(583),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 5, 23, 19, 12, 47, 853, DateTimeKind.Local).AddTicks(5256));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
