using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Qubik.Hackathon.API.Migrations
{
    /// <inheritdoc />
    public partial class InvestmentsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investments",
                schema: "hackathon");

            migrationBuilder.RenameColumn(
                name: "PassDate",
                schema: "hackathon",
                table: "Milestones",
                newName: "ValidatedAt");

            migrationBuilder.AddColumn<long>(
                name: "AmountReleased",
                schema: "hackathon",
                table: "Milestones",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                schema: "hackathon",
                table: "Milestones",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountReleased",
                schema: "hackathon",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                schema: "hackathon",
                table: "Milestones");

            migrationBuilder.RenameColumn(
                name: "ValidatedAt",
                schema: "hackathon",
                table: "Milestones",
                newName: "PassDate");

            migrationBuilder.CreateTable(
                name: "Investments",
                schema: "hackathon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressFrom = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "hackathon",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investments_CompanyId",
                schema: "hackathon",
                table: "Investments",
                column: "CompanyId");
        }
    }
}
