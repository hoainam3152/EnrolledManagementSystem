using EnrolledManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class PhanCongGiangDayResponse
    {
        public string MaLopHoc { get; set; }
        public string MaMonHoc { get; set; }
        public string MaGiangVien { get; set; }
        public string PhongHoc { get; set; }
        public string Thu { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string GioBatDau { get; set; }
        public string GioKetThuc { get; set; }

        public PhanCongGiangDayResponse()
        {
                
        }

        public PhanCongGiangDayResponse(PhanCongGiangDay pc)
        {
            this.MaLopHoc = pc.MaLopHoc;
            this.MaMonHoc = pc.MaMonHoc;
            this.MaGiangVien = pc.MaGiangVien;
            this.PhongHoc = pc.PhongHoc;
            this.Thu = pc.Thu;
            this.NgayBatDau = pc.NgayBatDau;
            this.NgayKetThuc = pc.NgayKetThuc;
            this.GioBatDau = pc.GioBatDau;
            this.GioKetThuc = pc.GioKetThuc;
        }
    }
}
