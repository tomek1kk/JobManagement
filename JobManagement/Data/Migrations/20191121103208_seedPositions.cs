using Microsoft.EntityFrameworkCore.Migrations;

namespace JobManagement.Data.Migrations
{
    public partial class seedPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Positions VALUES('Programmer')");
            migrationBuilder.Sql("INSERT INTO Positions VALUES('HR')");
            migrationBuilder.Sql("INSERT INTO Positions VALUES('Scrum master')");
            migrationBuilder.Sql("INSERT INTO Positions VALUES('Product owner')");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
