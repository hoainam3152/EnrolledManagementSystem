using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("PhanCongGiangDay")]
    public class PhanCongGiangDay
    {
        [StringLength(20)]
        public string MaLopHoc { get; set; }
        [StringLength(20)]
        public string MaMonHoc { get; set; }
        [StringLength(20)]
        public string MaGiangVien { get; set; }
        [StringLength(50)]
        public string PhongHoc { get; set; }
        public string Thu { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }

        [ForeignKey("MaLopHoc")]
        public LopHoc LopHoc { get; set; }
        [ForeignKey("MaMonHoc")]
        public MonHoc MonHoc { get; set; }
        [ForeignKey("MaGiangVien")]
        public GiangVien GiangVien { get; set; }
    }
}
