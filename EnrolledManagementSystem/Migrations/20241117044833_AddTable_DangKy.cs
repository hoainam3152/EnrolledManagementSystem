using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class AddTable_DangKy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhanQuyens_QuyenNguoiDung_MaQuyen",
                table: "PhanQuyens");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanQuyens_VaiTro_MaVaiTro",
                table: "PhanQuyens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhanQuyens",
                table: "PhanQuyens");

            migrationBuilder.DropColumn(
                name: "DaDongHocPhi",
                table: "PhieuThuHocPhi");

            migrationBuilder.RenameTable(
                name: "PhanQuyens",
                newName: "PhanQuyen");

            migrationBuilder.RenameIndex(
                name: "IX_PhanQuyens_MaQuyen",
                table: "PhanQuyen",
                newName: "IX_PhanQuyen_MaQuyen");

            migrationBuilder.AlterColumn<string>(
                name: "MaSoThue",
                table: "GiangVien",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhanQuyen",
                table: "PhanQuyen",
                columns: new[] { "MaVaiTro", "MaQuyen" });

            migrationBuilder.CreateTable(
                name: "DangKy",
                columns: table => new
                {
                    MaHocVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaLopHoc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DaDongHocPhi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKy", x => new { x.MaHocVien, x.MaLopHoc });
                    table.ForeignKey(
                        name: "FK_DangKy_HocVien_MaHocVien",
                        column: x => x.MaHocVien,
                        principalTable: "HocVien",
                        principalColumn: "MaHocVien");
                    table.ForeignKey(
                        name: "FK_DangKy_LopHoc_MaLopHoc",
                        column: x => x.MaLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangKy_MaLopHoc",
                table: "DangKy",
                column: "MaLopHoc");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanQuyen_QuyenNguoiDung_MaQuyen",
                table: "PhanQuyen",
                column: "MaQuyen",
                principalTable: "QuyenNguoiDung",
                principalColumn: "MaQuyen",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhanQuyen_VaiTro_MaVaiTro",
                table: "PhanQuyen",
                column: "MaVaiTro",
                principalTable: "VaiTro",
                principalColumn: "MaVaiTro",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhanQuyen_QuyenNguoiDung_MaQuyen",
                table: "PhanQuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanQuyen_VaiTro_MaVaiTro",
                table: "PhanQuyen");

            migrationBuilder.DropTable(
                name: "DangKy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhanQuyen",
                table: "PhanQuyen");

            migrationBuilder.RenameTable(
                name: "PhanQuyen",
                newName: "PhanQuyens");

            migrationBuilder.RenameIndex(
                name: "IX_PhanQuyen_MaQuyen",
                table: "PhanQuyens",
                newName: "IX_PhanQuyens_MaQuyen");

            migrationBuilder.AddColumn<bool>(
                name: "DaDongHocPhi",
                table: "PhieuThuHocPhi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "MaSoThue",
                table: "GiangVien",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhanQuyens",
                table: "PhanQuyens",
                columns: new[] { "MaVaiTro", "MaQuyen" });

            migrationBuilder.AddForeignKey(
                name: "FK_PhanQuyens_QuyenNguoiDung_MaQuyen",
                table: "PhanQuyens",
                column: "MaQuyen",
                principalTable: "QuyenNguoiDung",
                principalColumn: "MaQuyen",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhanQuyens_VaiTro_MaVaiTro",
                table: "PhanQuyens",
                column: "MaVaiTro",
                principalTable: "VaiTro",
                principalColumn: "MaVaiTro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
