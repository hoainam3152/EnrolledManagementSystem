using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class NienKhoaService
    {
        private readonly ManagementDbContext _context;

        public NienKhoaService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NienKhoaResponse>> GetAll()
        {
            return await _context.NienKhoas
                .Select(nk => new NienKhoaResponse
                {
                    MaNienKhoa = nk.MaNienKhoa,
                    TenNienKhoa = nk.TenNienKhoa
                })
                .ToListAsync();
        }

        public async Task<NienKhoaResponse?> GetById(string id)
        {
            return await _context.NienKhoas
                .Select(nk => new NienKhoaResponse
                {
                    MaNienKhoa = nk.MaNienKhoa,
                    TenNienKhoa = nk.TenNienKhoa
                })
                .FirstOrDefaultAsync(nk => nk.MaNienKhoa == id);
        }

        public async Task<NienKhoaResponse?> Add(NienKhoaCreate request)
        {
            var nk = await _context.NienKhoas
                .Select(nk => new NienKhoaResponse
                {
                    MaNienKhoa = nk.MaNienKhoa,
                    TenNienKhoa = nk.TenNienKhoa
                })
                .FirstOrDefaultAsync(k => k.MaNienKhoa == request.MaNienKhoa);
            if (nk == null)
            {
                _context.NienKhoas.Add(new NienKhoa()
                {
                    MaNienKhoa = request.MaNienKhoa,
                    TenNienKhoa = request.TenNienKhoa
                });
                await _context.SaveChangesAsync();
            }
            return nk;
        }

        public async Task<NienKhoaResponse?> Update(string id, NienKhoaUpdate request)
        {
            var khoaKhoi = await _context.NienKhoas.FirstOrDefaultAsync(nk => nk.MaNienKhoa == id);
            if (khoaKhoi != null)
            {
                khoaKhoi.TenNienKhoa = request.TenNienKhoa;
                await _context.SaveChangesAsync();
                return new NienKhoaResponse(khoaKhoi.MaNienKhoa, khoaKhoi.TenNienKhoa);
            }
            return null;
        }

        public async Task<NienKhoaResponse?> Delete(string id)
        {
            var khoaKhoi = await _context.NienKhoas.FirstOrDefaultAsync(nk => nk.MaNienKhoa == id);
            if (khoaKhoi != null)
            {
                _context.NienKhoas.Remove(khoaKhoi);
                await _context.SaveChangesAsync();
                return new NienKhoaResponse(khoaKhoi.MaNienKhoa, khoaKhoi.TenNienKhoa);
            }
            else
                return null;
        }
    }
}
