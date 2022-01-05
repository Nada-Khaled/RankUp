using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class removePendingReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PendingReviews",
                table: "boardUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PendingReviews",
                table: "boardUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
