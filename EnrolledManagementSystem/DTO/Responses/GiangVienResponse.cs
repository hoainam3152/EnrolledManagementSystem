using EnrolledManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class GiangVienResponse
    {
        public string ID { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string MaMonDayChinh { get; set; }
        public string? MonDayKiemNhiem { get; set; }
        public string? HinhAnh { get; set; }

        public GiangVienResponse()
        {
            
        }

        public GiangVienResponse(GiangVien gv)
        {
            this.ID = gv.MaGiangVien;
            this.HoTen = gv.Ho + gv.TenDemVaTen;
            this.NgaySinh = gv.NgaySinh;
            this.GioiTinh = gv.GioiTinh;
            this.Email = gv.Email;
            this.DienThoai = gv.DienThoai;
            this.DiaChi = gv.DiaChi;
            this.MaMonDayChinh = gv.MaMonDayChinh;
            this.MonDayKiemNhiem = gv.MonDayKiemNhiem;
            this.HinhAnh = gv.HinhAnh;
        }
    }
}
