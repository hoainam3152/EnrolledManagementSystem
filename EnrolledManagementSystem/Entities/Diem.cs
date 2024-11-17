using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("Diem")]
    public class Diem
    {
        [StringLength(20)]
        public string MaMonHoc { get; set; }
        [StringLength(20)]
        public string MaLoaiDiem { get; set; }
        [StringLength(20)]
        public string MaHocVien { get; set; }
        public float SoCotDiem { get; set; }
        public bool DaChot { get; set; }

        [ForeignKey("MaMonHoc")]
        public MonHoc MonHoc { get; set; }
        [ForeignKey("MaLoaiDiem")]
        public LoaiDiem LoaiDiem { get; set; }
        [ForeignKey("MaHocVien")]
        public HocVien HocVien { get; set; }
    }
}
