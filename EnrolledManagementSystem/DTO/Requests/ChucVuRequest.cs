using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class ChucVuRequest
    {
        [Required]
        public string TenChucVu { get; set; }
    }
}
