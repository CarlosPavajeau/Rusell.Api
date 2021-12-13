using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusell.Addresses.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    state = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    city = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    neighborhood = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    street_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    intersection = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    street_number = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    comments = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_addresses", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
