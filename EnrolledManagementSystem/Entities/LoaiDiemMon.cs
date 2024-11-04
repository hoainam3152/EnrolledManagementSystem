using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("LoaiDiemMon")]
    public class LoaiDiemMon
    {
        [Required]
        [StringLength(20)]
        public string MaKhoa { get; set; }
        [Required]
        [StringLength(20)]
        public string MaMon { get; set; }
        [Required]
        [StringLength(20)]
        public string MaLoai { get; set; }
        public int SoCotDiem { get; set; }
        public int SoCotDiemBatBuoc { get; set; }

        [ForeignKey("MaKhoa")]
        public Khoa Khoa { get; set; }
        [ForeignKey("MaMon")]
        public MonHoc MonHoc { get; set; }
        [ForeignKey("MaLoai")]
        public LoaiDiem LoaiDiem { get; set; }
    }
}
