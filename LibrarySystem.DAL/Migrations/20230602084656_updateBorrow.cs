using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.DAL.Migrations
{
    public partial class updateBorrow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Borrowers",
                table: "Borrowers");

            migrationBuilder.RenameTable(
                name: "Borrowers",
                newName: "Member");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Borrow",
                columns: table => new
                {
                    BorrowingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    NumberOfCopies = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrow", x => x.BorrowingId);
                    table.ForeignKey(
                        name: "FK_Borrow_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrow_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_BookId",
                table: "Borrow",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_MemberId",
                table: "Borrow",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Borrowers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Borrowers",
                table: "Borrowers",
                column: "Id");
        }
    }
}
