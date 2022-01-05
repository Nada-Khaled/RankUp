using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class addQuestionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "questionTypeid",
                table: "ReviewFormQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "questionTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionTypes", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "questionTypes",
                columns: new[] { "id", "type" },
                values: new object[] { 1, "multiselect" });

            migrationBuilder.InsertData(
                table: "questionTypes",
                columns: new[] { "id", "type" },
                values: new object[] { 2, "slider" });

            migrationBuilder.InsertData(
                table: "questionTypes",
                columns: new[] { "id", "type" },
                values: new object[] { 3, "text" });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewFormQuestions_questionTypeid",
                table: "ReviewFormQuestions",
                column: "questionTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewFormQuestions_questionTypes_questionTypeid",
                table: "ReviewFormQuestions",
                column: "questionTypeid",
                principalTable: "questionTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewFormQuestions_questionTypes_questionTypeid",
                table: "ReviewFormQuestions");

            migrationBuilder.DropTable(
                name: "questionTypes");

            migrationBuilder.DropIndex(
                name: "IX_ReviewFormQuestions_questionTypeid",
                table: "ReviewFormQuestions");

            migrationBuilder.DropColumn(
                name: "questionTypeid",
                table: "ReviewFormQuestions");
        }
    }
}
