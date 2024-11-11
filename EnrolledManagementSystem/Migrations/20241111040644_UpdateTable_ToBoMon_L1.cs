using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTable_ToBoMon_L1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "To_BoMonMaToBoMon",
                table: "LopHoc",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_To_BoMonMaToBoMon",
                table: "LopHoc",
                column: "To_BoMonMaToBoMon");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHoc_To_BoMon_To_BoMonMaToBoMon",
                table: "LopHoc",
                column: "To_BoMonMaToBoMon",
                principalTable: "To_BoMon",
                principalColumn: "MaToBoMon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHoc_To_BoMon_To_BoMonMaToBoMon",
                table: "LopHoc");

            migrationBuilder.DropIndex(
                name: "IX_LopHoc_To_BoMonMaToBoMon",
                table: "LopHoc");

            migrationBuilder.DropColumn(
                name: "To_BoMonMaToBoMon",
                table: "LopHoc");
        }
    }
}
