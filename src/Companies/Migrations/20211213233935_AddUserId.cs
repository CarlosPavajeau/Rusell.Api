using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusell.Companies.Migrations
{
    public partial class AddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "companies",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_companies_user_id",
                table: "companies",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_companies_user_id",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "companies");
        }
    }
}
