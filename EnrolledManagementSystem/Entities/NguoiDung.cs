using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        [StringLength(20)]
        public string MaNguoiDung { get; set; }
        [StringLength(100)]
        public string TenNguoiDung { get; set; }
        [StringLength(255)]
        public string? Email { get; set; }
        public int MaVaiTro { get; set; }
        [StringLength(100)]
        public string MatKhau { get; set; }
        [StringLength(255)]
        public string? HinhAnh { get; set; }

        [ForeignKey("MaVaiTro")]
        public VaiTro VaiTro { get; set; }
    }
}
