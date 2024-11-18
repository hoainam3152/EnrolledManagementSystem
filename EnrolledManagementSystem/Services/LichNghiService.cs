using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class LichNghiService
    {
        private readonly ManagementDbContext _context;

        public LichNghiService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LichNghiResponse>> GetAll()
        {
            return await _context.LichNghis
                .Select(pt => new LichNghiResponse
                {
                    MaLichNghi = pt.MaLichNghi,
                    TenNgayNghi = pt.TenNgayNghi,
                    LyDo = pt.LyDo,
                    ThoiGianBatDau = pt.ThoiGianBatDau,
                    ThoiGianKetThuc = pt.ThoiGianKetThuc
                })
                .ToListAsync();
        }

        public async Task<LichNghiResponse?> GetById(int id)
        {
            return await _context.LichNghis
                .Select(pt => new LichNghiResponse
                {
                    MaLichNghi = pt.MaLichNghi,
                    TenNgayNghi = pt.TenNgayNghi,
                    LyDo = pt.LyDo,
                    ThoiGianBatDau = pt.ThoiGianBatDau,
                    ThoiGianKetThuc = pt.ThoiGianKetThuc
                })
                .FirstOrDefaultAsync(pt => pt.MaLichNghi == id);
        }

        public async Task<LichNghiResponse?> Add(LichNghiRequest request)
        {
            try
            {
                _context.LichNghis.Add(new LichNghi()
                {
                    TenNgayNghi = request.TenNgayNghi,
                    LyDo = request.LyDo,
                    ThoiGianBatDau = request.ThoiGianBatDau,
                    ThoiGianKetThuc = request.ThoiGianKetThuc
                });
                await _context.SaveChangesAsync();
                return await _context.LichNghis
                    .OrderBy(pt => pt.MaLichNghi)
                    .Select(pt => new LichNghiResponse()
                    {
                        MaLichNghi = pt.MaLichNghi,
                        TenNgayNghi = pt.TenNgayNghi,
                        LyDo = pt.LyDo,
                        ThoiGianBatDau = pt.ThoiGianBatDau,
                        ThoiGianKetThuc = pt.ThoiGianKetThuc 
                    })
                    .LastAsync();
            }
            catch (DbUpdateException db)
            {
                throw new DbUpdateException(db.Message);
            }
        }

        public async Task<LichNghiResponse?> Update(int id, LichNghiRequest request)
        {
            try
            {
                var lichNghi = await _context.LichNghis.FirstOrDefaultAsync(pt => pt.MaLichNghi == id);
                if (lichNghi != null)
                {
                    lichNghi.TenNgayNghi = request.TenNgayNghi;
                    lichNghi.LyDo = request.LyDo;
                    lichNghi.ThoiGianBatDau = request.ThoiGianBatDau;
                    lichNghi.ThoiGianKetThuc = request.ThoiGianKetThuc;
                    await _context.SaveChangesAsync();
                    return new LichNghiResponse(lichNghi);
                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<LichNghiResponse?> Delete(int id)
        {
            try
            {
                var hocVien = await _context.LichNghis.FirstOrDefaultAsync(pt => pt.MaLichNghi == id);
                if (hocVien != null)
                {
                    _context.LichNghis.Remove(hocVien);
                    await _context.SaveChangesAsync();
                    return new LichNghiResponse(hocVien);
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
