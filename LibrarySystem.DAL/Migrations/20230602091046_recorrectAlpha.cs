using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.DAL.Migrations
{
    public partial class recorrectAlpha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookICode",
                table: "Borrow",
                newName: "BookCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookCode",
                table: "Borrow",
                newName: "BookICode");
        }
    }
}
