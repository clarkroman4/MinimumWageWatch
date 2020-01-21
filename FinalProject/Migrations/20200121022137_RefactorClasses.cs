using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class RefactorClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Wages");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Wages");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Wages");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Wages");

            migrationBuilder.CreateTable(
                name: "CityWages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinWage = table.Column<double>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityWages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CountyWages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinWage = table.Column<double>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    County = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountyWages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StateWages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinWage = table.Column<double>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateWages", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityWages");

            migrationBuilder.DropTable(
                name: "CountyWages");

            migrationBuilder.DropTable(
                name: "StateWages");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Wages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Wages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Wages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Wages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
