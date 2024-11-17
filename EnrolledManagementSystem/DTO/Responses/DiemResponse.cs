using EnrolledManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class DiemResponse
    {
        public string MaMonHoc { get; set; }
        public string MaLoaiDiem { get; set; }
        public string MaHocVien { get; set; }
        public float DiemMon { get; set; }
        public bool? DaChot { get; set; }

        public DiemResponse()
        {
            
        }

        public DiemResponse(Diem d)
        {
            this.MaMonHoc = d.MaMonHoc;
            this.MaLoaiDiem = d.MaLoaiDiem;
            this.MaHocVien = d.MaHocVien;
            this.DiemMon = d.DiemMon;
            this.DaChot = d.DaChot;
        }
    }
}
