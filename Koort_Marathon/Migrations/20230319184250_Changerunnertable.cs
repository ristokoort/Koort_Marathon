using Microsoft.EntityFrameworkCore.Migrations;

namespace Koort_Marathon.Migrations
{
    public partial class Changerunnertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Runner",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FinishTime",
                table: "Runner",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "BreakTime",
                table: "Runner",
                newName: "Breaks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Runner",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Runner",
                newName: "FinishTime");

            migrationBuilder.RenameColumn(
                name: "Breaks",
                table: "Runner",
                newName: "BreakTime");
        }
    }
}
