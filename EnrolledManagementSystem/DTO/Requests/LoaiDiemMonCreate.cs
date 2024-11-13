using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class LoaiDiemMonCreate
    {
        [Required]
        public string MaKhoa { get; set; }
        [Required]
        public string MaMon { get; set; }
        [Required]
        public string MaLoai { get; set; }
        [Required]
        public int SoCotDiem { get; set; }
        [Required]
        public int SoCotDiemBatBuoc { get; set; }
    }
}
