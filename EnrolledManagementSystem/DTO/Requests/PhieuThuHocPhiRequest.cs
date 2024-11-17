using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class PhieuThuHocPhiRequest
    {
        [Required]
        public string MaHocVien { get; set; }
        [Required]
        public string MaLop { get; set; }
        [Required]
        public int MaLoaiHocPhi { get; set; }
        [Required]
        public decimal MucThuPhi { get; set; }
        public decimal? GiamGia { get; set; }
        public string? GhiChu { get; set; }
    }
}
