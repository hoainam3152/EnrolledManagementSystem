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
        [StringLength(100)]
        public string TenLop { get; set; }
        [StringLength(20)]
        public string MaNienKhoa { get; set; }
        [StringLength(20)]
        public string MaKhoaKhoi { get; set; }
        public int SoLuongHocVien { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal HocPhi { get; set; }
        public string? MoTa { get; set; }
        [StringLength(255)]
        public string? HinhAnh { get; set; }

        [ForeignKey("MaNienKhoa")]
        public NienKhoa NienKhoa { get; set; }
        [ForeignKey("MaKhoaKhoi")]
        public Khoa_Khoi Khoa_Khoi { get; set; }

        public ICollection<PhanCongGiangDay> phanCongGiangDays { get; set; }
        public ICollection<HocVien> hocViens { get; set; }
        public ICollection<PhieuThuHocPhi> phieuThuHocPhis { get; set; }
    }
}
