using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class CVReviewseNewLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "approvedByid",
                table: "cvReviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cvReviews_approvedByid",
                table: "cvReviews",
                column: "approvedByid");

            migrationBuilder.AddForeignKey(
                name: "FK_cvReviews_boardUsers_approvedByid",
                table: "cvReviews",
                column: "approvedByid",
                principalTable: "boardUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cvReviews_boardUsers_approvedByid",
                table: "cvReviews");

            migrationBuilder.DropIndex(
                name: "IX_cvReviews_approvedByid",
                table: "cvReviews");

            migrationBuilder.DropColumn(
                name: "approvedByid",
                table: "cvReviews");
        }
    }
}
