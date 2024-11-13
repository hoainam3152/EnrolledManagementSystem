using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class KhoaKhoiUpdate
    {
        [Required]
        public string TenKhoaKhoi { get; set; }
    }
}
