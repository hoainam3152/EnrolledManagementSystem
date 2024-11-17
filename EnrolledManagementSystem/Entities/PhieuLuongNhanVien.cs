using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("PhieuLuongNhanVien")]
    public class PhieuLuongNhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhieuLuong { get; set; }
        [StringLength(50)]
        public string TenPhieu { get; set; }
        public DateTime NgayInPhieu { get; set; }
        [StringLength(20)]
        public string MaKhoaHoc { get; set; }
        [StringLength(20)]
        public string MaNhanVien { get; set; }
        public int LuongNhanVien { get; set; }
        [StringLength(100)]
        public string? TenPhuCap { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal SoTienPhuCap { get; set; }
        [StringLength(255)]
        public string? GhiChu { get; set; }
        public bool DaChotLuong { get; set; }

        [ForeignKey("MaKhoaHoc")]
        public Khoa Khoa { get; set; }
        [ForeignKey("MaNhanVien")]
        public NhanVien NhanVien { get; set; }
    }
}
