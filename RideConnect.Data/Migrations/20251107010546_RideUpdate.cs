using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class RideUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 2, 5, 41, 151, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 2, 5, 41, 151, DateTimeKind.Local).AddTicks(7277));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
