using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTable_Diem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoCotDiem",
                table: "Diem",
                newName: "DiemMon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiemMon",
                table: "Diem",
                newName: "SoCotDiem");
        }
    }
}
