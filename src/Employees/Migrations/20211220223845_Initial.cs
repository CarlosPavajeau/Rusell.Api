using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusell.Employees.Migrations
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
                    first_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    middle_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    first_surname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    second_surname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    type = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_employees_company_id",
                table: "employees",
                column: "company_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
