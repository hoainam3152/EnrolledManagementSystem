using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class NguoiDungService
    {
        private readonly ManagementDbContext _context;

        public NguoiDungService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NguoiDungResponse>> GetAll()
        {
            return await _context.NguoiDungs
                .Select(nd => new NguoiDungResponse
                {
                    MaNguoiDung = nd.MaNguoiDung,
                    TenNguoiDung = nd.TenNguoiDung,
                    Email = nd.Email,
                    MaVaiTro = nd.MaVaiTro,
                    HinhAnh = nd.HinhAnh
                })
                .ToListAsync();
        }

        public async Task<NguoiDungResponse?> GetById(string id)
        {
            return await _context.NguoiDungs
                .Select(nd => new NguoiDungResponse
                {
                    MaNguoiDung = nd.MaNguoiDung,
                    TenNguoiDung = nd.TenNguoiDung,
                    Email = nd.Email,
                    MaVaiTro = nd.MaVaiTro,
                    HinhAnh = nd.HinhAnh
                })
                .FirstOrDefaultAsync(nd => nd.MaNguoiDung == id);
        }

        public async Task<NguoiDungResponse?> Add(NguoiDungCreate request)
        {
            try
            {
                var nguoiDung = await _context.NguoiDungs
                    .Select(nd => new NguoiDungResponse
                    {
                        MaNguoiDung = nd.MaNguoiDung,
                        TenNguoiDung = nd.TenNguoiDung,
                        Email = nd.Email,
                        MaVaiTro = nd.MaVaiTro,
                        HinhAnh = nd.HinhAnh
                    })
                    .FirstOrDefaultAsync(nd => nd.MaNguoiDung == request.MaNguoiDung);
                if (nguoiDung == null)
                {
                    _context.NguoiDungs.Add(new NguoiDung()
                    {
                        MaNguoiDung = request.MaNguoiDung,
                        TenNguoiDung = request.TenNguoiDung,
                        Email = request.Email,
                        MaVaiTro = request.MaVaiTro,
                        MatKhau = request.MatKhau,
                        HinhAnh = request.HinhAnh
                    });
                    await _context.SaveChangesAsync();
                }
                return nguoiDung;
            }
            catch (DbUpdateException db)
            {
                throw new DbUpdateException(db.Message);
            }
        }

        public async Task<NguoiDungResponse?> Update(string id, NguoiDungUpdate request)
        {
            try
            {
                var nguoiDung = await _context.NguoiDungs.FirstOrDefaultAsync(nd => nd.MaNguoiDung == id);
                if (nguoiDung != null)
                {
                    nguoiDung.TenNguoiDung = request.TenNguoiDung;
                    nguoiDung.Email = request.Email;
                    nguoiDung.MaVaiTro = request.MaVaiTro;
                    nguoiDung.HinhAnh = request.HinhAnh;
                    await _context.SaveChangesAsync();
                    return new NguoiDungResponse(nguoiDung);
                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<NguoiDungResponse?> Delete(string id)
        {
            try
            {
                var nguoiDung = await _context.NguoiDungs.FirstOrDefaultAsync(nd => nd.MaNguoiDung == id);
                if (nguoiDung != null)
                {
                    _context.NguoiDungs.Remove(nguoiDung);
                    await _context.SaveChangesAsync();
                    return new NguoiDungResponse(nguoiDung);
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
