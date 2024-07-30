using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginCityId = table.Column<int>(name: "Origin_City_Id", type: "int", nullable: false),
                    DepartureCityId = table.Column<int>(name: "Departure_City_Id", type: "int", nullable: false),
                    DepartureDate = table.Column<DateTime>(name: "Departure_Date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginCityId = table.Column<int>(name: "Origin_City_Id", type: "int", nullable: false),
                    DepartureCityId = table.Column<int>(name: "Departure_City_Id", type: "int", nullable: false),
                    AgencyId = table.Column<int>(name: "Agency_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(name: "Departure_Time", type: "datetime2", nullable: false),
                    ArivalTime = table.Column<DateTime>(name: "Arival_Time", type: "datetime2", nullable: false),
                    AirlineId = table.Column<int>(name: "Airline_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_RouteId",
                table: "Flights",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Departure_City_Id_Origin_City_Id_Departure_Date",
                table: "Routes",
                columns: new[] { "Departure_City_Id", "Origin_City_Id", "Departure_Date" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
