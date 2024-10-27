using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateQuanLyDaoTao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHoc_Khoa_MaKhoa",
                table: "LopHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_Khoa_MaKhoa",
                table: "MonHoc");

            migrationBuilder.RenameColumn(
                name: "MaKhoa",
                table: "MonHoc",
                newName: "MaKhoaKhoi");

            migrationBuilder.RenameIndex(
                name: "IX_MonHoc_MaKhoa",
                table: "MonHoc",
                newName: "IX_MonHoc_MaKhoaKhoi");

            migrationBuilder.RenameColumn(
                name: "MaKhoa",
                table: "LopHoc",
                newName: "MaKhoaKhoi");

            migrationBuilder.RenameIndex(
                name: "IX_LopHoc_MaKhoa",
                table: "LopHoc",
                newName: "IX_LopHoc_MaKhoaKhoi");

            migrationBuilder.CreateTable(
                name: "Khoa_Khoi",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa_Khoi", x => x.MaKhoa);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LopHoc_Khoa_Khoi_MaKhoaKhoi",
                table: "LopHoc",
                column: "MaKhoaKhoi",
                principalTable: "Khoa_Khoi",
                principalColumn: "MaKhoa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_Khoa_Khoi_MaKhoaKhoi",
                table: "MonHoc",
                column: "MaKhoaKhoi",
                principalTable: "Khoa_Khoi",
                principalColumn: "MaKhoa",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHoc_Khoa_Khoi_MaKhoaKhoi",
                table: "LopHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_Khoa_Khoi_MaKhoaKhoi",
                table: "MonHoc");

            migrationBuilder.DropTable(
                name: "Khoa_Khoi");

            migrationBuilder.RenameColumn(
                name: "MaKhoaKhoi",
                table: "MonHoc",
                newName: "MaKhoa");

            migrationBuilder.RenameIndex(
                name: "IX_MonHoc_MaKhoaKhoi",
                table: "MonHoc",
                newName: "IX_MonHoc_MaKhoa");

            migrationBuilder.RenameColumn(
                name: "MaKhoaKhoi",
                table: "LopHoc",
                newName: "MaKhoa");

            migrationBuilder.RenameIndex(
                name: "IX_LopHoc_MaKhoaKhoi",
                table: "LopHoc",
                newName: "IX_LopHoc_MaKhoa");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHoc_Khoa_MaKhoa",
                table: "LopHoc",
                column: "MaKhoa",
                principalTable: "Khoa",
                principalColumn: "MaKhoa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_Khoa_MaKhoa",
                table: "MonHoc",
                column: "MaKhoa",
                principalTable: "Khoa",
                principalColumn: "MaKhoa",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
