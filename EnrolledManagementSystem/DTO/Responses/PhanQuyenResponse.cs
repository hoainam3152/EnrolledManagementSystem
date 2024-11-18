using EnrolledManagementSystem.Entities;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class PhanQuyenResponse
    {
        public int MaVaiTro { get; set; }
        public int MaQuyen { get; set; }

        public PhanQuyenResponse()
        {
            
        }

        public PhanQuyenResponse(PhanQuyen pq)
        {
            this.MaVaiTro = pq.MaVaiTro;
            this.MaQuyen = pq.MaQuyen;
        }
    }
}
