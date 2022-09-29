using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_comerce_project.Migrations
{
    public partial class ewslatter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Newsletters",
                table: "Newsletters");

            migrationBuilder.RenameTable(
                name: "Newsletters",
                newName: "Newsletter");

            migrationBuilder.AddColumn<string>(
                name: "MessageInfo",
                table: "SocieteInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Newsletter",
                table: "Newsletter",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Newsletter",
                table: "Newsletter");

            migrationBuilder.DropColumn(
                name: "MessageInfo",
                table: "SocieteInfos");

            migrationBuilder.RenameTable(
                name: "Newsletter",
                newName: "Newsletters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Newsletters",
                table: "Newsletters",
                column: "Id");
        }
    }
}
