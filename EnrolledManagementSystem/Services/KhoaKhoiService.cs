using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class KhoaKhoiService
    {
        private readonly ManagementDbContext _context;

        public KhoaKhoiService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KhoaKhoiResponse>> GetAll()
        {
            return await _context.Khoa_Khois
                .Select(kk => new KhoaKhoiResponse
                {
                    MaKhoaKhoi = kk.MaKhoaKhoi,
                    TenKhoaKhoi = kk.TenKhoaKhoi
                })
                .ToListAsync();
        }

        public async Task<KhoaKhoiResponse?> GetById(string id)
        {
            return await _context.Khoa_Khois
                .Select(kk => new KhoaKhoiResponse
                {
                    MaKhoaKhoi = kk.MaKhoaKhoi,
                    TenKhoaKhoi = kk.TenKhoaKhoi
                })
                .FirstOrDefaultAsync(kk => kk.MaKhoaKhoi == id);
        }

        public async Task<KhoaKhoiResponse?> Add(KhoaKhoiCreate request)
        {
            var kk = await _context.Khoa_Khois
                .Select(kk => new KhoaKhoiResponse
                {
                    MaKhoaKhoi = kk.MaKhoaKhoi,
                    TenKhoaKhoi = kk.TenKhoaKhoi
                })
                .FirstOrDefaultAsync(k => k.MaKhoaKhoi == request.MaKhoaKhoi);
            if (kk == null)
            {
                _context.Khoa_Khois.Add(new Khoa_Khoi()
                {
                    MaKhoaKhoi = request.MaKhoaKhoi,
                    TenKhoaKhoi = request.TenKhoaKhoi
                });
                await _context.SaveChangesAsync();
            }
            return kk;
        }

        public async Task<KhoaKhoiResponse?> Update(string id, KhoaKhoiUpdate request)
        {
            var khoaKhoi = await _context.Khoa_Khois.FirstOrDefaultAsync(kk => kk.MaKhoaKhoi == id);
            if (khoaKhoi != null)
            {
                khoaKhoi.TenKhoaKhoi = request.TenKhoaKhoi;
                await _context.SaveChangesAsync();
                return new KhoaKhoiResponse(khoaKhoi.MaKhoaKhoi, khoaKhoi.TenKhoaKhoi);
            }
            return null;
        }

        public async Task<KhoaKhoiResponse?> Delete(string id)
        {
            var khoaKhoi = await _context.Khoa_Khois.FirstOrDefaultAsync(kk => kk.MaKhoaKhoi == id);
            if (khoaKhoi != null)
            {
                _context.Khoa_Khois.Remove(khoaKhoi);
                await _context.SaveChangesAsync();
                return new KhoaKhoiResponse(khoaKhoi.MaKhoaKhoi, khoaKhoi.TenKhoaKhoi);
            } else
            return null;
        }
    }
}
