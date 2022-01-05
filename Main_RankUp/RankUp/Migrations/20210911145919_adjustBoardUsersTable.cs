using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class adjustBoardUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "boardUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserGuidId",
                table: "boardUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_boardUsers_UserGuidId",
                table: "boardUsers",
                column: "UserGuidId");

            migrationBuilder.AddForeignKey(
                name: "FK_boardUsers_AspNetUsers_UserGuidId",
                table: "boardUsers",
                column: "UserGuidId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_boardUsers_AspNetUsers_UserGuidId",
                table: "boardUsers");

            migrationBuilder.DropIndex(
                name: "IX_boardUsers_UserGuidId",
                table: "boardUsers");

            migrationBuilder.DropColumn(
                name: "UserGuidId",
                table: "boardUsers");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "boardUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
