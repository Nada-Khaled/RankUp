using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class addReviewFormTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewFormSections",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewFormSections", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewFormQuestions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sectionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewFormQuestions", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReviewFormQuestions_ReviewFormSections_sectionid",
                        column: x => x.sectionid,
                        principalTable: "ReviewFormSections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewFormOptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    questionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewFormOptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReviewFormOptions_ReviewFormQuestions_questionid",
                        column: x => x.questionid,
                        principalTable: "ReviewFormQuestions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewFormOptions_questionid",
                table: "ReviewFormOptions",
                column: "questionid");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewFormQuestions_sectionid",
                table: "ReviewFormQuestions",
                column: "sectionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewFormOptions");

            migrationBuilder.DropTable(
                name: "ReviewFormQuestions");

            migrationBuilder.DropTable(
                name: "ReviewFormSections");
        }
    }
}
