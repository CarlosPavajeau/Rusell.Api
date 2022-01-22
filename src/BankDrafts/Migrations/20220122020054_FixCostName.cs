using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusell.BankDrafts.Migrations
{
    public partial class FixCostName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "company",
                table: "bank_drafts",
                newName: "cost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cost",
                table: "bank_drafts",
                newName: "company");
        }
    }
}
