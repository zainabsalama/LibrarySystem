using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.DAL.Migrations
{
    public partial class CreateRetrivalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Retrieval",
                columns: table => new
                {
                    RetrievalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookCode = table.Column<int>(type: "int", nullable: false),
                    MemberCode = table.Column<int>(type: "int", nullable: false),
                    BookTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfCopies = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retrieval", x => x.RetrievalId);
                    table.ForeignKey(
                        name: "FK_Retrieval_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Retrieval_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Retrieval_BookId",
                table: "Retrieval",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Retrieval_MemberId",
                table: "Retrieval",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Retrieval");
        }
    }
}
