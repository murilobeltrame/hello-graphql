using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carriers.Api.Migrations
{
    /// <inheritdoc />
    public partial class CarrierAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Carrier",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Carrier",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Carrier",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Carrier",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Carrier",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Carrier");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Carrier");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Carrier");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Carrier");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Carrier");
        }
    }
}
