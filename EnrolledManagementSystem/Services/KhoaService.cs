using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class KhoaService
    {
        private readonly ManagementDbContext _context;

        public KhoaService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KhoaResponse>> GetAll()
        {
            return await _context.Khoas
                .Select(k => new KhoaResponse
                {
                    MaKhoa = k.MaKhoa,
                    TenKhoa = k.TenKhoa
                })
                .ToListAsync();
        }

        public async Task<KhoaResponse?> GetById(string id)
        {
            return await _context.Khoas
                .Select(k => new KhoaResponse
                {
                    MaKhoa = k.MaKhoa,
                    TenKhoa = k.TenKhoa
                })
                .FirstOrDefaultAsync(nk => nk.MaKhoa == id);
        }

        public async Task<KhoaResponse?> Add(KhoaCreate request)
        {
            var khoa = await _context.Khoas
                .Select(k => new KhoaResponse
                {
                    MaKhoa = k.MaKhoa,
                    TenKhoa = k.TenKhoa
                })
                .FirstOrDefaultAsync(k => k.MaKhoa == request.MaKhoa);
            if (khoa == null)
            {
                _context.Khoas.Add(new Khoa()
                {
                    MaKhoa = request.MaKhoa,
                    TenKhoa = request.TenKhoa
                });
                await _context.SaveChangesAsync();
            }
            return khoa;
        }

        public async Task<KhoaResponse?> Update(string id, KhoaUpdate request)
        {
            var khoa = await _context.Khoas.FirstOrDefaultAsync(nk => nk.MaKhoa == id);
            if (khoa != null)
            {
                khoa.TenKhoa = request.TenKhoa;
                await _context.SaveChangesAsync();
                return new KhoaResponse(khoa.MaKhoa, khoa.TenKhoa);
            }
            return null;
        }

        public async Task<KhoaResponse?> Delete(string id)
        {
            var khoa = await _context.Khoas.FirstOrDefaultAsync(k => k.MaKhoa == id);
            if (khoa != null)
            {
                _context.Khoas.Remove(khoa);
                await _context.SaveChangesAsync();
                return new KhoaResponse(khoa.MaKhoa, khoa.TenKhoa);
            }
            else
                return null;
        }
    }
}