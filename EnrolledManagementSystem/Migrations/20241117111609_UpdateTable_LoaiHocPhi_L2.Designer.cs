﻿// <auto-generated />
using System;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnrolledManagementSystem.Migrations
{
    [DbContext(typeof(ManagementDbContext))]
    [Migration("20241117111609_UpdateTable_LoaiHocPhi_L2")]
    partial class UpdateTable_LoaiHocPhi_L2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EnrolledManagementSystem.Entities.ChucVu", b =>
                {
                    b.Property<int>("MaChucVu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChucVu"), 1L, 1);

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaChucVu");

                    b.ToTable("ChucVu");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.DangKy", b =>
                {
                    b.Property<string>("MaHocVien")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaLopHoc")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("DaDongHocPhi")
                        .HasColumnType("bit");

                    b.HasKey("MaHocVien", "MaLopHoc");

                    b.HasIndex("MaLopHoc");

                    b.ToTable("DangKy");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.Diem", b =>
                {
                    b.Property<string>("MaMonHoc")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaLoaiDiem")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaHocVien")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("DaChot")
                        .HasColumnType("bit");

                    b.Property<float>("SoCotDiem")
                        .HasColumnType("real");

                    b.HasKey("MaMonHoc", "MaLoaiDiem", "MaHocVien");

                    b.HasIndex("MaHocVien");

                    b.HasIndex("MaLoaiDiem");

                    b.ToTable("Diem");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.GiangVien", b =>
                {
                    b.Property<string>("MaGiangVien")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("HinhAnh")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Ho")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaMonDayChinh")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaSoThue")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("MatKhau")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MonDayKiemNhiem")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("TenDemVaTen")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("MaGiangVien");

                    b.HasIndex("MaMonDayChinh");

                    b.ToTable("GiangVien");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.HocVien", b =>
                {
                    b.Property<string>("MaHocVien")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DienThoai")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("HinhAnh")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Ho")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("HoTenPhuHuynh")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MaLopHoc")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("TenDemVaTen")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("MaHocVien");

                    b.HasIndex("MaLopHoc");

                    b.ToTable("HocVien");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.Khoa", b =>
                {
                    b.Property<string>("MaKhoa")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaKhoa");

                    b.ToTable("Khoa");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.Khoa_Khoi", b =>
                {
                    b.Property<string>("MaKhoaKhoi")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TenKhoaKhoi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaKhoaKhoi");

                    b.ToTable("Khoa_Khoi");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.LichNghi", b =>
                {
                    b.Property<int>("MaLichNghi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLichNghi"), 1L, 1);

                    b.Property<string>("LyDo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenNgayNghi")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("MaLichNghi");

                    b.ToTable("LichNghi");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.LoaiDiem", b =>
                {
                    b.Property<string>("MaLoaiDiem")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("HeSo")
                        .HasColumnType("int");

                    b.Property<string>("TenLoaiDiem")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoaiDiem");

                    b.ToTable("LoaiDiem");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.LoaiDiemMon", b =>
                {
                    b.Property<string>("MaKhoa")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaMon")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaLoai")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SoCotDiem")
                        .HasColumnType("int");

                    b.Property<int>("SoCotDiemBatBuoc")
                        .HasColumnType("int");

                    b.HasKey("MaKhoa", "MaMon", "MaLoai");

                    b.HasIndex("MaLoai");

                    b.HasIndex("MaMon");

                    b.ToTable("LoaiDiemMon");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.LoaiHocPhi", b =>
                {
                    b.Property<int>("MaLoaiHocPhi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoaiHocPhi"), 1L, 1);

                    b.Property<string>("TenLoaiHocPhi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoaiHocPhi");

                    b.ToTable("LoaiHocPhi");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.LopHoc", b =>
                {
                    b.Property<string>("MaLop")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("HinhAnh")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("HocPhi")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("MaKhoaKhoi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaNienKhoa")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuongHocVien")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLop");

                    b.HasIndex("MaKhoaKhoi");

                    b.HasIndex("MaNienKhoa");

                    b.ToTable("LopHoc");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.MonHoc", b =>
                {
                    b.Property<string>("MaMonHoc")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaKhoaKhoi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("MaToBoMon")
                        .HasColumnType("int");

                    b.Property<string>("TenMonHoc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaMonHoc");

                    b.HasIndex("MaKhoaKhoi");

                    b.HasIndex("MaToBoMon");

                    b.ToTable("MonHoc");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.NguoiDung", b =>
                {
                    b.Property<string>("MaNguoiDung")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("HinhAnh")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("MaVaiTro")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenNguoiDung")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaNguoiDung");

                    b.HasIndex("MaVaiTro");

                    b.ToTable("NguoiDung");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.NhanVien", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("MaChucVu")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayVaoLam")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaNhanVien");

                    b.HasIndex("MaChucVu");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.NienKhoa", b =>
                {
                    b.Property<string>("MaNienKhoa")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TenNienKhoa")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("MaNienKhoa");

                    b.ToTable("NienKhoa");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.PhanCongGiangDay", b =>
                {
                    b.Property<string>("MaLopHoc")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaMonHoc")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaGiangVien")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("GioBatDau")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("GioKetThuc")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("date");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("date");

                    b.Property<string>("PhongHoc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Thu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLopHoc", "MaMonHoc", "MaGiangVien");

                    b.HasIndex("MaGiangVien");

                    b.HasIndex("MaMonHoc");

                    b.ToTable("PhanCongGiangDay");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.PhanQuyen", b =>
                {
                    b.Property<int>("MaVaiTro")
                        .HasColumnType("int");

                    b.Property<int>("MaQuyen")
                        .HasColumnType("int");

                    b.HasKey("MaVaiTro", "MaQuyen");

                    b.HasIndex("MaQuyen");

                    b.ToTable("PhanQuyen");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.PhieuLuongNhanVien", b =>
                {
                    b.Property<int>("MaPhieuLuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhieuLuong"), 1L, 1);

                    b.Property<bool>("DaChotLuong")
                        .HasColumnType("bit");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("LuongNhanVien")
                        .HasColumnType("int");

                    b.Property<string>("MaKhoaHoc")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaNhanVien")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("NgayInPhieu")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SoTienPhuCap")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("TenPhieu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenPhuCap")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaPhieuLuong");

                    b.HasIndex("MaKhoaHoc");

                    b.HasIndex("MaNhanVien");

                    b.ToTable("PhieuLuongNhanVien");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.PhieuThuHocPhi", b =>
                {
                    b.Property<int>("MaPhieuHocPhieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhieuHocPhieu"), 1L, 1);

                    b.Property<decimal>("GiamGia")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("MaHocVien")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("MaLoaiHocPhi")
                        .HasColumnType("int");

                    b.Property<string>("MaLop")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Mota")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("MucThuPhi")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.HasKey("MaPhieuHocPhieu");

                    b.HasIndex("MaHocVien");

                    b.HasIndex("MaLoaiHocPhi");

                    b.HasIndex("MaLop");

                    b.ToTable("PhieuThuHocPhi");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.QuyenNguoiDung", b =>
                {
                    b.Property<int>("MaQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaQuyen"), 1L, 1);

                    b.Property<string>("TenQuyen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaQuyen");

                    b.ToTable("QuyenNguoiDung");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.To_BoMon", b =>
                {
                    b.Property<int>("MaToBoMon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaToBoMon"), 1L, 1);

                    b.Property<string>("TenToBoMon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaToBoMon");

                    b.ToTable("To_BoMon");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.VaiTro", b =>
                {
                    b.Property<int>("MaVaiTro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaVaiTro"), 1L, 1);

                    b.Property<string>("TenVaiTro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaVaiTro");

                    b.ToTable("VaiTro");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.DangKy", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.HocVien", "HocVien")
                        .WithMany("DangKys")
                        .HasForeignKey("MaHocVien")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.LopHoc", "LopHoc")
                        .WithMany("DangKys")
                        .HasForeignKey("MaLopHoc")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("HocVien");

                    b.Navigation("LopHoc");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.Diem", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.HocVien", "HocVien")
                        .WithMany("Diems")
                        .HasForeignKey("MaHocVien")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.LoaiDiem", "LoaiDiem")
                        .WithMany("Diems")
                        .HasForeignKey("MaLoaiDiem")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.MonHoc", "MonHoc")
                        .WithMany("Diems")
                        .HasForeignKey("MaMonHoc")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("HocVien");

                    b.Navigation("LoaiDiem");

                    b.Navigation("MonHoc");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.GiangVien", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.MonHoc", "MonChinh")
                        .WithMany("giangViens")
                        .HasForeignKey("MaMonDayChinh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonChinh");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.HocVien", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.LopHoc", "LopHoc")
                        .WithMany("hocViens")
                        .HasForeignKey("MaLopHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LopHoc");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.LoaiDiemMon", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.Khoa", "Khoa")
                        .WithMany("loaiDiemMons")
                        .HasForeignKey("MaKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.LoaiDiem", "LoaiDiem")
                        .WithMany("loaiDiemMons")
                        .HasForeignKey("MaLoai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.MonHoc", "MonHoc")
                        .WithMany("loaiDiemMons")
                        .HasForeignKey("MaMon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");

                    b.Navigation("LoaiDiem");

                    b.Navigation("MonHoc");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.LopHoc", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.Khoa_Khoi", "Khoa_Khoi")
                        .WithMany("lopHocs")
                        .HasForeignKey("MaKhoaKhoi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.NienKhoa", "NienKhoa")
                        .WithMany("lopHocs")
                        .HasForeignKey("MaNienKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa_Khoi");

                    b.Navigation("NienKhoa");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.MonHoc", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.Khoa_Khoi", "Khoa_Khoi")
                        .WithMany("monHocs")
                        .HasForeignKey("MaKhoaKhoi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.To_BoMon", "To_BoMon")
                        .WithMany("monHocs")
                        .HasForeignKey("MaToBoMon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa_Khoi");

                    b.Navigation("To_BoMon");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.NguoiDung", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.VaiTro", "VaiTro")
                        .WithMany("NguoiDungs")
                        .HasForeignKey("MaVaiTro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.NhanVien", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.ChucVu", "ChucVu")
                        .WithMany("NhanViens")
                        .HasForeignKey("MaChucVu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.PhanCongGiangDay", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.GiangVien", "GiangVien")
                        .WithMany("phanCongGiangDays")
                        .HasForeignKey("MaGiangVien")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.LopHoc", "LopHoc")
                        .WithMany("phanCongGiangDays")
                        .HasForeignKey("MaLopHoc")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.MonHoc", "MonHoc")
                        .WithMany("phanCongGiangDays")
                        .HasForeignKey("MaMonHoc")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("GiangVien");

                    b.Navigation("LopHoc");

                    b.Navigation("MonHoc");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.PhanQuyen", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.QuyenNguoiDung", "QuyenNguoiDung")
                        .WithMany("PhanQuyens")
                        .HasForeignKey("MaQuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.VaiTro", "VaiTro")
                        .WithMany("PhanQuyens")
                        .HasForeignKey("MaVaiTro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuyenNguoiDung");

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.PhieuLuongNhanVien", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.Khoa", "Khoa")
                        .WithMany()
                        .HasForeignKey("MaKhoaHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.NhanVien", "NhanVien")
                        .WithMany("PhieuLuongNhanViens")
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.PhieuThuHocPhi", b =>
                {
                    b.HasOne("EnrolledManagementSystem.Entities.HocVien", "HocVien")
                        .WithMany("PhieuThuHocPhis")
                        .HasForeignKey("MaHocVien")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.LoaiHocPhi", "LoaiHocPhi")
                        .WithMany("PhieuThuHocPhis")
                        .HasForeignKey("MaLoaiHocPhi")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EnrolledManagementSystem.Entities.LopHoc", "LopHoc")
                        .WithMany("PhieuThuHocPhis")
                        .HasForeignKey("MaLop")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("HocVien");

                    b.Navigation("LoaiHocPhi");

                    b.Navigation("LopHoc");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.ChucVu", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.GiangVien", b =>
                {
                    b.Navigation("phanCongGiangDays");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.HocVien", b =>
                {
                    b.Navigation("DangKys");

                    b.Navigation("Diems");

                    b.Navigation("PhieuThuHocPhis");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.Khoa", b =>
                {
                    b.Navigation("loaiDiemMons");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.Khoa_Khoi", b =>
                {
                    b.Navigation("lopHocs");

                    b.Navigation("monHocs");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.LoaiDiem", b =>
                {
                    b.Navigation("Diems");

                    b.Navigation("loaiDiemMons");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.LoaiHocPhi", b =>
                {
                    b.Navigation("PhieuThuHocPhis");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.LopHoc", b =>
                {
                    b.Navigation("DangKys");

                    b.Navigation("PhieuThuHocPhis");

                    b.Navigation("hocViens");

                    b.Navigation("phanCongGiangDays");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.MonHoc", b =>
                {
                    b.Navigation("Diems");

                    b.Navigation("giangViens");

                    b.Navigation("loaiDiemMons");

                    b.Navigation("phanCongGiangDays");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.NhanVien", b =>
                {
                    b.Navigation("PhieuLuongNhanViens");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.NienKhoa", b =>
                {
                    b.Navigation("lopHocs");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.QuyenNguoiDung", b =>
                {
                    b.Navigation("PhanQuyens");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.To_BoMon", b =>
                {
                    b.Navigation("monHocs");
                });

            modelBuilder.Entity("EnrolledManagementSystem.Entities.VaiTro", b =>
                {
                    b.Navigation("NguoiDungs");

                    b.Navigation("PhanQuyens");
                });
#pragma warning restore 612, 618
        }
    }
}
