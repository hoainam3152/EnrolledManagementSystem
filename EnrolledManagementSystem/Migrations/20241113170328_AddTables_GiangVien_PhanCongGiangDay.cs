using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class AddTables_GiangVien_PhanCongGiangDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "LopHoc",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    MaGiangVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaSoThue = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenDemVaTen = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaMonDayChinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaMonDayKiemNhiem = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangVien", x => x.MaGiangVien);
                    table.ForeignKey(
                        name: "FK_GiangVien_MonHoc_MaMonDayChinh",
                        column: x => x.MaMonDayChinh,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiangVien_MonHoc_MaMonDayKiemNhiem",
                        column: x => x.MaMonDayKiemNhiem,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc");
                });

            migrationBuilder.CreateTable(
                name: "PhanCongGiangDay",
                columns: table => new
                {
                    MaLopHoc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaMonHoc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaGiangVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhongHoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Thu = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioBatDau = table.Column<TimeSpan>(type: "time", nullable: false),
                    GioKetThuc = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCongGiangDay", x => new { x.MaLopHoc, x.MaMonHoc, x.MaGiangVien });
                    table.ForeignKey(
                        name: "FK_PhanCongGiangDay_GiangVien_MaGiangVien",
                        column: x => x.MaGiangVien,
                        principalTable: "GiangVien",
                        principalColumn: "MaGiangVien");
                    table.ForeignKey(
                        name: "FK_PhanCongGiangDay_LopHoc_MaLopHoc",
                        column: x => x.MaLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop");
                    table.ForeignKey(
                        name: "FK_PhanCongGiangDay_MonHoc_MaMonHoc",
                        column: x => x.MaMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_MaMonDayChinh",
                table: "GiangVien",
                column: "MaMonDayChinh");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_MaMonDayKiemNhiem",
                table: "GiangVien",
                column: "MaMonDayKiemNhiem");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongGiangDay_MaGiangVien",
                table: "PhanCongGiangDay",
                column: "MaGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongGiangDay_MaMonHoc",
                table: "PhanCongGiangDay",
                column: "MaMonHoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhanCongGiangDay");

            migrationBuilder.DropTable(
                name: "GiangVien");

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "LopHoc",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
