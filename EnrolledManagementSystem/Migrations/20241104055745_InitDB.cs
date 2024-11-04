using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "Khoa_Khoi",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa_Khoi", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDiem",
                columns: table => new
                {
                    MaLoaiDiem = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenLoaiDiem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HeSo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDiem", x => x.MaLoaiDiem);
                });

            migrationBuilder.CreateTable(
                name: "NienKhoa",
                columns: table => new
                {
                    MaNienKhoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenNiemKhoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NienKhoa", x => x.MaNienKhoa);
                });

            migrationBuilder.CreateTable(
                name: "To_BoMon",
                columns: table => new
                {
                    MaToBoMon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenToBoMon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_BoMon", x => x.MaToBoMon);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaNienKhoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaKhoaKhoi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoLuongHocVien = table.Column<int>(type: "int", nullable: false),
                    HocPhi = table.Column<double>(type: "float", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.MaLop);
                    table.ForeignKey(
                        name: "FK_LopHoc_Khoa_Khoi_MaKhoaKhoi",
                        column: x => x.MaKhoaKhoi,
                        principalTable: "Khoa_Khoi",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LopHoc_NienKhoa_MaNienKhoa",
                        column: x => x.MaNienKhoa,
                        principalTable: "NienKhoa",
                        principalColumn: "MaNienKhoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    MaMonHoc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenMonHoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaToBoMon = table.Column<int>(type: "int", nullable: false),
                    MaKhoaKhoi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.MaMonHoc);
                    table.ForeignKey(
                        name: "FK_MonHoc_Khoa_Khoi_MaKhoaKhoi",
                        column: x => x.MaKhoaKhoi,
                        principalTable: "Khoa_Khoi",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonHoc_To_BoMon_MaToBoMon",
                        column: x => x.MaToBoMon,
                        principalTable: "To_BoMon",
                        principalColumn: "MaToBoMon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDiemMon",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaMon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaLoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoCotDiem = table.Column<int>(type: "int", nullable: false),
                    SoCotDiemBatBuoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDiemMon", x => new { x.MaKhoa, x.MaMon, x.MaLoai });
                    table.ForeignKey(
                        name: "FK_LoaiDiemMon_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoaiDiemMon_LoaiDiem_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "LoaiDiem",
                        principalColumn: "MaLoaiDiem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoaiDiemMon_MonHoc_MaMon",
                        column: x => x.MaMon,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDiemMon_MaLoai",
                table: "LoaiDiemMon",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDiemMon_MaMon",
                table: "LoaiDiemMon",
                column: "MaMon");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaKhoaKhoi",
                table: "LopHoc",
                column: "MaKhoaKhoi");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaNienKhoa",
                table: "LopHoc",
                column: "MaNienKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaKhoaKhoi",
                table: "MonHoc",
                column: "MaKhoaKhoi");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaToBoMon",
                table: "MonHoc",
                column: "MaToBoMon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoaiDiemMon");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "LoaiDiem");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "NienKhoa");

            migrationBuilder.DropTable(
                name: "Khoa_Khoi");

            migrationBuilder.DropTable(
                name: "To_BoMon");
        }
    }
}
