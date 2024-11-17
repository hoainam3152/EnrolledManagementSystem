using EnrolledManagementSystem.Entities;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class HocVienResponse
    {
        public string MaHocVien { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? HoTenPhuHuynh { get; set; }
        public string MaLopHoc { get; set; }
        public string? HinhAnh { get; set; }

        public HocVienResponse()
        {
            
        }

        public HocVienResponse(HocVien hv)
        {
            this.MaHocVien = hv.MaHocVien;
            this.HoTen = hv.Ho + hv.TenDemVaTen;
            this.NgaySinh = hv.NgaySinh;
            this.GioiTinh = hv.GioiTinh;
            this.Email = hv.Email;
            this.DienThoai = hv.DienThoai;
            this.DiaChi = hv.DiaChi;
            this.HoTenPhuHuynh = hv.HoTenPhuHuynh;
            this.MaLopHoc = hv.MaLopHoc;
            this.HinhAnh = hv.HinhAnh;
        }
    }
}
