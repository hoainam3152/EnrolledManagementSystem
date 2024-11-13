using EnrolledManagementSystem.Entities;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class LoaiDiemMonResponse
    {
        public string MaKhoa { get; set; }
        public string MaMon { get; set; }
        public string MaLoai { get; set; }
        public int SoCotDiem { get; set; }
        public int SoCotDiemBatBuoc { get; set; }

        public LoaiDiemMonResponse()
        {

        }

        public LoaiDiemMonResponse(LoaiDiemMon ldm)
        {
            this.MaKhoa = ldm.MaKhoa;
            this.MaMon = ldm.MaMon;
            this.MaLoai = ldm.MaLoai;
            this.SoCotDiem = ldm.SoCotDiem;
            this.SoCotDiemBatBuoc = ldm.SoCotDiemBatBuoc;
        }
    }
}
