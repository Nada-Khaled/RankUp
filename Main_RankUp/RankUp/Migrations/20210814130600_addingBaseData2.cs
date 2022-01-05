using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class addingBaseData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "maxCVReviewPerPersion",
                table: "baseData",
                newName: "maxCVReviewPerPerson");

            migrationBuilder.AddColumn<int>(
                name: "maxCVReviewPerMonth",
                table: "baseData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "baseData",
                keyColumn: "id",
                keyValue: 1,
                column: "maxCVReviewPerMonth",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maxCVReviewPerMonth",
                table: "baseData");

            migrationBuilder.RenameColumn(
                name: "maxCVReviewPerPerson",
                table: "baseData",
                newName: "maxCVReviewPerPersion");
        }
    }
}
