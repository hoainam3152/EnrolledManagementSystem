using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    public partial class UpdateTable_PhanCong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GioKetThuc",
                table: "PhanCongGiangDay",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "GioBatDau",
                table: "PhanCongGiangDay",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "GioKetThuc",
                table: "PhanCongGiangDay",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "GioBatDau",
                table: "PhanCongGiangDay",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);
        }
    }
}
