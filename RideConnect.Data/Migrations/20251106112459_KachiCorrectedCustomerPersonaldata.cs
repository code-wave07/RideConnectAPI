using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class KachiCorrectedCustomerPersonaldata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar(256)",
                table: "CustomerPersonalData",
                newName: "Address");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "CustomerPersonalData",
                newName: "varchar(256)");

            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 12, 15, 39, 158, DateTimeKind.Local).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 12, 15, 39, 158, DateTimeKind.Local).AddTicks(9571));
        }
    }
}
