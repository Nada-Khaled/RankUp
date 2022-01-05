using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class addBoardUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reviewerid",
                table: "cvReviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "boardUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVReviewCount = table.Column<int>(type: "int", nullable: false),
                    TotalCVReviewed = table.Column<int>(type: "int", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boardUsers", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cvReviews_reviewerid",
                table: "cvReviews",
                column: "reviewerid");

            migrationBuilder.AddForeignKey(
                name: "FK_cvReviews_boardUsers_reviewerid",
                table: "cvReviews",
                column: "reviewerid",
                principalTable: "boardUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cvReviews_boardUsers_reviewerid",
                table: "cvReviews");

            migrationBuilder.DropTable(
                name: "boardUsers");

            migrationBuilder.DropIndex(
                name: "IX_cvReviews_reviewerid",
                table: "cvReviews");

            migrationBuilder.DropColumn(
                name: "reviewerid",
                table: "cvReviews");
        }
    }
}
