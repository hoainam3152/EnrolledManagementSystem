using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class AddTable_Diem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diem",
                columns: table => new
                {
                    MaMonHoc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaLoaiDiem = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaHocVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoCotDiem = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diem", x => new { x.MaMonHoc, x.MaLoaiDiem, x.MaHocVien });
                    table.ForeignKey(
                        name: "FK_Diem_HocVien_MaHocVien",
                        column: x => x.MaHocVien,
                        principalTable: "HocVien",
                        principalColumn: "MaHocVien");
                    table.ForeignKey(
                        name: "FK_Diem_LoaiDiem_MaLoaiDiem",
                        column: x => x.MaLoaiDiem,
                        principalTable: "LoaiDiem",
                        principalColumn: "MaLoaiDiem");
                    table.ForeignKey(
                        name: "FK_Diem_MonHoc_MaMonHoc",
                        column: x => x.MaMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diem_MaHocVien",
                table: "Diem",
                column: "MaHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_Diem_MaLoaiDiem",
                table: "Diem",
                column: "MaLoaiDiem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diem");
        }
    }
}
