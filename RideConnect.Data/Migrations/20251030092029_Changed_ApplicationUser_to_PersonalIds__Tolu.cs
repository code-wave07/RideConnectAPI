using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changed_ApplicationUser_to_PersonalIds__Tolu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_AspNetUsers_DriverId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_AspNetUsers_PassengerId",
                table: "Rides");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_CustomerPersonalData_PassengerId",
                table: "Rides",
                column: "PassengerId",
                principalTable: "CustomerPersonalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_DriverPersonalData_DriverId",
                table: "Rides",
                column: "DriverId",
                principalTable: "DriverPersonalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_CustomerPersonalData_PassengerId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_DriverPersonalData_DriverId",
                table: "Rides");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_AspNetUsers_DriverId",
                table: "Rides",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_AspNetUsers_PassengerId",
                table: "Rides",
                column: "PassengerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
