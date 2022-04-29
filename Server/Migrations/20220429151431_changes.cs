using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamificationApp.Server.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodAnswers",
                table: "Tests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoodAnswers",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
