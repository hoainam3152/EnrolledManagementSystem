using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("LoaiHocPhi")]
    public class LoaiHocPhi
    {
        [Key]
        [StringLength(20)]
        public string MaLoaiHocPhi { get; set; }
        [Required]
        [StringLength(50)]
        public string TenLoaiHocPhi { get; set; }

        public ICollection<PhieuThuHocPhi> phieuThuHocPhis { get; set; }
    }
}
