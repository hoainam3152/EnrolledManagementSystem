using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class PhieuThuHocPhiService
    {
        private readonly ManagementDbContext _context;

        public PhieuThuHocPhiService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhieuThuHocPhiResponse>> GetAll()
        {
            return await _context.PhieuThuHocPhis
                .Select(pt => new PhieuThuHocPhiResponse
                {
                    MaPhieuThu = pt.MaPhieuThu,
                    MaHocVien = pt.MaHocVien,
                    MaLop = pt.MaLop,
                    MaLoaiHocPhi = pt.MaLoaiHocPhi,
                    MucThuPhi = pt.MucThuPhi,
                    GiamGia = pt.GiamGia,
                    GhiChu = pt.GhiChu,                   
                    NgayTao = pt.NgayTao
                })
                .ToListAsync();
        }

        public async Task<PhieuThuHocPhiResponse?> GetById(int id)
        {
            return await _context.PhieuThuHocPhis
                .Select(pt => new PhieuThuHocPhiResponse
                {
                    MaPhieuThu = pt.MaPhieuThu,
                    MaHocVien = pt.MaHocVien,
                    MaLop = pt.MaLop,
                    MaLoaiHocPhi = pt.MaLoaiHocPhi,
                    MucThuPhi = pt.MucThuPhi,
                    GiamGia = pt.GiamGia,
                    GhiChu = pt.GhiChu,
                    NgayTao = pt.NgayTao
                })
                .FirstOrDefaultAsync(pt => pt.MaPhieuThu == id);
        }

        public async Task<PhieuThuHocPhiResponse?> Add(PhieuThuHocPhiRequest request)
        {
            try
            {
                _context.PhieuThuHocPhis.Add(new PhieuThuHocPhi()
                {
                    MaHocVien = request.MaHocVien,
                    MaLop = request.MaLop,
                    MaLoaiHocPhi = request.MaLoaiHocPhi,
                    MucThuPhi = request.MucThuPhi,
                    GiamGia = request.GiamGia,
                    GhiChu = request.GhiChu,
                    NgayTao = DateTime.Now
                });
                await _context.SaveChangesAsync();
                return await _context.PhieuThuHocPhis
                    .OrderBy(pt => pt.MaPhieuThu)
                    .Select(pt => new PhieuThuHocPhiResponse()
                    {
                        MaPhieuThu = pt.MaPhieuThu,
                        MaHocVien = pt.MaHocVien,
                        MaLop = pt.MaLop,
                        MaLoaiHocPhi = pt.MaLoaiHocPhi,
                        MucThuPhi = pt.MucThuPhi,
                        GiamGia = pt.GiamGia,
                        GhiChu = pt.GhiChu,
                        NgayTao = pt.NgayTao
                    })
                    .LastAsync();
            }
            catch (DbUpdateException db)
            {
                throw new DbUpdateException(db.Message);
            }
        }

        public async Task<PhieuThuHocPhiResponse?> Update(int id, PhieuThuHocPhiRequest request)
        {
            try
            {
                var phieuThu = await _context.PhieuThuHocPhis.FirstOrDefaultAsync(pt => pt.MaPhieuThu == id);
                if (phieuThu != null)
                {
                    phieuThu.MaHocVien = request.MaHocVien;
                    phieuThu.MaLop = request.MaLop;
                    phieuThu.MaLoaiHocPhi = request.MaLoaiHocPhi;
                    phieuThu.MucThuPhi = request.MucThuPhi;
                    phieuThu.GiamGia = request.GiamGia;
                    phieuThu.GhiChu = request.GhiChu;
                    await _context.SaveChangesAsync();
                    return new PhieuThuHocPhiResponse(phieuThu);
                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<PhieuThuHocPhiResponse?> Delete(int id)
        {
            try
            {
                var hocVien = await _context.PhieuThuHocPhis.FirstOrDefaultAsync(pt => pt.MaPhieuThu == id);
                if (hocVien != null)
                {
                    _context.PhieuThuHocPhis.Remove(hocVien);
                    await _context.SaveChangesAsync();
                    return new PhieuThuHocPhiResponse(hocVien);
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
