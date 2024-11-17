using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class AddTable_QLDoanhThu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuThuHocPhi_LoaiHocPhi_MaLoaiHocPhi",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuThuHocPhi_LopHoc_MaLop",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuThuHocPhi",
                table: "PhieuThuHocPhi");

            migrationBuilder.RenameColumn(
                name: "MaPhieu",
                table: "PhieuThuHocPhi",
                newName: "MaHocVien");

            migrationBuilder.AddColumn<int>(
                name: "MaPhieuHocPhieu",
                table: "PhieuThuHocPhi",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "DaDongHocPhi",
                table: "PhieuThuHocPhi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "LopHoc",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DaChot",
                table: "Diem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuThuHocPhi",
                table: "PhieuThuHocPhi",
                column: "MaPhieuHocPhieu");

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    MaChucVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.MaChucVu);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    MaChucVu = table.Column<int>(type: "int", nullable: false),
                    NgayVaoLam = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_MaChucVu",
                        column: x => x.MaChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "MaChucVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LuongNhanVien",
                columns: table => new
                {
                    MaPhieuLuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayInPhieu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaKhoaHoc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaNhanVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LuongNhanVien = table.Column<int>(type: "int", nullable: false),
                    TenPhuCap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoTienPhuCap = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DaChotLuong = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuongNhanVien", x => x.MaPhieuLuong);
                    table.ForeignKey(
                        name: "FK_LuongNhanVien_Khoa_MaKhoaHoc",
                        column: x => x.MaKhoaHoc,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LuongNhanVien_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThuHocPhi_MaHocVien",
                table: "PhieuThuHocPhi",
                column: "MaHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_LuongNhanVien_MaKhoaHoc",
                table: "LuongNhanVien",
                column: "MaKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LuongNhanVien_MaNhanVien",
                table: "LuongNhanVien",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaChucVu",
                table: "NhanVien",
                column: "MaChucVu");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuThuHocPhi_HocVien_MaHocVien",
                table: "PhieuThuHocPhi",
                column: "MaHocVien",
                principalTable: "HocVien",
                principalColumn: "MaHocVien");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuThuHocPhi_LoaiHocPhi_MaLoaiHocPhi",
                table: "PhieuThuHocPhi",
                column: "MaLoaiHocPhi",
                principalTable: "LoaiHocPhi",
                principalColumn: "MaLoaiHocPhi");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuThuHocPhi_LopHoc_MaLop",
                table: "PhieuThuHocPhi",
                column: "MaLop",
                principalTable: "LopHoc",
                principalColumn: "MaLop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuThuHocPhi_HocVien_MaHocVien",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuThuHocPhi_LoaiHocPhi_MaLoaiHocPhi",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuThuHocPhi_LopHoc_MaLop",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropTable(
                name: "LuongNhanVien");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuThuHocPhi",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_PhieuThuHocPhi_MaHocVien",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropColumn(
                name: "MaPhieuHocPhieu",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropColumn(
                name: "DaDongHocPhi",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "LopHoc");

            migrationBuilder.DropColumn(
                name: "DaChot",
                table: "Diem");

            migrationBuilder.RenameColumn(
                name: "MaHocVien",
                table: "PhieuThuHocPhi",
                newName: "MaPhieu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuThuHocPhi",
                table: "PhieuThuHocPhi",
                column: "MaPhieu");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuThuHocPhi_LoaiHocPhi_MaLoaiHocPhi",
                table: "PhieuThuHocPhi",
                column: "MaLoaiHocPhi",
                principalTable: "LoaiHocPhi",
                principalColumn: "MaLoaiHocPhi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuThuHocPhi_LopHoc_MaLop",
                table: "PhieuThuHocPhi",
                column: "MaLop",
                principalTable: "LopHoc",
                principalColumn: "MaLop",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
