using EnrolledManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class LichNghiResponse
    {
        public int MaLichNghi { get; set; }
        public string TenNgayNghi { get; set; }
        public string LyDo { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }

        public LichNghiResponse()
        {
                
        }

        public LichNghiResponse(LichNghi ln)
        {
            this.MaLichNghi = ln.MaLichNghi;
            this.TenNgayNghi = ln.TenNgayNghi;
            this.LyDo = ln.LyDo;
            this.ThoiGianBatDau = ln.ThoiGianBatDau;
            this.ThoiGianKetThuc = ln.ThoiGianKetThuc;
        }
    }
}
