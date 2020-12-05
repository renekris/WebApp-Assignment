using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REST_API.Migrations
{
    public partial class Airportenumfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Airport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FlightDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentBags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentBags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentBags_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BagLetters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BagNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LetterCount = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShipmentBagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagLetters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BagLetters_ShipmentBags_ShipmentBagsId",
                        column: x => x.ShipmentBagsId,
                        principalTable: "ShipmentBags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BagParcels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BagNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ShipmentBagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagParcels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BagParcels_ShipmentBags_ShipmentBagsId",
                        column: x => x.ShipmentBagsId,
                        principalTable: "ShipmentBags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParcelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DestinationCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BagParcelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcel_BagParcels_BagParcelsId",
                        column: x => x.BagParcelsId,
                        principalTable: "BagParcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BagLetters_ShipmentBagsId",
                table: "BagLetters",
                column: "ShipmentBagsId");

            migrationBuilder.CreateIndex(
                name: "IX_BagParcels_ShipmentBagsId",
                table: "BagParcels",
                column: "ShipmentBagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_BagParcelsId",
                table: "Parcel",
                column: "BagParcelsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentBags_ShipmentId",
                table: "ShipmentBags",
                column: "ShipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BagLetters");

            migrationBuilder.DropTable(
                name: "Parcel");

            migrationBuilder.DropTable(
                name: "BagParcels");

            migrationBuilder.DropTable(
                name: "ShipmentBags");

            migrationBuilder.DropTable(
                name: "Shipment");
        }
    }
}
