using Microsoft.EntityFrameworkCore.Migrations;

namespace SawyerAir.Migrations
{
    public partial class Migration0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id_Line = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id_Line);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id_Plane = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Id_Line = table.Column<int>(nullable: false),
                    LineId_Line = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id_Plane);
                    table.ForeignKey(
                        name: "FK_Planes_Lines_LineId_Line",
                        column: x => x.LineId_Line,
                        principalTable: "Lines",
                        principalColumn: "Id_Line",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planes_LineId_Line",
                table: "Planes",
                column: "LineId_Line");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Lines");
        }
    }
}
