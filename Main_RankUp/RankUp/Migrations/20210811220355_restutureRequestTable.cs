using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class restutureRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cvReviews");

            migrationBuilder.CreateTable(
                name: "reviewRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reviewerid = table.Column<int>(type: "int", nullable: true),
                    approvedByid = table.Column<int>(type: "int", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviewRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_reviewRequests_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reviewRequests_boardUsers_approvedByid",
                        column: x => x.approvedByid,
                        principalTable: "boardUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reviewRequests_boardUsers_reviewerid",
                        column: x => x.reviewerid,
                        principalTable: "boardUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reviewRequests_approvedByid",
                table: "reviewRequests",
                column: "approvedByid");

            migrationBuilder.CreateIndex(
                name: "IX_reviewRequests_reviewerid",
                table: "reviewRequests",
                column: "reviewerid");

            migrationBuilder.CreateIndex(
                name: "IX_reviewRequests_userId",
                table: "reviewRequests",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reviewRequests");

            migrationBuilder.CreateTable(
                name: "cvReviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    approvedByid = table.Column<int>(type: "int", nullable: true),
                    reviewerid = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cvReviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_cvReviews_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cvReviews_boardUsers_approvedByid",
                        column: x => x.approvedByid,
                        principalTable: "boardUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cvReviews_boardUsers_reviewerid",
                        column: x => x.reviewerid,
                        principalTable: "boardUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cvReviews_approvedByid",
                table: "cvReviews",
                column: "approvedByid");

            migrationBuilder.CreateIndex(
                name: "IX_cvReviews_reviewerid",
                table: "cvReviews",
                column: "reviewerid");

            migrationBuilder.CreateIndex(
                name: "IX_cvReviews_userId",
                table: "cvReviews",
                column: "userId");
        }
    }
}
