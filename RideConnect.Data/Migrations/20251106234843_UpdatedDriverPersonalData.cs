using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDriverPersonalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 0, 48, 39, 426, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 0, 48, 39, 426, DateTimeKind.Local).AddTicks(7533));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
