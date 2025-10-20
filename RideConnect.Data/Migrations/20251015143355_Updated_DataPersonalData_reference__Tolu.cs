using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updated_DataPersonalData_reference__Tolu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DriverPersonalData_UserId",
                table: "CarDetails");

            migrationBuilder.CreateIndex(
                name: "IX_DriverPersonalData_UserId",
                table: "CarDetails",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DriverPersonalData_UserId",
                table: "CarDetails");

            migrationBuilder.CreateIndex(
                name: "IX_DriverPersonalData_UserId",
                table: "CarDetails",
                column: "UserId");
        }
    }
}
