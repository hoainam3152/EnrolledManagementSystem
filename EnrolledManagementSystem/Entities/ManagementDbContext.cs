using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Entities
{
    public class ManagementDbContext : DbContext
    {
        public ManagementDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<NienKhoa> NienKhoas { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<To_BoMon> To_BoMons { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<LopHoc> LopHocs { get; set; }
        public DbSet<LoaiDiem> LoaiDiems { get; set; }
        public DbSet<LoaiDiemMon> LoaiDiemMons { get; set; }
        public DbSet<Khoa_Khoi> Khoa_Khois { get; set; }
        public DbSet<GiangVien> GiangViens { get; set; }
        public DbSet<PhanCongGiangDay> PhanCongGiangDays { get; set; }
        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<LoaiHocPhi> LoaiHocPhis { get; set; }
        public DbSet<PhieuThuHocPhi> PhieuThuHocPhis { get; set; }
        public DbSet<LichNghi> LichNghis { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //LoaiDiemMon
            modelBuilder.Entity<LoaiDiemMon>(entity =>
            {
                //Tao nhieu khoa chinh
                entity.HasKey(e => new { e.MaKhoa, e.MaMon, e.MaLoai });

                //Tao khoa ngoai
                entity.HasOne(e => e.Khoa)
                    .WithMany(e => e.loaiDiemMons)
                    .HasForeignKey(e => e.MaKhoa);

                entity.HasOne(e => e.MonHoc)
                    .WithMany(e => e.loaiDiemMons)
                    .HasForeignKey(e => e.MaMon);

                entity.HasOne(e => e.LoaiDiem)
                    .WithMany(e => e.loaiDiemMons)
                    .HasForeignKey(e => e.MaLoai);
            });

            //GiangVien
            modelBuilder.Entity<GiangVien>(entity =>
            {
                //Chuyen kieu DateTime thanh kieu Date trong sql
                entity.Property(e => e.NgaySinh).HasColumnType("date");
            });

            //HocVien
            modelBuilder.Entity<HocVien>(entity =>
            {
                //Chuyen kieu DateTime thanh kieu Date trong sql
                entity.Property(e => e.NgaySinh).HasColumnType("date");
            });

            //PhanCongGiangDay
            modelBuilder.Entity<PhanCongGiangDay>(entity =>
            {
                //Tao nhieu khoa chinh
                entity.HasKey(e => new { e.MaLopHoc, e.MaMonHoc, e.MaGiangVien });

                //Tao khoa ngoai
                entity.HasOne(e => e.LopHoc)
                    .WithMany(e => e.phanCongGiangDays)
                    .HasForeignKey(e => e.MaLopHoc)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.MonHoc)
                    .WithMany(e => e.phanCongGiangDays)
                    .HasForeignKey(e => e.MaMonHoc)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.GiangVien)
                    .WithMany(e => e.phanCongGiangDays)
                    .HasForeignKey(e => e.MaGiangVien)
                    .OnDelete(DeleteBehavior.NoAction);

                //Chuyen kieu DateTime thanh kieu Date trong sql
                entity.Property(e => e.NgayBatDau).HasColumnType("date");
                entity.Property(e => e.NgayKetThuc).HasColumnType("date");

                //Chuyen kieu TimeSpan thanh kieu Time trong sql
                entity.Property(e => e.GioBatDau).HasColumnType("time");
                entity.Property(e => e.GioKetThuc).HasColumnType("time");
            });
        }
    }
}
