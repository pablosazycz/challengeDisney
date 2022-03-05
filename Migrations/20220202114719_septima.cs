using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disney.Migrations
{
    public partial class septima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Datecreation",
                table: "MovieSeries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datecreation",
                table: "MovieSeries");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Characters");
        }
    }
}
