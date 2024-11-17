using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class HocVienService
    {
        private readonly ManagementDbContext _context;

        public HocVienService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HocVienResponse>> GetAll()
        {
            return await _context.HocViens
                .Select(hv => new HocVienResponse
                {
                    MaHocVien = hv.MaHocVien,
                    HoTen = hv.Ho + " " + hv.TenDemVaTen,
                    NgaySinh = hv.NgaySinh,
                    GioiTinh = hv.GioiTinh,
                    Email = hv.Email,
                    DienThoai = hv.DienThoai,
                    DiaChi = hv.DiaChi,
                    HoTenPhuHuynh = hv.HoTenPhuHuynh,
                    MaLopHoc = hv.MaLopHoc,
                    HinhAnh = hv.HinhAnh
                })
                .ToListAsync();
        }

        public async Task<HocVienResponse?> GetById(string id)
        {
            return await _context.HocViens
                .Select(hv => new HocVienResponse
                {
                    MaHocVien = hv.MaHocVien,
                    HoTen = hv.Ho + " " + hv.TenDemVaTen,
                    NgaySinh = hv.NgaySinh,
                    GioiTinh = hv.GioiTinh,
                    Email = hv.Email,
                    DienThoai = hv.DienThoai,
                    DiaChi = hv.DiaChi,
                    HoTenPhuHuynh = hv.HoTenPhuHuynh,
                    MaLopHoc = hv.MaLopHoc,
                    HinhAnh = hv.HinhAnh
                })
                .FirstOrDefaultAsync(hv => hv.MaHocVien == id);
        }

        public async Task<HocVienResponse?> Add(HocVienCreate request)
        {
            try
            {
                var hocVien = await _context.HocViens
                    .Select(hv => new HocVienResponse
                    {
                        MaHocVien = hv.MaHocVien,
                        HoTen = hv.Ho + " " + hv.TenDemVaTen,
                        NgaySinh = hv.NgaySinh,
                        GioiTinh = hv.GioiTinh,
                        Email = hv.Email,
                        DienThoai = hv.DienThoai,
                        DiaChi = hv.DiaChi,
                        HoTenPhuHuynh = hv.HoTenPhuHuynh,
                        MaLopHoc = hv.MaLopHoc,
                        HinhAnh = hv.HinhAnh
                    })
                    .FirstOrDefaultAsync(hv => hv.MaHocVien == request.MaHocVien);
                if (hocVien == null)
                {
                    _context.HocViens.Add(new HocVien()
                    {
                        MaHocVien = request.MaHocVien,
                        Ho = request.Ho,
                        TenDemVaTen = request.TenDemVaTen,
                        NgaySinh = request.NgaySinh,
                        GioiTinh = request.GioiTinh,
                        Email = request.Email,
                        DienThoai = request.DienThoai,
                        DiaChi = request.DiaChi,
                        HoTenPhuHuynh = request.HoTenPhuHuynh,
                        MaLopHoc = request.MaLopHoc,
                        MatKhau = request.MatKhau,
                        HinhAnh = request.HinhAnh
                    });
                    await _context.SaveChangesAsync();
                }
                return hocVien;
            }
            catch (DbUpdateException db)
            {
                throw new DbUpdateException(db.Message);
            }
        }

        public async Task<HocVienResponse?> Update(string id, HocVienUpdate request)
        {
            try
            {
                var hocVien = await _context.HocViens.FirstOrDefaultAsync(hv => hv.MaHocVien == id);
                if (hocVien != null)
                {
                    hocVien.Ho = request.Ho;
                    hocVien.TenDemVaTen = request.TenDemVaTen;
                    hocVien.NgaySinh = request.NgaySinh;
                    hocVien.GioiTinh = request.GioiTinh;
                    hocVien.Email = request.Email;
                    hocVien.DienThoai = request.DienThoai;
                    hocVien.DiaChi = request.DiaChi;
                    hocVien.HoTenPhuHuynh = request.HoTenPhuHuynh;
                    hocVien.HinhAnh = request.HinhAnh;
                    await _context.SaveChangesAsync();
                    return new HocVienResponse(hocVien);
                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<HocVienResponse?> Delete(string id)
        {
            try
            {
                var hocVien = await _context.HocViens.FirstOrDefaultAsync(hv => hv.MaHocVien == id);
                if (hocVien != null)
                {
                    _context.HocViens.Remove(hocVien);
                    await _context.SaveChangesAsync();
                    return new HocVienResponse(hocVien);
                }
                else
                    return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }
    }
}
