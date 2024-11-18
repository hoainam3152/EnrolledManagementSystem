using EnrolledManagementSystem.Entities;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class QuyenNguoiDungResponse
    {
        public int MaQuyen { get; set; }
        public string TenQuyen { get; set; }

        public QuyenNguoiDungResponse()
        {
            
        }

        public QuyenNguoiDungResponse(QuyenNguoiDung qnd)
        {
            this.MaQuyen = qnd.MaQuyen;
            this.TenQuyen = qnd.TenQuyen;
        }
    }
}
