using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergySolutionCalculator.Web.Migrations
{
    public partial class selected_inverters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Inverters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inverters_UserId",
                table: "Inverters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inverters_Users_UserId",
                table: "Inverters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inverters_Users_UserId",
                table: "Inverters");

            migrationBuilder.DropIndex(
                name: "IX_Inverters_UserId",
                table: "Inverters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Inverters");
        }
    }
}
