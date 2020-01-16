using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Wages_WageID",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_WageID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "WageID",
                table: "Locations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WageID",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_WageID",
                table: "Locations",
                column: "WageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Wages_WageID",
                table: "Locations",
                column: "WageID",
                principalTable: "Wages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
