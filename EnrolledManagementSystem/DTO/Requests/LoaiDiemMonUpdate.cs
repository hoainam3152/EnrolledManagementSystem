using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class LoaiDiemMonUpdate
    {
        [Required]
        public int SoCotDiem { get; set; }
        [Required]
        public int SoCotDiemBatBuoc { get; set; }
    }
}
