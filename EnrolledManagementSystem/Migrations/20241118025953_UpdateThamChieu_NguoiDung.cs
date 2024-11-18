using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateThamChieu_NguoiDung : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaNguoiDung",
                table: "NhanVien",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaNguoiDung",
                table: "HocVien",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaNguoiDung",
                table: "GiangVien",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaNguoiDung",
                table: "NhanVien",
                column: "MaNguoiDung",
                unique: true,
                filter: "[MaNguoiDung] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_MaNguoiDung",
                table: "HocVien",
                column: "MaNguoiDung",
                unique: true,
                filter: "[MaNguoiDung] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_MaNguoiDung",
                table: "GiangVien",
                column: "MaNguoiDung",
                unique: true,
                filter: "[MaNguoiDung] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GiangVien_NguoiDung_MaNguoiDung",
                table: "GiangVien",
                column: "MaNguoiDung",
                principalTable: "NguoiDung",
                principalColumn: "MaNguoiDung");

            migrationBuilder.AddForeignKey(
                name: "FK_HocVien_NguoiDung_MaNguoiDung",
                table: "HocVien",
                column: "MaNguoiDung",
                principalTable: "NguoiDung",
                principalColumn: "MaNguoiDung");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_NguoiDung_MaNguoiDung",
                table: "NhanVien",
                column: "MaNguoiDung",
                principalTable: "NguoiDung",
                principalColumn: "MaNguoiDung");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiangVien_NguoiDung_MaNguoiDung",
                table: "GiangVien");

            migrationBuilder.DropForeignKey(
                name: "FK_HocVien_NguoiDung_MaNguoiDung",
                table: "HocVien");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_NguoiDung_MaNguoiDung",
                table: "NhanVien");

            migrationBuilder.DropIndex(
                name: "IX_NhanVien_MaNguoiDung",
                table: "NhanVien");

            migrationBuilder.DropIndex(
                name: "IX_HocVien_MaNguoiDung",
                table: "HocVien");

            migrationBuilder.DropIndex(
                name: "IX_GiangVien_MaNguoiDung",
                table: "GiangVien");

            migrationBuilder.DropColumn(
                name: "MaNguoiDung",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "MaNguoiDung",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "MaNguoiDung",
                table: "GiangVien");
        }
    }
}
