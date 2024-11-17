using EnrolledManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class DangKyResponse
    {
        public string MaHocVien { get; set; }
        public string MaLopHoc { get; set; }
        public bool DaDongHocPhi { get; set; }

        public DangKyResponse()
        {
            
        }

        public DangKyResponse(DangKy dk)
        {
            this.MaHocVien = dk.MaHocVien;
            this.MaLopHoc = dk.MaLopHoc;
            this.DaDongHocPhi = dk.DaDongHocPhi;
        }
    }
}
