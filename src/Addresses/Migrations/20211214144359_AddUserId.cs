using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusell.Addresses.Migrations
{
    public partial class AddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "addresses",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_addresses_user_id",
                table: "addresses",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_addresses_user_id",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "addresses");
        }
    }
}
