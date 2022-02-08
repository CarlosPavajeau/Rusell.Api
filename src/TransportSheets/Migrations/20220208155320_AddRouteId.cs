using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusell.TransportSheets.Migrations
{
    public partial class AddRouteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "route_id",
                table: "transport_sheets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_transport_sheets_route_id",
                table: "transport_sheets",
                column: "route_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_transport_sheets_route_id",
                table: "transport_sheets");

            migrationBuilder.DropColumn(
                name: "route_id",
                table: "transport_sheets");
        }
    }
}
