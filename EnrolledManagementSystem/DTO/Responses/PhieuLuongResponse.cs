using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EnrolledManagementSystem.Entities;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class PhieuLuongResponse
    {
        public int MaPhieuLuong { get; set; }
        public string TenPhieu { get; set; }
        public DateTime NgayInPhieu { get; set; }
        public string MaKhoaHoc { get; set; }
        public string MaNhanVien { get; set; }
        public int LuongNhanVien { get; set; }
        public string? TenPhuCap { get; set; }
        public decimal? SoTienPhuCap { get; set; }
        public string? GhiChu { get; set; }
        public bool DaChotLuong { get; set; }

        public PhieuLuongResponse()
        {
            
        }

        public PhieuLuongResponse(PhieuLuongNhanVien pl)
        {
            this.MaPhieuLuong = pl.MaPhieuLuong;
            this.TenPhieu = pl.TenPhieu;
            this.NgayInPhieu = pl.NgayInPhieu;
            this.MaKhoaHoc = pl.MaKhoaHoc;
            this.MaNhanVien = pl.MaNhanVien;
            this.LuongNhanVien = pl.LuongNhanVien;
            this.TenPhuCap = pl.TenPhuCap;
            this.SoTienPhuCap = pl.SoTienPhuCap;
            this.GhiChu = pl.GhiChu;
            this.DaChotLuong = pl.DaChotLuong;
        }
    }
}
