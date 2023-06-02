using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.DAL.Migrations
{
    public partial class MakeCodeAsAforignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_Books_BookId",
                table: "Borrow");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_Member_MemberId",
                table: "Borrow");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Borrow",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Borrow",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BookICode",
                table: "Borrow",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberCode",
                table: "Borrow",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_Books_BookId",
                table: "Borrow",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_Member_MemberId",
                table: "Borrow",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_Books_BookId",
                table: "Borrow");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_Member_MemberId",
                table: "Borrow");

            migrationBuilder.DropColumn(
                name: "BookICode",
                table: "Borrow");

            migrationBuilder.DropColumn(
                name: "MemberCode",
                table: "Borrow");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Borrow",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Borrow",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_Books_BookId",
                table: "Borrow",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_Member_MemberId",
                table: "Borrow",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
