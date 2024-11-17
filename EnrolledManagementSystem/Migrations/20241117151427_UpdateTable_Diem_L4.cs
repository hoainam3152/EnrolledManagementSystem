using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTable_Diem_L4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diem",
                table: "Diem");

            migrationBuilder.AddColumn<int>(
                name: "MaDiem",
                table: "Diem",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diem",
                table: "Diem",
                column: "MaDiem");

            migrationBuilder.CreateIndex(
                name: "IX_Diem_MaMonHoc",
                table: "Diem",
                column: "MaMonHoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diem",
                table: "Diem");

            migrationBuilder.DropIndex(
                name: "IX_Diem_MaMonHoc",
                table: "Diem");

            migrationBuilder.DropColumn(
                name: "MaDiem",
                table: "Diem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diem",
                table: "Diem",
                columns: new[] { "MaMonHoc", "MaLoaiDiem", "MaHocVien", "DiemMon" });
        }
    }
}
