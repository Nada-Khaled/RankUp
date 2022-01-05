using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RankUp.Migrations
{
    public partial class addUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "univeristy",
                table: "AspNetUsers",
                newName: "photo");

            migrationBuilder.RenameColumn(
                name: "prof",
                table: "AspNetUsers",
                newName: "jobTitle");

            migrationBuilder.AddColumn<string>(
                name: "company",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "AspNetUsers",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "jobStartDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "jobStatus",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "company",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "jobStartDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "jobStatus",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "photo",
                table: "AspNetUsers",
                newName: "univeristy");

            migrationBuilder.RenameColumn(
                name: "jobTitle",
                table: "AspNetUsers",
                newName: "prof");
        }
    }
}
