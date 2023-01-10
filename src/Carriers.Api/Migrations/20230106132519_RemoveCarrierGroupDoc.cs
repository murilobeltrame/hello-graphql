using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carriers.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCarrierGroupDoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "CarrierGroup");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "CarrierGroup",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
