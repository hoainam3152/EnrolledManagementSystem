using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("LopHoc")]
    public class LopHoc
    {
        [Key]
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string MaNienKhoa { get; set; }
        public string MaKhoaKhoi { get; set; }
        public int SoLuongHocVien { get; set; }
        public double HocPhi { get; set; }
        public string MoTat { get; set; }
        public string HinhAnh { get; set; }

        [ForeignKey("MaNienKhoa")]
        public NienKhoa NienKhoa { get; set; }
        [ForeignKey("MaKhoaKhoi")]
        public Khoa_Khoi Khoa_Khoi { get; set; }
    }
}
