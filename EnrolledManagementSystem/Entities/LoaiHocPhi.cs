using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("LoaiHocPhi")]
    public class LoaiHocPhi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLoaiHocPhi { get; set; }
        [StringLength(50)]
        public string TenLoaiHocPhi { get; set; }

        public ICollection<PhieuThuHocPhi> PhieuThuHocPhis { get; set; }
    }
}
