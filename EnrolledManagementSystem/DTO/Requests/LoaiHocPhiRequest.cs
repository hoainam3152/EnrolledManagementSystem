using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class LoaiHocPhiRequest
    {
        [Required]
        public string TenHocPhi { get; set; }
    }
}
