using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusell.Clients.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    middle_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    first_surname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    second_surname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    user_id = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clients", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_clients_user_id",
                table: "clients",
                column: "user_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
