using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusell.Vehicles.Migrations
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
                name: "vehicles",
                columns: table => new
                {
                    license_plate = table.Column<string>(type: "text", nullable: false),
                    internal_number = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    property_card = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    type = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    mark = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    model = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    model_number = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    color = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    chairs = table.Column<int>(type: "integer", nullable: false),
                    engine_number = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    chassis_number = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    owner_id = table.Column<string>(type: "text", nullable: false),
                    driver_id = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicles", x => x.license_plate);
                    table.ForeignKey(
                        name: "fk_vehicles_employees_driver_id1",
                        column: x => x.driver_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_employees_owner_id1",
                        column: x => x.owner_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_legal_information",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    due_date = table.Column<DateOnly>(type: "date", nullable: false),
                    renovation_date = table.Column<DateOnly>(type: "date", nullable: false),
                    vehicle_license_plate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_legal_information", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicle_legal_information_vehicles_vehicle_temp_id",
                        column: x => x.vehicle_license_plate,
                        principalTable: "vehicles",
                        principalColumn: "license_plate",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_legal_information_vehicle_license_plate",
                table: "vehicle_legal_information",
                column: "vehicle_license_plate");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_chassis_number",
                table: "vehicles",
                column: "chassis_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_company_id",
                table: "vehicles",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_driver_id",
                table: "vehicles",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_engine_number",
                table: "vehicles",
                column: "engine_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_internal_number",
                table: "vehicles",
                column: "internal_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_owner_id",
                table: "vehicles",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_property_card",
                table: "vehicles",
                column: "property_card",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicle_legal_information");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
