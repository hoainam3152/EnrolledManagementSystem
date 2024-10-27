using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("LoaiDiemMon")]
    public class LoaiDiemMon
    {
        [Key]
        public string MaLDM { get; set; }
        public string MaKhoa { get; set; }
        public string MaMon { get; set; }
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
