using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class GiangVienService
    {
        private readonly ManagementDbContext _context;

        public GiangVienService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GiangVienResponse>> GetAll()
        {
            return await _context.GiangViens
                .Select(gv => new GiangVienResponse
                {
                    ID = gv.MaGiangVien,
                    HoTen = gv.Ho + gv.TenDemVaTen,
                    NgaySinh = gv.NgaySinh,
                    GioiTinh = gv.GioiTinh,
                    Email = gv.Email,
                    DienThoai = gv.DienThoai,
                    DiaChi = gv.DiaChi,
                    MaMonDayChinh = gv.MaMonDayChinh,
                    MonDayKiemNhiem = gv.MonDayKiemNhiem,
                    HinhAnh = gv.HinhAnh
                })
                .ToListAsync();
        }

        public async Task<GiangVienResponse?> GetById(string id)
        {
            return await _context.GiangViens
                .Select(gv => new GiangVienResponse
                {
                    ID = gv.MaGiangVien,
                    HoTen = gv.Ho + gv.TenDemVaTen,
                    NgaySinh = gv.NgaySinh,
                    GioiTinh = gv.GioiTinh,
                    Email = gv.Email,
                    DienThoai = gv.DienThoai,
                    DiaChi = gv.DiaChi,
                    MaMonDayChinh = gv.MaMonDayChinh,
                    MonDayKiemNhiem = gv.MonDayKiemNhiem,
                    HinhAnh = gv.HinhAnh
                })
                .FirstOrDefaultAsync(gv => gv.ID == id);
        }

        public async Task<GiangVienResponse?> Add(GiangVienCreate request)
        {
            try
            {
                var giangVien = await _context.GiangViens
                    .Select(gv => new GiangVienResponse
                    {
                        ID = gv.MaGiangVien,
                        HoTen = gv.Ho + gv.TenDemVaTen,
                        NgaySinh = gv.NgaySinh,
                        GioiTinh = gv.GioiTinh,
                        Email = gv.Email,
                        DienThoai = gv.DienThoai,
                        DiaChi = gv.DiaChi,
                        MaMonDayChinh = gv.MaMonDayChinh,
                        MonDayKiemNhiem = gv.MonDayKiemNhiem,
                        HinhAnh = gv.HinhAnh
                    })
                    .FirstOrDefaultAsync(gv => gv.ID == request.MaGiangVien);
                if (giangVien == null)
                {
                    _context.GiangViens.Add(new GiangVien()
                    {
                        MaGiangVien = request.MaGiangVien,
                        MaSoThue = request.MaSoThue,
                        Ho = request.Ho,
                        TenDemVaTen = request.TenDemVaTen,
                        NgaySinh = request.NgaySinh,
                        GioiTinh = request.GioiTinh,
                        Email = request.Email,
                        DienThoai = request.DienThoai,
                        DiaChi = request.DiaChi,
                        MaMonDayChinh = request.MaMonDayChinh,
                        MonDayKiemNhiem = request.MonDayKiemNhiem,
                        MatKhau = request.MatKhau,
                        HinhAnh = request.HinhAnh
                    });
                    await _context.SaveChangesAsync();
                }
                return giangVien;
            }
            catch (DbUpdateException db)
            {
                throw new DbUpdateException(db.Message);
            }
        }

        public async Task<GiangVienResponse?> Update(string id, GiangVienUpdate request)
        {
            try
            {
                var giangVien = await _context.GiangViens.FirstOrDefaultAsync(gv => gv.MaGiangVien == id);
                if (giangVien != null)
                {
                    giangVien.MaSoThue = request.MaSoThue;
                    giangVien.Ho = request.Ho;
                    giangVien.TenDemVaTen = request.TenDemVaTen;
                    giangVien.NgaySinh = request.NgaySinh;
                    giangVien.GioiTinh = request.GioiTinh;
                    giangVien.Email = request.Email;
                    giangVien.DienThoai = request.DienThoai;
                    giangVien.DiaChi = request.DiaChi;
                    giangVien.MaMonDayChinh = request.MaMonDayChinh;
                    giangVien.MonDayKiemNhiem = request.MonDayKiemNhiem;
                    giangVien.HinhAnh = request.HinhAnh;
                    await _context.SaveChangesAsync();
                    return new GiangVienResponse(giangVien);
                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<GiangVienResponse?> Delete(string id)
        {
            try
            {
                var giangVien = await _context.GiangViens.FirstOrDefaultAsync(gv => gv.MaGiangVien == id);
                if (giangVien != null)
                {
                    _context.GiangViens.Remove(giangVien);
                    await _context.SaveChangesAsync();
                    return new GiangVienResponse(giangVien);
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
