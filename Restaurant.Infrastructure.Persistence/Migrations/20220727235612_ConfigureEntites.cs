using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Infrastructure.Persistence.Migrations
{
    public partial class ConfigureEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creadted",
                table: "InfoDish");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "InfoDish");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "InfoDish");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "InfoDish");

            migrationBuilder.DropColumn(
                name: "Creadted",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Dish");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Creadted",
                table: "InfoDish",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InfoDish",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "InfoDish",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "InfoDish",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Creadted",
                table: "Dish",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Dish",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Dish",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Dish",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
