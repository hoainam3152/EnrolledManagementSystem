using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class DiemUpdate
    {
        [Required]
        public float DiemMon { get; set; }
    }
}
