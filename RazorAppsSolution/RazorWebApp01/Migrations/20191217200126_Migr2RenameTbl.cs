using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorWebApp01.Migrations
{
    public partial class Migr2RenameTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Nt",
                table: "Nt");

            migrationBuilder.RenameTable(
                name: "Nt",
                newName: "Nts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nts",
                table: "Nts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Nts",
                table: "Nts");

            migrationBuilder.RenameTable(
                name: "Nts",
                newName: "Nt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nt",
                table: "Nt",
                column: "Id");
        }
    }
}
