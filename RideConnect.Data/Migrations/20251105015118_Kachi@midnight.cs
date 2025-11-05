using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RideConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class Kachimidnight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "RideType",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "RideType",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { "1", true, new DateTime(2025, 11, 5, 2, 51, 17, 104, DateTimeKind.Local).AddTicks(596), "Private ride, one passenger only", "Solo", null },
                    { "2", true, new DateTime(2025, 11, 5, 2, 51, 17, 104, DateTimeKind.Local).AddTicks(611), "Ride shared with other passengers", "Shared", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "RideType",
                newName: "Price");
        }
    }
}
