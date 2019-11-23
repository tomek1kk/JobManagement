using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobManagement.Data.Migrations
{
    public partial class positionmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "Positions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Positions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Positions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "Positions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Positions");
        }
    }
}
