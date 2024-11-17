using EnrolledManagementSystem.Entities;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class NhanVienResponse
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public int MaChucVu { get; set; }
        public DateTime NgayVaoLam { get; set; }

        public NhanVienResponse()
        {
            
        }

        public NhanVienResponse(NhanVien nv)
        {
            this.MaNhanVien = nv.MaNhanVien;
            this.TenNhanVien = nv.TenNhanVien;
            this.NgaySinh = nv.NgaySinh;
            this.MaChucVu = nv.MaChucVu;
            this.NgayVaoLam = nv.NgayVaoLam;
        }
    }
}
