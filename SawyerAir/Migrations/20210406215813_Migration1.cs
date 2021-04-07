using Microsoft.EntityFrameworkCore.Migrations;

namespace SawyerAir.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planes_Lines_LineId_Line",
                table: "Planes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planes",
                table: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Planes_LineId_Line",
                table: "Planes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lines",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "Id_Plane",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "Id_Line",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "LineId_Line",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "Id_Line",
                table: "Lines");

            migrationBuilder.RenameTable(
                name: "Planes",
                newName: "Plane");

            migrationBuilder.RenameTable(
                name: "Lines",
                newName: "Line");

            migrationBuilder.AddColumn<int>(
                name: "PlaneId",
                table: "Plane",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LineId",
                table: "Plane",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LineId",
                table: "Line",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plane",
                table: "Plane",
                column: "PlaneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Line",
                table: "Line",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Plane_LineId",
                table: "Plane",
                column: "LineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plane_Line_LineId",
                table: "Plane",
                column: "LineId",
                principalTable: "Line",
                principalColumn: "LineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plane_Line_LineId",
                table: "Plane");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plane",
                table: "Plane");

            migrationBuilder.DropIndex(
                name: "IX_Plane_LineId",
                table: "Plane");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Line",
                table: "Line");

            migrationBuilder.DropColumn(
                name: "PlaneId",
                table: "Plane");

            migrationBuilder.DropColumn(
                name: "LineId",
                table: "Plane");

            migrationBuilder.DropColumn(
                name: "LineId",
                table: "Line");

            migrationBuilder.RenameTable(
                name: "Plane",
                newName: "Planes");

            migrationBuilder.RenameTable(
                name: "Line",
                newName: "Lines");

            migrationBuilder.AddColumn<int>(
                name: "Id_Plane",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id_Line",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LineId_Line",
                table: "Planes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Line",
                table: "Lines",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planes",
                table: "Planes",
                column: "Id_Plane");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lines",
                table: "Lines",
                column: "Id_Line");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_LineId_Line",
                table: "Planes",
                column: "LineId_Line");

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_Lines_LineId_Line",
                table: "Planes",
                column: "LineId_Line",
                principalTable: "Lines",
                principalColumn: "Id_Line",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
