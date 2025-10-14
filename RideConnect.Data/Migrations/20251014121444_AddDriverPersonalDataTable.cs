using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDriverPersonalDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPersonalDatas_AspNetUsers_UserId",
                table: "CustomerPersonalDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPersonalDatas",
                table: "CustomerPersonalDatas");

            migrationBuilder.RenameTable(
                name: "CustomerPersonalDatas",
                newName: "CustomerPersonalData");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPersonalDatas_UserId",
                table: "CustomerPersonalData",
                newName: "IX_CustomerPersonalData_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPersonalDatas_Id",
                table: "CustomerPersonalData",
                newName: "IX_CustomerPersonalData_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPersonalData",
                table: "CustomerPersonalData",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DriverPersonalData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    DlNumber = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    VehicleMake = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    CarModel = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    ProductionYear = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    CarColor = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    CarPlateNumber = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(256)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverPersonalData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverPersonalData_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverPersonalData_UserId",
                table: "DriverPersonalData",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPersonalData_AspNetUsers_UserId",
                table: "CustomerPersonalData",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPersonalData_AspNetUsers_UserId",
                table: "CustomerPersonalData");

            migrationBuilder.DropTable(
                name: "DriverPersonalData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPersonalData",
                table: "CustomerPersonalData");

            migrationBuilder.RenameTable(
                name: "CustomerPersonalData",
                newName: "CustomerPersonalDatas");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPersonalData_UserId",
                table: "CustomerPersonalDatas",
                newName: "IX_CustomerPersonalDatas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPersonalData_Id",
                table: "CustomerPersonalDatas",
                newName: "IX_CustomerPersonalDatas_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPersonalDatas",
                table: "CustomerPersonalDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPersonalDatas_AspNetUsers_UserId",
                table: "CustomerPersonalDatas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
