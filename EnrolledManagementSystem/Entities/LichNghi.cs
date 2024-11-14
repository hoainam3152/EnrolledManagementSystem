using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("LichNghi")]
    public class LichNghi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //thiết lập tự động tăng
        public int MaLichNghi { get; set; }
        [StringLength(80)]
        public string TenNgayNghi { get; set; }
        [StringLength(255)]
        public string LyDo { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
    }
}
