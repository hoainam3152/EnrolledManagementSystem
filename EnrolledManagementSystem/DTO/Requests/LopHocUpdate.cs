using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class LopHocUpdate
    {
        [Required]
        public string TenLop { get; set; }
        [Required]
        public string MaNienKhoa { get; set; }
        [Required]
        public string MaKhoaKhoi { get; set; }
        [Required]
        public int SoLuongHocVien { get; set; }
        [Required]
        public decimal HocPhi { get; set; }
        public string? MoTa { get; set; } = null;
        public string? HinhAnh { get; set; } = null;
    }
}
