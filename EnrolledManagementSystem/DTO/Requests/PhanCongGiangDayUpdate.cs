using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class PhanCongGiangDayUpdate
    {
        [Required]
        public string PhongHoc { get; set; }
        [Required]
        public string Thu { get; set; }
        [Required]
        public DateTime NgayBatDau { get; set; }
        [Required]
        public DateTime NgayKetThuc { get; set; }
        [Required]
        public string GioBatDau { get; set; }
        [Required]
        public string GioKetThuc { get; set; }
    }
}
