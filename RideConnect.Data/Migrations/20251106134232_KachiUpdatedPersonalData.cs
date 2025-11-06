using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class KachiUpdatedPersonalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "DriverPersonalData",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 14, 42, 25, 465, DateTimeKind.Local).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 14, 42, 25, 465, DateTimeKind.Local).AddTicks(5438));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "DriverPersonalData");

            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 12, 24, 51, 16, DateTimeKind.Local).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 12, 24, 51, 16, DateTimeKind.Local).AddTicks(2628));
        }
    }
}
