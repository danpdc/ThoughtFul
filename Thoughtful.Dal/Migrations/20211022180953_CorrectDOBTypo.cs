using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thoughtful.Dal.Migrations
{
    public partial class CorrectDOBTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirt",
                table: "Authors",
                newName: "DateOfBirth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Authors",
                newName: "DateOfBirt");
        }
    }
}
