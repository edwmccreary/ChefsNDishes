using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsNDishes.Migrations
{
    public partial class CorrectedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Chefs");

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "Chefs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "Chefs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstname",
                table: "Chefs");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "Chefs");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Chefs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
