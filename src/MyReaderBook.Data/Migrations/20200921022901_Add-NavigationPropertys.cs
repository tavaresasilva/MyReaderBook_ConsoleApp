using Microsoft.EntityFrameworkCore.Migrations;

namespace MyReaderBook.Data.Migrations
{
    public partial class AddNavigationPropertys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReaderBooks_ReaderId",
                table: "ReaderBooks",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReaderBooks_Books_BookId",
                table: "ReaderBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReaderBooks_Readers_ReaderId",
                table: "ReaderBooks",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReaderBooks_Books_BookId",
                table: "ReaderBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_ReaderBooks_Readers_ReaderId",
                table: "ReaderBooks");

            migrationBuilder.DropIndex(
                name: "IX_ReaderBooks_ReaderId",
                table: "ReaderBooks");
        }
    }
}
