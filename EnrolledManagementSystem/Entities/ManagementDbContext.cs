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
        #endregion
    }
}
