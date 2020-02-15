using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorWebApp01.Migrations
{
    public partial class Mgr02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Example_Nts_NtId",
                table: "Example");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Example_ExampleID",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Nts_NtId",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Example",
                table: "Example");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Example",
                newName: "Examples");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_NtId",
                table: "Tags",
                newName: "IX_Tags_NtId");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_ExampleID",
                table: "Tags",
                newName: "IX_Tags_ExampleID");

            migrationBuilder.RenameIndex(
                name: "IX_Example_NtId",
                table: "Examples",
                newName: "IX_Examples_NtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examples",
                table: "Examples",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Examples_Nts_NtId",
                table: "Examples",
                column: "NtId",
                principalTable: "Nts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Examples_ExampleID",
                table: "Tags",
                column: "ExampleID",
                principalTable: "Examples",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Nts_NtId",
                table: "Tags",
                column: "NtId",
                principalTable: "Nts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examples_Nts_NtId",
                table: "Examples");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Examples_ExampleID",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Nts_NtId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Examples",
                table: "Examples");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Examples",
                newName: "Example");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_NtId",
                table: "Tag",
                newName: "IX_Tag_NtId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ExampleID",
                table: "Tag",
                newName: "IX_Tag_ExampleID");

            migrationBuilder.RenameIndex(
                name: "IX_Examples_NtId",
                table: "Example",
                newName: "IX_Example_NtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Example",
                table: "Example",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Example_Nts_NtId",
                table: "Example",
                column: "NtId",
                principalTable: "Nts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Example_ExampleID",
                table: "Tag",
                column: "ExampleID",
                principalTable: "Example",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Nts_NtId",
                table: "Tag",
                column: "NtId",
                principalTable: "Nts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
