using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("PhieuThuHocPhi")]
    public class PhieuThuHocPhi
    {
        [Key]
        [StringLength(20)]
        public string MaPhieu { get; set; }
        [StringLength(20)]
        public string MaLop { get; set; }
        [StringLength(20)]
        public string MaLoaiHocPhi { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal MucThuPhi { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal GiamGia { get; set; }
        [StringLength(255)]
        public string Mota { get; set; }
        [StringLength(20)]
        public DateTime NgayTao { get; set; }

        [ForeignKey("MaLop")]
        public LopHoc LopHoc { get; set; }

        [ForeignKey("MaLoaiHocPhi")]
        public LoaiHocPhi LoaiHocPhi { get; set; }
    }
}
