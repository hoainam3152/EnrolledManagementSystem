using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class QuyenNguoiDungRequest
    {
        [Required]
        public string TenQuyen { get; set; }
    }
}
