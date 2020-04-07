using Microsoft.EntityFrameworkCore.Migrations;

namespace TastyMeal.DataAccess.Migrations
{
    public partial class CategoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuOrder",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "MenuOrder",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
