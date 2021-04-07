using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SawyerAir.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departure_Location = table.Column<string>(nullable: true),
                    Destination_Location = table.Column<string>(nullable: true),
                    Departure_Hour = table.Column<TimeSpan>(nullable: false),
                    Destination_Hour = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Plane_Flight",
                columns: table => new
                {
                    PlaneId = table.Column<int>(nullable: false),
                    FlightId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plane_Flight", x => new { x.PlaneId, x.FlightId });
                    table.ForeignKey(
                        name: "FK_Plane_Flight_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plane_Flight_Plane_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Plane",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plane_Flight_FlightId",
                table: "Plane_Flight",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plane_Flight");

            migrationBuilder.DropTable(
                name: "Flight");
        }
    }
}
