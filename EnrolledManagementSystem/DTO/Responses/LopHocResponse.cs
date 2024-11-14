using EnrolledManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class LopHocResponse
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string MaNienKhoa { get; set; }
        public string MaKhoaKhoi { get; set; }
        public int SoLuongHocVien { get; set; }
        public decimal HocPhi { get; set; }
        public string? MoTa { get; set; } = null;
        public string? HinhAnh { get; set; } = null;

        public LopHocResponse()
        {
            
        }

        public LopHocResponse(LopHoc lh)
        {
            this.MaLop = lh.MaLop;
            this.TenLop = lh.TenLop;
            this.MaNienKhoa = lh.MaNienKhoa;
            this.MaKhoaKhoi = lh.MaKhoaKhoi;
            this.SoLuongHocVien = lh.SoLuongHocVien;
            this.HocPhi = lh.HocPhi;
            this.MoTa = lh.MoTa;
            this.HinhAnh = lh.HinhAnh;
        }
    }
}
