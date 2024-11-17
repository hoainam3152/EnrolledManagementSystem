using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class GiangVienCreate
    {
        [Required]
        public string MaGiangVien { get; set; }
        public string? MaSoThue { get; set; }
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
        [Required]
        public string DienThoai { get; set; }
        public string? DiaChi { get; set; }
        [Required]
        public string MaMonDayChinh { get; set; }
        public string? MonDayKiemNhiem { get; set; }
        public string? MatKhau { get; set; }
        public string? HinhAnh { get; set; }
    }
}
