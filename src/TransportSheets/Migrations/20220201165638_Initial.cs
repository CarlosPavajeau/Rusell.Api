using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusell.TransportSheets.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    full_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transport_sheets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    departure_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    quota = table.Column<long>(type: "bigint", nullable: false),
                    vehicle_license_plate = table.Column<string>(type: "text", nullable: true),
                    dispatcher_id = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transport_sheets", x => x.id);
                    table.ForeignKey(
                        name: "fk_transport_sheets_employees_dispatcher_temp_id",
                        column: x => x.dispatcher_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_transport_sheets_company_id",
                table: "transport_sheets",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_transport_sheets_dispatcher_id",
                table: "transport_sheets",
                column: "dispatcher_id");

            migrationBuilder.CreateIndex(
                name: "ix_transport_sheets_vehicle_license_plate",
                table: "transport_sheets",
                column: "vehicle_license_plate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transport_sheets");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
