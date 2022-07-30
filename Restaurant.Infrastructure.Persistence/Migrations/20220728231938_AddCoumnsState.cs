using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Infrastructure.Persistence.Migrations
{
    public partial class AddCoumnsState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stauts",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "stauts",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stauts",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "stauts",
                table: "Request");
        }
    }
}
