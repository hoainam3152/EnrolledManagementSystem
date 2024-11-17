using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTablePhieuLuong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SoTienPhuCap",
                table: "PhieuLuongNhanVien",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SoTienPhuCap",
                table: "PhieuLuongNhanVien",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);
        }
    }
}
