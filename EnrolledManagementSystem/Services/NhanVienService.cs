using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class NhanVienService
    {
        private readonly ManagementDbContext _context;

        public NhanVienService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NhanVienResponse>> GetAll()
        {
            return await _context.NhanViens
                .Select(nv => new NhanVienResponse
                {
                    MaNhanVien = nv.MaNhanVien,
                    TenNhanVien = nv.TenNhanVien,
                    NgaySinh = nv.NgaySinh,
                    MaChucVu = nv.MaChucVu,
                    NgayVaoLam = nv.NgayVaoLam
                })
                .ToListAsync();
        }

        public async Task<NhanVienResponse?> GetById(string id)
        {
            return await _context.NhanViens
                .Select(nv => new NhanVienResponse
                {
                    MaNhanVien = nv.MaNhanVien,
                    TenNhanVien = nv.TenNhanVien,
                    NgaySinh = nv.NgaySinh,
                    MaChucVu = nv.MaChucVu,
                    NgayVaoLam = nv.NgayVaoLam
                })
                .FirstOrDefaultAsync(nv => nv.MaNhanVien == id);
        }

        public async Task<NhanVienResponse?> Add(NhanVienCreate request)
        {
            try
            {
                var nhanVien = await _context.NhanViens
                    .Select(nv => new NhanVienResponse
                    {
                        MaNhanVien = nv.MaNhanVien,
                        TenNhanVien = nv.TenNhanVien,
                        NgaySinh = nv.NgaySinh,
                        MaChucVu = nv.MaChucVu,
                        NgayVaoLam = nv.NgayVaoLam
                    })
                    .FirstOrDefaultAsync(nv => nv.MaNhanVien == request.MaNhanVien);
                if (nhanVien == null)
                {
                    _context.NhanViens.Add(new NhanVien()
                    {
                        MaNhanVien = request.MaNhanVien,
                        TenNhanVien = request.TenNhanVien,
                        NgaySinh = request.NgaySinh,
                        MaChucVu = request.MaChucVu,
                        NgayVaoLam = request.NgayVaoLam
                    });
                    await _context.SaveChangesAsync();
                }
                return nhanVien;
            }
            catch (DbUpdateException db)
            {
                throw new DbUpdateException(db.Message);
            }
        }

        public async Task<NhanVienResponse?> Update(string id, NhanVienUpdate request)
        {
            try
            {
                var nhanVien = await _context.NhanViens.FirstOrDefaultAsync(nv => nv.MaNhanVien == id);
                if (nhanVien != null)
                {
                    nhanVien.TenNhanVien = request.TenNhanVien;
                    nhanVien.NgaySinh = request.NgaySinh;
                    nhanVien.MaChucVu = request.MaChucVu;
                    nhanVien.NgayVaoLam = request.NgayVaoLam;
                    await _context.SaveChangesAsync();
                    return new NhanVienResponse(nhanVien);
                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<NhanVienResponse?> Delete(string id)
        {
            try
            {
                var nhanVien = await _context.NhanViens.FirstOrDefaultAsync(nv => nv.MaNhanVien == id);
                if (nhanVien != null)
                {
                    _context.NhanViens.Remove(nhanVien);
                    await _context.SaveChangesAsync();
                    return new NhanVienResponse(nhanVien);
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
