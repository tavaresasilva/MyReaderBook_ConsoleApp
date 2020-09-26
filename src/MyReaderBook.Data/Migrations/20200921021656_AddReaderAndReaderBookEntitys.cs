using Microsoft.EntityFrameworkCore.Migrations;

namespace MyReaderBook.Data.Migrations
{
    public partial class AddReaderAndReaderBookEntitys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReaderBooks",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    ReaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaderBooks", x => new { x.BookId, x.ReaderId });
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReaderBooks");

            migrationBuilder.DropTable(
                name: "Readers");
        }
    }
}
