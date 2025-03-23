using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qubik.Hackathon.API.Migrations
{
    /// <inheritdoc />
    public partial class MilesstoneValidator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                schema: "hackathon",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "ValidatorRecipientAddress",
                schema: "hackathon",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Passed",
                schema: "hackathon",
                table: "Milestones",
                newName: "ValidatorRecipientAddress");

            migrationBuilder.AddColumn<DateTime>(
                name: "PassDate",
                schema: "hackathon",
                table: "Milestones",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ValidationAmount",
                schema: "hackathon",
                table: "Milestones",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassDate",
                schema: "hackathon",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "ValidationAmount",
                schema: "hackathon",
                table: "Milestones");

            migrationBuilder.RenameColumn(
                name: "ValidatorRecipientAddress",
                schema: "hackathon",
                table: "Milestones",
                newName: "Passed");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "hackathon",
                table: "Milestones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ValidatorRecipientAddress",
                schema: "hackathon",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
