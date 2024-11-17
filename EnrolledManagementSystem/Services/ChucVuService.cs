using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class ChucVuService
    {
        private readonly ManagementDbContext _context;

        public ChucVuService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChucVuResponse>> GetAll()
        {
            return await _context.ChucVus
                .Select(cv => new ChucVuResponse
                {
                    MaChucVu = cv.MaChucVu,
                    TenChucVu = cv.TenChucVu
                })
                .ToListAsync();
        }

        public async Task<ChucVuResponse?> GetById(int id)
        {
            return await _context.ChucVus
                .Select(cv => new ChucVuResponse
                {
                    MaChucVu = cv.MaChucVu,
                    TenChucVu = cv.TenChucVu
                })
                .FirstOrDefaultAsync(cv => cv.MaChucVu == id);
        }

        public async Task<ChucVuResponse?> Add(ChucVuRequest request)
        {
            _context.ChucVus.Add(new ChucVu()
            {
                TenChucVu = request.TenChucVu
            });
            await _context.SaveChangesAsync();
            return await _context.ChucVus
                .OrderBy(cv => cv.MaChucVu)
                .Select(cv => new ChucVuResponse
                {
                    MaChucVu = cv.MaChucVu,
                    TenChucVu = cv.TenChucVu
                })
                .LastAsync();
        }

        public async Task<ChucVuResponse?> Update(int id, ChucVuRequest request)
        {
            var chucVu = await _context.ChucVus.FirstOrDefaultAsync(cv => cv.MaChucVu == id);
            if (chucVu != null)
            {
                chucVu.TenChucVu = request.TenChucVu;
                await _context.SaveChangesAsync();
                return new ChucVuResponse(chucVu);
            }
            return null;
        }

        public async Task<ChucVuResponse?> Delete(int id)
        {
            var chucVu = await _context.ChucVus.FirstOrDefaultAsync(cv => cv.MaChucVu == id);
            if (chucVu != null)
            {
                _context.ChucVus.Remove(chucVu);
                await _context.SaveChangesAsync();
                return new ChucVuResponse(chucVu);
            }
            else
                return null;
        }
    }
}
