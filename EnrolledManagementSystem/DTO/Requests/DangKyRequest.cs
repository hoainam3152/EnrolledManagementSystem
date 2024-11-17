using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class DangKyRequest
    {
        [Required]
        public string MaHocVien { get; set; }
        [Required]
        public string MaLopHoc { get; set; }
    }
}
