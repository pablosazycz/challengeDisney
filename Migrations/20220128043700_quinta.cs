using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disney.Migrations
{
    public partial class quinta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSeries_Genders_GenderId",
                table: "MovieSeries");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "MovieSeries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSeries_Genders_GenderId",
                table: "MovieSeries",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSeries_Genders_GenderId",
                table: "MovieSeries");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "MovieSeries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSeries_Genders_GenderId",
                table: "MovieSeries",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");
        }
    }
}
