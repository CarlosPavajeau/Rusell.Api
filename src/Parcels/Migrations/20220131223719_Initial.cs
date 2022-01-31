using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusell.Parcels.Migrations
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
                    full_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companies", x => x.id);
                });

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
                name: "parcels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    cost = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    vehicle_license_plate = table.Column<string>(type: "text", nullable: true),
                    dispatcher_id = table.Column<string>(type: "text", nullable: false),
                    sender_id = table.Column<string>(type: "text", nullable: false),
                    receiver_id = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_parcels", x => x.id);
                    table.ForeignKey(
                        name: "fk_parcels_clients_receiver_id1",
                        column: x => x.receiver_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_parcels_clients_sender_id1",
                        column: x => x.sender_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_parcels_companies_company_temp_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_parcels_employees_dispatcher_temp_id",
                        column: x => x.dispatcher_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_parcels_company_id",
                table: "parcels",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_parcels_dispatcher_id",
                table: "parcels",
                column: "dispatcher_id");

            migrationBuilder.CreateIndex(
                name: "ix_parcels_receiver_id",
                table: "parcels",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "ix_parcels_sender_id",
                table: "parcels",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "ix_parcels_vehicle_license_plate",
                table: "parcels",
                column: "vehicle_license_plate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parcels");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
