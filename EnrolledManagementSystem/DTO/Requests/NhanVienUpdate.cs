using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class NhanVienUpdate
    {
        [Required]
        public string TenNhanVien { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public int MaChucVu { get; set; }
        [Required]
        public DateTime NgayVaoLam { get; set; }
    }
}
