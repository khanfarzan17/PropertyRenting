using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentEaseLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "RentProperty",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PropertyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserName1 = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentProperty", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_RentProperty_User_UserName1",
                        column: x => x.UserName1,
                        principalTable: "User",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "SearchHistory",
                columns: table => new
                {
                    SearchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SearchQuery = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistory", x => x.SearchID);
                    table.ForeignKey(
                        name: "FK_SearchHistory_User_UserName",
                        column: x => x.UserName,
                        principalTable: "User",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: true),
                    BookingStatus = table.Column<int>(type: "int", nullable: false),
                    CheackedInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheackedOutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_RentProperty_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "RentProperty",
                        principalColumn: "PropertyId");
                    table.ForeignKey(
                        name: "FK_Booking_User_UserName",
                        column: x => x.UserName,
                        principalTable: "User",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PropertyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => new { x.UserName, x.PropertyID });
                    table.ForeignKey(
                        name: "FK_Favorite_RentProperty_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "RentProperty",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorite_User_UserName",
                        column: x => x.UserName,
                        principalTable: "User",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PropertyId",
                table: "Booking",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserName",
                table: "Booking",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_PropertyID",
                table: "Favorite",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_RentProperty_UserName1",
                table: "RentProperty",
                column: "UserName1");

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistory_UserName",
                table: "SearchHistory",
                column: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "SearchHistory");

            migrationBuilder.DropTable(
                name: "RentProperty");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
