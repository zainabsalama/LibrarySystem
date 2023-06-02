using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.DAL.Migrations
{
    public partial class updateTitleToBorrow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookTitle",
                table: "Borrow",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookTitle",
                table: "Borrow");
        }
    }
}
