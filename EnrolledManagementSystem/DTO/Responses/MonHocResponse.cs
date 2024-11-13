using EnrolledManagementSystem.Entities;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class MonHocResponse
    {
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int MaToBoMon { get; set; }
        public string MaKhoaKhoi { get; set; }

        public MonHocResponse()
        {
            
        }

        public MonHocResponse(MonHoc mh)
        {
            this.MaMonHoc = mh.MaMonHoc;
            this.TenMonHoc = mh.TenMonHoc;
            this.MaToBoMon = mh.MaToBoMon;
            this.MaKhoaKhoi = mh.MaKhoaKhoi;
        }
    }
}
