using Microsoft.EntityFrameworkCore.Migrations;

namespace JobManagement.Data.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "JobApplications");

            migrationBuilder.AddColumn<int>(
                name: "PositionID",
                table: "JobApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_PositionID",
                table: "JobApplications",
                column: "PositionID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Positions_PositionID",
                table: "JobApplications",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "PositionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Positions_PositionID",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_PositionID",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "PositionID",
                table: "JobApplications");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "JobApplications",
                nullable: true);
        }
    }
}
