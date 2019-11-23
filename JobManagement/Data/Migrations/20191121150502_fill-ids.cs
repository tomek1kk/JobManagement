using Microsoft.EntityFrameworkCore.Migrations;

namespace JobManagement.Data.Migrations
{
    public partial class fillids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE JobApplications SET PositionID=1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
