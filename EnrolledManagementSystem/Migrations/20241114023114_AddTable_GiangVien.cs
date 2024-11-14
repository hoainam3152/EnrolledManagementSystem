using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class AddTable_GiangVien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    MaGiangVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaSoThue = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenDemVaTen = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaMonDayChinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MonDayKiemNhiem = table.Column<string>(type: "nvarchar(100)", maxLength: 20, nullable: true),
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
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PhanCongGiangDay_GiangVien_MaGiangVien",
                table: "PhanCongGiangDay",
                column: "MaGiangVien",
                principalTable: "GiangVien",
                principalColumn: "MaGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_MaMonDayChinh",
                table: "GiangVien",
                column: "MaMonDayChinh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhanCongGiangDay_GiangVien_MaGiangVien",
                table: "PhanCongGiangDay");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanCongGiangDay_GiangVien_MaGiangVien",
                table: "PhanCongGiangDay",
                column: "MaGiangVien",
                principalTable: "GiangVien",
                principalColumn: "MaGiangVien",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
