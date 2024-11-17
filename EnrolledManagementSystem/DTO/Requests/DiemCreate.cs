using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class DiemCreate
    {
        [Required]
        public string MaMonHoc { get; set; }
        [Required]
        public string MaLoaiDiem { get; set; }
        [Required]
        public string MaHocVien { get; set; }
        [Required]
        public float DiemMon { get; set; }
    }
}
