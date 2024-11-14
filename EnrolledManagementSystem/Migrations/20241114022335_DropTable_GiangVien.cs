using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class DropTable_GiangVien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiangVien"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayKetThuc",
                table: "PhanCongGiangDay",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBatDau",
                table: "PhanCongGiangDay",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "HocVien",
                columns: table => new
                {
                    MaHocVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenDemVaTen = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HoTenPhuHuynh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaLopHoc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocVien", x => x.MaHocVien);
                    table.ForeignKey(
                        name: "FK_HocVien_LopHoc_MaLopHoc",
                        column: x => x.MaLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_MaLopHoc",
                table: "HocVien",
                column: "MaLopHoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhanCongGiangDay_GiangVien_MaGiangVien",
                table: "PhanCongGiangDay");

            migrationBuilder.DropTable(
                name: "HocVien");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayKetThuc",
                table: "PhanCongGiangDay",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBatDau",
                table: "PhanCongGiangDay",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                table: "GiangVien",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanCongGiangDay_GiangVien_MaGiangVien",
                table: "PhanCongGiangDay",
                column: "MaGiangVien",
                principalTable: "GiangVien",
                principalColumn: "MaGiangVien");
        }
    }
}
