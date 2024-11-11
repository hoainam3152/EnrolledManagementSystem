using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTable_Khoa_Khoi_L1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenKhoa",
                table: "Khoa_Khoi",
                newName: "TenKhoaKhoi");

            migrationBuilder.RenameColumn(
                name: "MaKhoa",
                table: "Khoa_Khoi",
                newName: "MaKhoaKhoi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenKhoaKhoi",
                table: "Khoa_Khoi",
                newName: "TenKhoa");

            migrationBuilder.RenameColumn(
                name: "MaKhoaKhoi",
                table: "Khoa_Khoi",
                newName: "MaKhoa");
        }
    }
}
