using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class AddTable_LoaiHocPhi_PhieuThuHP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "HocPhi",
                table: "LopHoc",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "LoaiHocPhi",
                columns: table => new
                {
                    MaLoaiHocPhi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenLoaiHocPhi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHocPhi", x => x.MaLoaiHocPhi);
                });

            migrationBuilder.CreateTable(
                name: "PhieuThuHocPhi",
                columns: table => new
                {
                    MaPhieu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaLop = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaLoaiHocPhi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MucThuPhi = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    GiamGia = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuThuHocPhi", x => x.MaPhieu);
                    table.ForeignKey(
                        name: "FK_PhieuThuHocPhi_LoaiHocPhi_MaLoaiHocPhi",
                        column: x => x.MaLoaiHocPhi,
                        principalTable: "LoaiHocPhi",
                        principalColumn: "MaLoaiHocPhi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuThuHocPhi_LopHoc_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThuHocPhi_MaLoaiHocPhi",
                table: "PhieuThuHocPhi",
                column: "MaLoaiHocPhi");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThuHocPhi_MaLop",
                table: "PhieuThuHocPhi",
                column: "MaLop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuThuHocPhi");

            migrationBuilder.DropTable(
                name: "LoaiHocPhi");

            migrationBuilder.AlterColumn<double>(
                name: "HocPhi",
                table: "LopHoc",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");
        }
    }
}
