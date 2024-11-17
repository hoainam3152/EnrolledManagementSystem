using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTable_PhieuLuongNV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LuongNhanVien_Khoa_MaKhoaHoc",
                table: "LuongNhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK_LuongNhanVien_NhanVien_MaNhanVien",
                table: "LuongNhanVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LuongNhanVien",
                table: "LuongNhanVien");

            migrationBuilder.RenameTable(
                name: "LuongNhanVien",
                newName: "PhieuLuongNhanVien");

            migrationBuilder.RenameIndex(
                name: "IX_LuongNhanVien_MaNhanVien",
                table: "PhieuLuongNhanVien",
                newName: "IX_PhieuLuongNhanVien_MaNhanVien");

            migrationBuilder.RenameIndex(
                name: "IX_LuongNhanVien_MaKhoaHoc",
                table: "PhieuLuongNhanVien",
                newName: "IX_PhieuLuongNhanVien_MaKhoaHoc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuLuongNhanVien",
                table: "PhieuLuongNhanVien",
                column: "MaPhieuLuong");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuLuongNhanVien_Khoa_MaKhoaHoc",
                table: "PhieuLuongNhanVien",
                column: "MaKhoaHoc",
                principalTable: "Khoa",
                principalColumn: "MaKhoa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuLuongNhanVien_NhanVien_MaNhanVien",
                table: "PhieuLuongNhanVien",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuLuongNhanVien_Khoa_MaKhoaHoc",
                table: "PhieuLuongNhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuLuongNhanVien_NhanVien_MaNhanVien",
                table: "PhieuLuongNhanVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuLuongNhanVien",
                table: "PhieuLuongNhanVien");

            migrationBuilder.RenameTable(
                name: "PhieuLuongNhanVien",
                newName: "LuongNhanVien");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuLuongNhanVien_MaNhanVien",
                table: "LuongNhanVien",
                newName: "IX_LuongNhanVien_MaNhanVien");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuLuongNhanVien_MaKhoaHoc",
                table: "LuongNhanVien",
                newName: "IX_LuongNhanVien_MaKhoaHoc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LuongNhanVien",
                table: "LuongNhanVien",
                column: "MaPhieuLuong");

            migrationBuilder.AddForeignKey(
                name: "FK_LuongNhanVien_Khoa_MaKhoaHoc",
                table: "LuongNhanVien",
                column: "MaKhoaHoc",
                principalTable: "Khoa",
                principalColumn: "MaKhoa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LuongNhanVien_NhanVien_MaNhanVien",
                table: "LuongNhanVien",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
