using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class VaiTroRequest
    {
        [Required]
        public string TenVaiTro { get; set; }
    }
}
