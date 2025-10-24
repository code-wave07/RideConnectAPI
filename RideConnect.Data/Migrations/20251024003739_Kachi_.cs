using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class Kachi_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDetails_DriverPersonalData_DriverPersonalDataId",
                table: "CarDetails");

            migrationBuilder.RenameColumn(
                name: "DriverPersonalDataId",
                table: "CarDetails",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CarDetails_DriverPersonalDataId",
                table: "CarDetails",
                newName: "IX_CarDetails_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDetails_DriverPersonalData_UserId",
                table: "CarDetails",
                column: "UserId",
                principalTable: "DriverPersonalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDetails_DriverPersonalData_UserId",
                table: "CarDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CarDetails",
                newName: "DriverPersonalDataId");

            migrationBuilder.RenameIndex(
                name: "IX_CarDetails_UserId",
                table: "CarDetails",
                newName: "IX_CarDetails_DriverPersonalDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDetails_DriverPersonalData_DriverPersonalDataId",
                table: "CarDetails",
                column: "DriverPersonalDataId",
                principalTable: "DriverPersonalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
