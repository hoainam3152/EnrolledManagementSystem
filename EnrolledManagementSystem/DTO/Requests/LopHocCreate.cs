using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class LopHocCreate
    {
        [Required]
        public string MaLop { get; set; }
        [Required]
        public string TenLop { get; set; }
        [Required]
        public string MaNienKhoa { get; set; }
        [Required]
        public string MaKhoaKhoi { get; set; }
        [Required]
        public int SoLuongHocVien { get; set; }
        [Required]
        public double HocPhi { get; set; }
        public string? MoTa { get; set; }
        public string? HinhAnh { get; set; }
    }
}
