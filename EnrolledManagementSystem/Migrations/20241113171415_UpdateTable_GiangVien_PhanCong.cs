using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTable_GiangVien_PhanCong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiangVien_MonHoc_MaMonDayKiemNhiem",
                table: "GiangVien");

            migrationBuilder.DropIndex(
                name: "IX_GiangVien_MaMonDayKiemNhiem",
                table: "GiangVien");

            migrationBuilder.DropColumn(
                name: "MaMonDayKiemNhiem",
                table: "GiangVien");

            migrationBuilder.AlterColumn<string>(
                name: "Thu",
                table: "PhanCongGiangDay",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MonDayKiemNhiem",
                table: "GiangVien",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonDayKiemNhiem",
                table: "GiangVien");

            migrationBuilder.AlterColumn<int>(
                name: "Thu",
                table: "PhanCongGiangDay",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MaMonDayKiemNhiem",
                table: "GiangVien",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_MaMonDayKiemNhiem",
                table: "GiangVien",
                column: "MaMonDayKiemNhiem");

            migrationBuilder.AddForeignKey(
                name: "FK_GiangVien_MonHoc_MaMonDayKiemNhiem",
                table: "GiangVien",
                column: "MaMonDayKiemNhiem",
                principalTable: "MonHoc",
                principalColumn: "MaMonHoc");
        }
    }
}
