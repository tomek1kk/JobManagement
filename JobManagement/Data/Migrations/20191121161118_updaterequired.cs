using Microsoft.EntityFrameworkCore.Migrations;

namespace JobManagement.Data.Migrations
{
    public partial class updaterequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE JobApplications SET PositionId = 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
