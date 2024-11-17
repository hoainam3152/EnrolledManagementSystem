using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("VaiTro")]
    public class VaiTro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //thiết lập tự động tăng
        public int MaVaiTro { get; set; }
        [StringLength(100)]
        public string TenVaiTro { get; set; }
        public ICollection<NguoiDung> NguoiDungs { get; set; }
        public ICollection<PhanQuyen> PhanQuyens { get; set; }
    }
}
