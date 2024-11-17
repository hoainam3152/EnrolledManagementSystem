using EnrolledManagementSystem.Entities;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class LoaiHocPhiResponse
    {
        public int MaLoaiHocPhi { get; set; }
        public string TenLoaiHocPhi { get; set; }

        public LoaiHocPhiResponse()
        {
            
        }

        public LoaiHocPhiResponse(LoaiHocPhi lhd)
        {
            this.MaLoaiHocPhi = lhd.MaLoaiHocPhi;
            this.TenLoaiHocPhi = lhd.TenLoaiHocPhi;
        }
    }
}
