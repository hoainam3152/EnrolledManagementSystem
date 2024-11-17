using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class PhieuLuongService
    {
        private readonly ManagementDbContext _context;

        public PhieuLuongService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhieuLuongResponse>> GetAll()
        {
            return await _context.PhieuLuongNhanViens
                .Select(pl => new PhieuLuongResponse
                {
                    MaPhieuLuong = pl.MaPhieuLuong,
                    TenPhieu = pl.TenPhieu,
                    NgayInPhieu = pl.NgayInPhieu,
                    MaKhoaHoc = pl.MaKhoaHoc,
                    MaNhanVien = pl.MaNhanVien,
                    LuongNhanVien = pl.LuongNhanVien,
                    TenPhuCap = pl.TenPhuCap,
                    SoTienPhuCap = pl.SoTienPhuCap,
                    GhiChu = pl.GhiChu,
                    DaChotLuong = pl.DaChotLuong
                })
                .ToListAsync();
        }

        public async Task<PhieuLuongResponse?> GetById(int id)
        {
            return await _context.PhieuLuongNhanViens
                .Select(pl => new PhieuLuongResponse
                {
                    MaPhieuLuong = pl.MaPhieuLuong,
                    TenPhieu = pl.TenPhieu,
                    NgayInPhieu = pl.NgayInPhieu,
                    MaKhoaHoc = pl.MaKhoaHoc,
                    MaNhanVien = pl.MaNhanVien,
                    LuongNhanVien = pl.LuongNhanVien,
                    TenPhuCap = pl.TenPhuCap,
                    SoTienPhuCap = pl.SoTienPhuCap,
                    GhiChu = pl.GhiChu,
                    DaChotLuong = pl.DaChotLuong
                })
                .FirstOrDefaultAsync(pl => pl.MaPhieuLuong == id);
        }

        public async Task<PhieuLuongResponse?> Add(PhieuLuongCreate request)
        {
            try
            {
                _context.PhieuLuongNhanViens.Add(new PhieuLuongNhanVien()
                {
                    TenPhieu = request.TenPhieu,
                    NgayInPhieu = DateTime.Now,
                    MaKhoaHoc = request.MaKhoaHoc,
                    MaNhanVien = request.MaNhanVien,
                    LuongNhanVien = request.LuongNhanVien,
                    TenPhuCap = request.TenPhuCap,
                    SoTienPhuCap = request.SoTienPhuCap,
                    GhiChu = request.GhiChu,
                    DaChotLuong = false
                });
                await _context.SaveChangesAsync();
                return await _context.PhieuLuongNhanViens
                    .OrderBy(pl => pl.MaPhieuLuong)
                    .Select(pl => new PhieuLuongResponse()
                    {
                        MaPhieuLuong = pl.MaPhieuLuong,
                        TenPhieu = pl.TenPhieu,
                        NgayInPhieu = pl.NgayInPhieu,
                        MaKhoaHoc = pl.MaKhoaHoc,
                        MaNhanVien = pl.MaNhanVien,
                        LuongNhanVien = pl.LuongNhanVien,
                        TenPhuCap = pl.TenPhuCap,
                        SoTienPhuCap = pl.SoTienPhuCap,
                        GhiChu = pl.GhiChu,
                        DaChotLuong = pl.DaChotLuong
                    })
                    .LastAsync();
            }
            catch (DbUpdateException db)
            {
                throw new DbUpdateException(db.Message);
            }
        }

        public async Task<PhieuLuongResponse?> Update(int id, PhieuLuongUpdate request)
        {
            try
            {
                var phieuLuong = await _context.PhieuLuongNhanViens.FirstOrDefaultAsync(pl => pl.MaPhieuLuong == id);
                if (phieuLuong != null)
                {
                    phieuLuong.TenPhieu = request.TenPhieu;
                    phieuLuong.NgayInPhieu = request.NgayInPhieu;
                    phieuLuong.MaKhoaHoc = request.MaKhoaHoc;
                    phieuLuong.MaNhanVien = request.MaNhanVien;
                    phieuLuong.LuongNhanVien = request.LuongNhanVien;
                    phieuLuong.TenPhuCap = request.TenPhuCap;
                    phieuLuong.SoTienPhuCap = request.SoTienPhuCap;
                    phieuLuong.DaChotLuong = request.DaChotLuong;
                    await _context.SaveChangesAsync();
                    return new PhieuLuongResponse(phieuLuong);
                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<PhieuLuongResponse?> Delete(int id)
        {
            try
            {
                var phieuLuong = await _context.PhieuLuongNhanViens.FirstOrDefaultAsync(pl => pl.MaPhieuLuong == id);
                if (phieuLuong != null)
                {
                    _context.PhieuLuongNhanViens.Remove(phieuLuong);
                    await _context.SaveChangesAsync();
                    return new PhieuLuongResponse(phieuLuong);
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
