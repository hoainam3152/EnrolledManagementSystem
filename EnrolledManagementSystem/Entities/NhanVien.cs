using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        [StringLength(20)]
        public string MaNhanVien { get; set; }
        [StringLength(100)]
        public string TenNhanVien { get; set; }
        [StringLength(20)]
        public DateTime NgaySinh { get; set; }
        public int MaChucVu { get; set; }
        public DateTime NgayVaoLam { get; set; }
        [StringLength(20)]
        public string? MaNguoiDung { get; set; }

        [ForeignKey("MaChucVu")]
        public ChucVu ChucVu { get; set; }
        [ForeignKey("MaNguoiDung")]
        public NguoiDung NguoiDung { get; set; }

        public ICollection<PhieuLuongNhanVien> PhieuLuongNhanViens { get; set; }
    }
}
