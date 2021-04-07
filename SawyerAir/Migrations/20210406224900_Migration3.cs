using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SawyerAir.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Stop",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false),
                    StopAt = table.Column<string>(nullable: true),
                    StopHour = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Stop_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class_Info",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false),
                    FlightId = table.Column<int>(nullable: false),
                    No_seats = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class_Info", x => new { x.ClassId, x.FlightId });
                    table.ForeignKey(
                        name: "FK_Class_Info_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_Info_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_Info_FlightId",
                table: "Class_Info",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Stop_FlightId",
                table: "Stop",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class_Info");

            migrationBuilder.DropTable(
                name: "Stop");

            migrationBuilder.DropTable(
                name: "Class");
        }
    }
}
