using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class KhoaUpdate
    {
        [Required]
        public string TenKhoa { get; set; }
    }
}
