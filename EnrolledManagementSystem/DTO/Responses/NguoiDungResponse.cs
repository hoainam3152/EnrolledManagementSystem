using EnrolledManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class NguoiDungResponse
    {
        public string MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public string? Email { get; set; }
        public int MaVaiTro { get; set; }
        public string? HinhAnh { get; set; }

        public NguoiDungResponse()
        {
            
        }

        public NguoiDungResponse(NguoiDung nd)
        {
            this.MaNguoiDung = nd.MaNguoiDung;
            this.TenNguoiDung = nd.TenNguoiDung;
            this.Email = nd.Email;
            this.MaVaiTro = nd.MaVaiTro;
            this.HinhAnh = nd.HinhAnh;
        }
    }
}
