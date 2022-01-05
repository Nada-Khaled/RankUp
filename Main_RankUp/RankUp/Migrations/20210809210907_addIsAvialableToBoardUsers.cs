using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class addIsAvialableToBoardUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RankUpEmployee");

            migrationBuilder.RenameColumn(
                name: "TotalCVReviewed",
                table: "boardUsers",
                newName: "PendingReviews");

            migrationBuilder.RenameColumn(
                name: "CVReviewCount",
                table: "boardUsers",
                newName: "CVsReviewed");

            migrationBuilder.AddColumn<bool>(
                name: "isAvailable",
                table: "boardUsers",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAvailable",
                table: "boardUsers");

            migrationBuilder.RenameColumn(
                name: "PendingReviews",
                table: "boardUsers",
                newName: "TotalCVReviewed");

            migrationBuilder.RenameColumn(
                name: "CVsReviewed",
                table: "boardUsers",
                newName: "CVReviewCount");

            migrationBuilder.CreateTable(
                name: "RankUpEmployee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVsReviewed = table.Column<int>(type: "int", nullable: false),
                    PendingReviews = table.Column<int>(type: "int", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankUpEmployee", x => x.id);
                });
        }
    }
}
