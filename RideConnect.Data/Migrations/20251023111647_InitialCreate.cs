using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "varchar(MAX)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    Firstname = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Lastname = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "varchar(MAX)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(MAX)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Claims = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RideType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    Type = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Price = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(256)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(256)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(256)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(256)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(256)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(256)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Value = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPersonalData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "varchar(256)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(256)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPersonalData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPersonalData_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverPersonalData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    BankName = table.Column<string>(type: "varchar(256)", nullable: false),
                    AccountNumber = table.Column<string>(type: "varchar(256)", nullable: false),
                    AccountName = table.Column<string>(type: "varchar(256)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MenuId = table.Column<string>(type: "varchar(256)", nullable: true),
                    
                    RoleId = table.Column<string>(type: "varchar(256)", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    ClaimValue = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MenuId = table.Column<string>(type: "varchar(256)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(256)", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    ClaimValue = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rides",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    From = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Location = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    RideTypeId = table.Column<string>(type: "varchar(256)", nullable: false),
                    DriverId = table.Column<string>(type: "varchar(256)", nullable: false),
                    PassengerId = table.Column<string>(type: "varchar(256)", nullable: false),
                    Price = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    RideStatus = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rides_AspNetUsers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rides_AspNetUsers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rides_RideType_RideTypeId",
                        column: x => x.RideTypeId,
                        principalTable: "RideType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    NumberOfSeats = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    DlNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    VehicleMake = table.Column<string>(type: "varchar(50)", nullable: false),
                    CarModel = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProductionYear = table.Column<string>(type: "varchar(50)", nullable: false),
                    CarColor = table.Column<string>(type: "varchar(10)", nullable: false),
                    CarPlateNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    DriverPersonalDataId = table.Column<string>(type: "varchar(256)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarDetails_DriverPersonalData_DriverPersonalDataId",
                        column: x => x.DriverPersonalDataId,
                        principalTable: "DriverPersonalData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_MenuId",
                table: "AspNetRoleClaims",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

           

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_MenuId",
                table: "AspNetUserClaims",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            

           

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarDetails_DriverPersonalDataId",
                table: "CarDetails",
                column: "DriverPersonalDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarDetails_Id",
                table: "CarDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPersonalData_Id",
                table: "CustomerPersonalData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPersonalData_UserId",
                table: "CustomerPersonalData",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverPersonalData_Id",
                table: "DriverPersonalData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DriverPersonalData_UserId",
                table: "DriverPersonalData",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_DriverId",
                table: "Rides",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_PassengerId",
                table: "Rides",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_RideTypeId",
                table: "Rides",
                column: "RideTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarDetails");

            migrationBuilder.DropTable(
                name: "CustomerPersonalData");

            migrationBuilder.DropTable(
                name: "Rides");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DriverPersonalData");

            migrationBuilder.DropTable(
                name: "RideType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
