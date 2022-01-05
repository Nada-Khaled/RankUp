using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class AddToDoListTableAndAddDeadlineAttributeToReviewRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "reviewRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "toDoList",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    boardUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    task = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toDoList", x => x.id);
                    table.ForeignKey(
                        name: "FK_toDoList_AspNetUsers_boardUserId",
                        column: x => x.boardUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_toDoList_boardUserId",
                table: "toDoList",
                column: "boardUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "toDoList");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "reviewRequests");
        }
    }
}
