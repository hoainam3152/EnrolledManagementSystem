using EnrolledManagementSystem.Entities;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class VaiTroResponse
    {
        public int MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }

        public VaiTroResponse()
        {
            
        }

        public VaiTroResponse(VaiTro vt)
        {
            this.MaVaiTro = vt.MaVaiTro;
            this.TenVaiTro = vt.TenVaiTro;
        }
    }
}
