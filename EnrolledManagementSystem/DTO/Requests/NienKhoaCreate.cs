using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class NienKhoaCreate
    {
        [Required]
        public string MaNienKhoa { get; set; }
        [Required]
        public string TenNiemKhoa { get; set; }
    }
}
