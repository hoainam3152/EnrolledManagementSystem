using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class GiangVienUpdate
    {
        public string? MaSoThue { get; set; }
        public string Ho { get; set; }
        public string TenDemVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string MaMonDayChinh { get; set; }
        public string? MonDayKiemNhiem { get; set; }
        public string? HinhAnh { get; set; }
    }
}
