using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qubik.Hackathon.API.Migrations
{
    /// <inheritdoc />
    public partial class EmailsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvestorAddress",
                schema: "hackathon",
                table: "Companies",
                newName: "InvestorIdentity");

            migrationBuilder.AddColumn<string>(
                name: "CeoEmailAddress",
                schema: "hackathon",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InvestorEmailAddress",
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
                name: "CeoEmailAddress",
                schema: "hackathon",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "InvestorEmailAddress",
                schema: "hackathon",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "InvestorIdentity",
                schema: "hackathon",
                table: "Companies",
                newName: "InvestorAddress");
        }
    }
}
