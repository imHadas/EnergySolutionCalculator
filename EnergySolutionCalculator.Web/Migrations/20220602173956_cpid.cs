using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergySolutionCalculator.Web.Migrations
{
    public partial class cpid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CpId",
                table: "ConstantPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpId",
                table: "ConstantPrices");
        }
    }
}
