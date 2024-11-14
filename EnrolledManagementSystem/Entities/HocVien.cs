using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("HocVien")]
    public class HocVien
    {
        [Key]
        [StringLength(20)]
        public string MaHocVien { get; set; }
        [StringLength(20)]
        public string Ho { get; set; }
        [StringLength(80)]
        public string TenDemVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        [StringLength(3)]
        public string GioiTinh { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(10)]
        public string? DienThoai { get; set; }
        [StringLength(255)]
        public string? DiaChi { get; set; }
        [StringLength(100)]
        public string? HoTenPhuHuynh { get; set; }
        [StringLength(100)]
        public string MatKhau { get; set; }
        [StringLength(20)]
        public string MaLopHoc { get; set; }
        [StringLength(255)]
        public string? HinhAnh { get; set; }

        [ForeignKey("MaLopHoc")]
        public LopHoc LopHoc { get; set; }
    }
}
