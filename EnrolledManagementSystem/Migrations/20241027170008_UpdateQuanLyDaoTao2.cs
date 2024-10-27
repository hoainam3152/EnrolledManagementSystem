using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateQuanLyDaoTao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiDiemMon",
                columns: table => new
                {
                    MaLDM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaLoai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoCotDiem = table.Column<int>(type: "int", nullable: false),
                    SoCotDiemBatBuoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDiemMon", x => x.MaLDM);
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
                name: "IX_LoaiDiemMon_MaKhoa",
                table: "LoaiDiemMon",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDiemMon_MaLoai",
                table: "LoaiDiemMon",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDiemMon_MaMon",
                table: "LoaiDiemMon",
                column: "MaMon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoaiDiemMon");
        }
    }
}
