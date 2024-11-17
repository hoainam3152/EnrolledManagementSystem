using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("GiangVien")]
    public class GiangVien
    {
        [Key]
        [StringLength(20)]
        public string MaGiangVien { get; set; }
        [StringLength(13)]
        public string? MaSoThue { get; set; }
        [StringLength(20)]
        public string Ho { get; set; }
        [StringLength(80)]
        public string TenDemVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        [StringLength(3)]
        public string GioiTinh { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(10)]
        public string DienThoai { get; set; }
        [StringLength(255)]
        public string? DiaChi { get; set; }
        [StringLength(20)]
        public string MaMonDayChinh { get; set; }
        [StringLength(100)]
        public string? MonDayKiemNhiem { get; set; }
        [StringLength(100)]
        public string? MatKhau { get; set; }
        [StringLength(255)]
        public string? HinhAnh { get; set; }

        [ForeignKey("MaMonDayChinh")]
        public MonHoc MonChinh { get; set; }

        public ICollection<PhanCongGiangDay> phanCongGiangDays { get; set; }
    }
}
