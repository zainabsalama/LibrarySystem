using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumOfCopies = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Borrows",
                columns: table => new
                {
                    BorrowingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfCopies = table.Column<int>(type: "int", nullable: false),
                    IsRetrieved = table.Column<bool>(type: "bit", nullable: false),
                    BorrowingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RetrievalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrows", x => x.BorrowingId);
                    table.ForeignKey(
                        name: "FK_Borrows_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrows_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Code", "NumOfCopies", "Title" },
                values: new object[,]
                {
                    { 1, 1001, 5, "The Great Gatsby" },
                    { 2, 2002, 10, "To Kill a Mockingbird" },
                    { 3, 3003, 30, "1984" },
                    { 4, 4004, 20, "Pride and Prejudice" },
                    { 5, 5005, 8, "The Catcher in the Rye" },
                    { 6, 6006, 14, "Moby-Dick" },
                    { 7, 7007, 16, "To the Lighthouse" },
                    { 8, 8008, 17, "The Lord of the Rings" },
                    { 9, 9009, 12, "Harry Potter and the Sorcerer's Stone" },
                    { 10, 10010, 9, "The Odyssey" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1001, "John Doe" },
                    { 2, 2002, "Jane Smith" },
                    { 3, 3003, "Michael Johnson" },
                    { 4, 4004, "Emily Brown" },
                    { 5, 5005, "David Wilson" }
                });

            migrationBuilder.InsertData(
                table: "Borrows",
                columns: new[] { "BorrowingId", "BookId", "BorrowingDate", "IsRetrieved", "MemberId", "NumberOfCopies", "RetrievalDate" },
                values: new object[] { 1, 1, new DateTime(2023, 6, 3, 12, 36, 31, 177, DateTimeKind.Local).AddTicks(5832), false, 1, 2, null });

            migrationBuilder.InsertData(
                table: "Borrows",
                columns: new[] { "BorrowingId", "BookId", "BorrowingDate", "IsRetrieved", "MemberId", "NumberOfCopies", "RetrievalDate" },
                values: new object[] { 2, 3, new DateTime(2023, 5, 29, 12, 36, 31, 177, DateTimeKind.Local).AddTicks(5846), false, 2, 4, null });

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_BookId",
                table: "Borrows",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_MemberId",
                table: "Borrows",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrows");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
