using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class PhieuLuongCreate
    {
        [Required]
        public string TenPhieu { get; set; }
        [Required]
        public string MaKhoaHoc { get; set; }
        [Required]
        public string MaNhanVien { get; set; }
        [Required]
        public int LuongNhanVien { get; set; }
        public string? TenPhuCap { get; set; }
        public decimal? SoTienPhuCap { get; set; }
        public string? GhiChu { get; set; }
    }
}
