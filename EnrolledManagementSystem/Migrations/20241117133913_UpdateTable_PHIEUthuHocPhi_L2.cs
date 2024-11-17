using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTable_PHIEUthuHocPhi_L2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaPhieuHocPhieu",
                table: "PhieuThuHocPhi",
                newName: "MaPhieuThu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaPhieuThu",
                table: "PhieuThuHocPhi",
                newName: "MaPhieuHocPhieu");
        }
    }
}
