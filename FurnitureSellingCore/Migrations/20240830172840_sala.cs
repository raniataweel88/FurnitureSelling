using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureSellingCore.Migrations
{
    /// <inheritdoc />
    public partial class sala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Salary",
                table: "User",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Order",
                type: "datetime(6)",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 20, 28, 40, 82, DateTimeKind.Local).AddTicks(6387),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 29, 18, 8, 57, 969, DateTimeKind.Local).AddTicks(9690));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salary",
                table: "User",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Order",
                type: "datetime(6)",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 29, 18, 8, 57, 969, DateTimeKind.Local).AddTicks(9690),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 20, 28, 40, 82, DateTimeKind.Local).AddTicks(6387));
        }
    }
}
