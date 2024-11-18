using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class PhanQuyenRequest
    {
        [Required]
        public int MaVaiTro { get; set; }
        [Required]
        public int MaQuyen { get; set; }
    }
}
