using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTable_LoaiHocPhi_L2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiHocPhi",
                table: "LoaiHocPhi");

            migrationBuilder.AddColumn<int>(
                name: "MaLoaiHocPhi",
                table: "PhieuThuHocPhi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaLoaiHocPhi",
                table: "LoaiHocPhi",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiHocPhi",
                table: "LoaiHocPhi",
                column: "MaLoaiHocPhi");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThuHocPhi_MaLoaiHocPhi",
                table: "PhieuThuHocPhi",
                column: "MaLoaiHocPhi");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuThuHocPhi_LoaiHocPhi_MaLoaiHocPhi",
                table: "PhieuThuHocPhi",
                column: "MaLoaiHocPhi",
                principalTable: "LoaiHocPhi",
                principalColumn: "MaLoaiHocPhi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuThuHocPhi_LoaiHocPhi_MaLoaiHocPhi",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_PhieuThuHocPhi_MaLoaiHocPhi",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiHocPhi",
                table: "LoaiHocPhi");

            migrationBuilder.DropColumn(
                name: "MaLoaiHocPhi",
                table: "PhieuThuHocPhi");

            migrationBuilder.DropColumn(
                name: "MaLoaiHocPhi",
                table: "LoaiHocPhi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiHocPhi",
                table: "LoaiHocPhi",
                column: "TenLoaiHocPhi");
        }
    }
}
