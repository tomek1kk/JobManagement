using Microsoft.EntityFrameworkCore.Migrations;

namespace JobManagement.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Positions_PositionID",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_PositionID",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "PositionID",
                table: "JobApplications",
                newName: "PositionId");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "JobApplications",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "JobApplications",
                newName: "PositionID");

            migrationBuilder.AlterColumn<int>(
                name: "PositionID",
                table: "JobApplications",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
