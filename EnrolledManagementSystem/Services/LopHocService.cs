using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class LopHocService
    {
        private readonly ManagementDbContext _context;

        public LopHocService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LopHocResponse>> GetAll()
        {
            return await _context.LopHocs
                .Select(lh => new LopHocResponse
                {
                    MaLop = lh.MaLop,
                    TenLop = lh.TenLop,
                    MaNienKhoa = lh.MaNienKhoa,
                    MaKhoaKhoi = lh.MaKhoaKhoi,
                    SoLuongHocVien = lh.SoLuongHocVien,
                    HocPhi = lh.HocPhi,
                    MoTa = lh.MoTa,
                    HinhAnh = lh.HinhAnh
                })
                .ToListAsync();
        }

        public async Task<LopHocResponse?> GetById(string id)
        {
            return await _context.LopHocs
                .Select(lh => new LopHocResponse
                {
                    MaLop = lh.MaLop,
                    TenLop = lh.TenLop,
                    MaNienKhoa = lh.MaNienKhoa,
                    MaKhoaKhoi = lh.MaKhoaKhoi,
                    SoLuongHocVien = lh.SoLuongHocVien,
                    HocPhi = lh.HocPhi,
                    MoTa = lh.MoTa,
                    HinhAnh = lh.HinhAnh
                })
                .FirstOrDefaultAsync(lh => lh.MaLop == id);
        }

        public async Task<LopHocResponse?> Add(LopHocCreate request)
        {
            try
            {
                var lopHoc = await _context.LopHocs
                    .Select(lh => new LopHocResponse
                    {
                        MaLop = lh.MaLop,
                        TenLop = lh.TenLop,
                        MaNienKhoa = lh.MaNienKhoa,
                        MaKhoaKhoi = lh.MaKhoaKhoi,
                        SoLuongHocVien = lh.SoLuongHocVien,
                        HocPhi = lh.HocPhi,
                        MoTa = lh.MoTa,
                        HinhAnh = lh.HinhAnh
                    })
                    .FirstOrDefaultAsync(k => k.MaLop == request.MaLop);
                if (lopHoc == null)
                {
                    _context.LopHocs.Add(new LopHoc()
                    {
                        MaLop = request.MaLop,
                        TenLop = request.TenLop,
                        MaNienKhoa = request.MaNienKhoa,
                        MaKhoaKhoi = request.MaKhoaKhoi,
                        SoLuongHocVien = request.SoLuongHocVien,
                        HocPhi = request.HocPhi,
                        MoTa = request.MoTa,
                        HinhAnh = request.HinhAnh
                    });
                    await _context.SaveChangesAsync();
                }
                return lopHoc;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public async Task<LopHocResponse?> Update(string id, LopHocUpdate request)
        {
            try
            {
                var lopHoc = await _context.LopHocs.FirstOrDefaultAsync(lh => lh.MaLop == id);
                if (lopHoc != null)
                {
                    lopHoc.TenLop = request.TenLop;
                    lopHoc.MaNienKhoa = request.MaNienKhoa;
                    lopHoc.MaKhoaKhoi = request.MaKhoaKhoi;
                    lopHoc.SoLuongHocVien = request.SoLuongHocVien;
                    lopHoc.HocPhi = request.HocPhi;
                    lopHoc.MoTa = request.MoTa;
                    lopHoc.HinhAnh = request.HinhAnh;
                    await _context.SaveChangesAsync();
                    return new LopHocResponse(lopHoc);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public async Task<LopHocResponse?> Delete(string id)
        {
            try
            {
                var lopHoc = await _context.LopHocs.FirstOrDefaultAsync(lh => lh.MaLop == id);
                if (lopHoc != null)
                {
                    _context.LopHocs.Remove(lopHoc);
                    await _context.SaveChangesAsync();
                    return new LopHocResponse(lopHoc);
                }
                else
                    return null;
            }
            catch
            {
                throw new DbUpdateException("DELETE FAILED");
            }
        }
    }
}
