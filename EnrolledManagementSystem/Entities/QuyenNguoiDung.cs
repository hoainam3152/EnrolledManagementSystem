using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("QuyenNguoiDung")]
    public class QuyenNguoiDung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //thiết lập tự động tăng
        public int MaQuyen { get; set; }
        [StringLength(100)]
        public string TenQuyen { get; set; }
        public ICollection<PhanQuyen> PhanQuyens { get; set; }
    }
}
