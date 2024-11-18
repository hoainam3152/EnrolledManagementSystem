using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class LichNghiRequest
    {
        [Required]
        public string TenNgayNghi { get; set; }
        public string LyDo { get; set; }
        [Required]
        public DateTime ThoiGianBatDau { get; set; }
        [Required]
        public DateTime ThoiGianKetThuc { get; set; }
    }
}
