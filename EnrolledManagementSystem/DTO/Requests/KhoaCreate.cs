using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class KhoaCreate
    {
        [Required]
        public string MaKhoa { get; set; }
        [Required]
        public string TenKhoa { get; set; }
    }
}
