using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class secondConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emp",
                table: "Emp");

            migrationBuilder.RenameTable(
                name: "Emp",
                newName: "Emps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emps",
                table: "Emps",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emps",
                table: "Emps");

            migrationBuilder.RenameTable(
                name: "Emps",
                newName: "Emp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emp",
                table: "Emp",
                column: "id");
        }
    }
}
