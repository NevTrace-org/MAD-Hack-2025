using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qubik.Hackathon.API.Migrations
{
    /// <inheritdoc />
    public partial class InvestorSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvestorSeed",
                schema: "hackathon",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvestorSeed",
                schema: "hackathon",
                table: "Companies");
        }
    }
}
