using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class KachiToday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "CustomerPersonalData",
                newName: "varchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "RideType",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar(256)",
                table: "CustomerPersonalData",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "RideType",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 5, 2, 51, 17, 104, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "RideType",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 5, 2, 51, 17, 104, DateTimeKind.Local).AddTicks(611));
        }
    }
}
