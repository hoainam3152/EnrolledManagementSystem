using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //thiết lập tự động tăng
        public int MaChucVu { get; set; }
        [StringLength(100)]
        public string TenChucVu { get; set; }
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}
