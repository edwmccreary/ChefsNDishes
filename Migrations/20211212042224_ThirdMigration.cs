using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsNDishes.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "Chefs");

            migrationBuilder.AddColumn<DateTime>(
                name: "dob",
                table: "Chefs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dob",
                table: "Chefs");

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Chefs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
