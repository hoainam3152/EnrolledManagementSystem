using EnrolledManagementSystem.Entities;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class ChucVuResponse
    {
        public int MaChucVu { get; set; }
        public string TenChucVu { get; set; }

        public ChucVuResponse()
        {
            
        }

        public ChucVuResponse(ChucVu cv)
        {
            this.MaChucVu = cv.MaChucVu;
            this.TenChucVu = cv.TenChucVu;
        }
    }
}
