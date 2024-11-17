using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTable_Diem_L3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diem",
                table: "Diem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diem",
                table: "Diem",
                columns: new[] { "MaMonHoc", "MaLoaiDiem", "MaHocVien", "DiemMon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diem",
                table: "Diem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diem",
                table: "Diem",
                columns: new[] { "MaMonHoc", "MaLoaiDiem", "MaHocVien" });
        }
    }
}
