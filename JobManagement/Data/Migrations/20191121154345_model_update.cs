using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobManagement.Data.Migrations
{
    public partial class model_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationStatus",
                table: "JobApplications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplyDate",
                table: "JobApplications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "ApplyDate",
                table: "JobApplications");
        }
    }
}
