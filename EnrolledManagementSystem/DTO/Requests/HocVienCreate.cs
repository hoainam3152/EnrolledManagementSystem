using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class HocVienCreate
    {
        [Required]
        public string MaHocVien { get; set; }
        [Required]
        public string Ho { get; set; }
        [Required]
        public string TenDemVaTen { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public string GioiTinh { get; set; }
        [Required]
        public string Email { get; set; }
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? HoTenPhuHuynh { get; set; }
        [Required]
        public string MatKhau { get; set; }
        [Required]
        public string MaLopHoc { get; set; }
        public string? HinhAnh { get; set; }
    }
}
