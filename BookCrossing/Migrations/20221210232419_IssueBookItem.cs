using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BookCrossing.Migrations
{
    public partial class IssueBookItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueBookItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BookId = table.Column<int>(nullable: true),
                    IssueBookId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueBookItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueBookItem_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueBookItem_BookId",
                table: "IssueBookItem",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueBookItem");
        }
    }
}
