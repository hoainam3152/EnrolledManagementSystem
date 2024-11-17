using EnrolledManagementSystem.Entities;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class PhieuThuHocPhiResponse
    {
        public int MaPhieuThu { get; set; }
        public string MaHocVien { get; set; }
        public string MaLop { get; set; }
        public int MaLoaiHocPhi { get; set; }
        public decimal MucThuPhi { get; set; }
        public decimal? GiamGia { get; set; }
        public string? GhiChu { get; set; }
        public DateTime NgayTao { get; set; }

        public PhieuThuHocPhiResponse()
        {
            
        }

        public PhieuThuHocPhiResponse(PhieuThuHocPhi ph)
        {
            this.MaPhieuThu = ph.MaPhieuThu;
            this.MaHocVien = ph.MaHocVien;
            this.MaLop = ph.MaLop;
            this.MaLoaiHocPhi = ph.MaLoaiHocPhi;
            this.MucThuPhi = ph.MucThuPhi;
            this.GiamGia = ph.GiamGia;
            this.GhiChu = ph.GhiChu;
            this.NgayTao = ph.NgayTao;
        }
    }
}
