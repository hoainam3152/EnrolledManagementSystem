using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class NguoiDungUpdate
    {
        [Required]
        public string TenNguoiDung { get; set; }
        public string? Email { get; set; }
        [Required]
        public int MaVaiTro { get; set; }
        public string? HinhAnh { get; set; }
    }
}
