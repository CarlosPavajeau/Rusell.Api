using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusell.Routes.Migrations
{
    public partial class AddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "to",
                table: "routes",
                newName: "to_id");

            migrationBuilder.RenameColumn(
                name: "from",
                table: "routes",
                newName: "from_id");

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    country = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    state = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    city = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_addresses", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_routes_from_id",
                table: "routes",
                column: "from_id");

            migrationBuilder.CreateIndex(
                name: "ix_routes_to_id",
                table: "routes",
                column: "to_id");

            migrationBuilder.AddForeignKey(
                name: "fk_routes_addresses_from_id1",
                table: "routes",
                column: "from_id",
                principalTable: "addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_routes_addresses_to_id1",
                table: "routes",
                column: "to_id",
                principalTable: "addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_routes_addresses_from_id1",
                table: "routes");

            migrationBuilder.DropForeignKey(
                name: "fk_routes_addresses_to_id1",
                table: "routes");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropIndex(
                name: "ix_routes_from_id",
                table: "routes");

            migrationBuilder.DropIndex(
                name: "ix_routes_to_id",
                table: "routes");

            migrationBuilder.RenameColumn(
                name: "to_id",
                table: "routes",
                newName: "to");

            migrationBuilder.RenameColumn(
                name: "from_id",
                table: "routes",
                newName: "from");
        }
    }
}
