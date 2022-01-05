using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class adjustUserIDColoumnInBoardUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_boardUsers_AspNetUsers_UserGuidId",
                table: "boardUsers");

            migrationBuilder.RenameColumn(
                name: "UserGuidId",
                table: "boardUsers",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_boardUsers_UserGuidId",
                table: "boardUsers",
                newName: "IX_boardUsers_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_boardUsers_AspNetUsers_userId",
                table: "boardUsers",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_boardUsers_AspNetUsers_userId",
                table: "boardUsers");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "boardUsers",
                newName: "UserGuidId");

            migrationBuilder.RenameIndex(
                name: "IX_boardUsers_userId",
                table: "boardUsers",
                newName: "IX_boardUsers_UserGuidId");

            migrationBuilder.AddForeignKey(
                name: "FK_boardUsers_AspNetUsers_UserGuidId",
                table: "boardUsers",
                column: "UserGuidId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
