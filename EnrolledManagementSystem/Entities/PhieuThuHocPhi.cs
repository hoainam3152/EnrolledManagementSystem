using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("PhieuThuHocPhi")]
    public class PhieuThuHocPhi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhieuHocPhieu { get; set; }
        [StringLength(20)]
        public string MaHocVien { get; set; }
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
        public DateTime NgayTao { get; set; }
        public bool DaDongHocPhi { get; set; }

        [ForeignKey("MaHocVien")]
        public HocVien HocVien { get; set; }
        [ForeignKey("MaLop")]
        public LopHoc LopHoc { get; set; }

        [ForeignKey("MaLoaiHocPhi")]
        public LoaiHocPhi LoaiHocPhi { get; set; }
    }
}
