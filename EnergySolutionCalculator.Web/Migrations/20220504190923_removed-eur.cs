using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergySolutionCalculator.Web.Migrations
{
    public partial class removedeur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceEur",
                table: "Inverters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceEur",
                table: "Inverters",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
