using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("LopHoc")]
    public class LopHoc
    {
        [Key]
        [StringLength(20)]
        public string MaLop { get; set; }
        [Required]
        [StringLength(100)]
        public string TenLop { get; set; }
        [Required]
        [StringLength(20)]
        public string MaNienKhoa { get; set; }
        [Required]
        [StringLength(20)]
        public string MaKhoaKhoi { get; set; }
        public int SoLuongHocVien { get; set; }
        public double HocPhi { get; set; }
        public string? MoTa { get; set; } = null;
        public string? HinhAnh { get; set; } = null;

        [ForeignKey("MaNienKhoa")]
        public NienKhoa NienKhoa { get; set; }
        [ForeignKey("MaKhoaKhoi")]
        public Khoa_Khoi Khoa_Khoi { get; set; }
    }
}
