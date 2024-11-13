using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class MonHocUpdate
    {
        [Required]
        public string TenMonHoc { get; set; }
        [Required]
        public int MaToBoMon { get; set; }
        [Required]
        public string MaKhoaKhoi { get; set; }
    }
}
