using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTable_LoaiHocPhi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiHocPhi",
                table: "LoaiHocPhi");

            migrationBuilder.AddColumn<string>(
                name: "MaLoaiHocPhi",
                table: "PhieuThuHocPhi",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaLoaiHocPhi",
                table: "LoaiHocPhi",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

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
    }
}
