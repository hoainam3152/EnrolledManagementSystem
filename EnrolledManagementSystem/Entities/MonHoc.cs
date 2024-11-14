using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("MonHoc")]
    public class MonHoc
    {
        [Key]
        [StringLength(20)]
        public string MaMonHoc { get; set; }
        [StringLength(100)]
        public string TenMonHoc { get; set; }
        public int MaToBoMon { get; set; }
        [StringLength(20)]
        public string MaKhoaKhoi { get; set; }

        [ForeignKey("MaToBoMon")]
        public To_BoMon To_BoMon { get; set; }

        [ForeignKey("MaKhoaKhoi")]
        public Khoa_Khoi Khoa_Khoi { get; set; }

        public ICollection<LoaiDiemMon> loaiDiemMons { get; set; }
        public ICollection<PhanCongGiangDay> phanCongGiangDays { get; set; }
        public ICollection<GiangVien> giangViens { get; set; }
    }
}
