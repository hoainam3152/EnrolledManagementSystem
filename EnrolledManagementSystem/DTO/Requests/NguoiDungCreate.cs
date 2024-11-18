using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class NguoiDungCreate
    {
        [Required]
        public string MaNguoiDung { get; set; }
        [Required]
        public string TenNguoiDung { get; set; }
        public string? Email { get; set; }
        [Required]
        public int MaVaiTro { get; set; }
        [Required]
        public string MatKhau { get; set; }
        public string? HinhAnh { get; set; }
    }
}
