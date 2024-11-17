using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using EnrolledManagementSystem.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnrolledManagementSystem.Services
{
    public class DangKyService
    {
        private readonly ManagementDbContext _context;

        public DangKyService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DangKyResponse>> GetAll()
        {
            return await _context.DangKys
                .Select(dk => new DangKyResponse
                {
                    MaHocVien = dk.MaHocVien,
                    MaLopHoc = dk.MaLopHoc,
                    DaDongHocPhi = dk.DaDongHocPhi
                })
                .ToListAsync();
        }

        public async Task<DangKyResponse?> GetById(string maHV, string maLH)
        {
            return await _context.DangKys
                .Select(dk => new DangKyResponse
                {
                    MaHocVien = dk.MaHocVien,
                    MaLopHoc = dk.MaLopHoc,
                    DaDongHocPhi = dk.DaDongHocPhi
                })
                .FirstOrDefaultAsync(dk => dk.MaHocVien == maHV && dk.MaLopHoc == maLH);
        }

        public async Task<DangKyResponse?> Add(DangKyRequest request)
        {
            try
            {
                var dangKy = await _context.DangKys
                    .Select(dk => new DangKyResponse
                    {
                        MaHocVien = dk.MaHocVien,
                        MaLopHoc = dk.MaLopHoc,
                        DaDongHocPhi = dk.DaDongHocPhi
                    })
                    .FirstOrDefaultAsync(dk => dk.MaHocVien == request.MaHocVien && dk.MaLopHoc == request.MaLopHoc);
                if (dangKy == null)
                {
                    _context.DangKys.Add(new DangKy()
                    {
                        MaHocVien = request.MaHocVien,
                        MaLopHoc = request.MaLopHoc,
                        DaDongHocPhi = false,
                    });
                    await _context.SaveChangesAsync();
                }
                return dangKy;
            }
            catch (DbUpdateException db)
            {
                throw new DbUpdateException(db.Message);
            }
        }

        public async Task<DangKyResponse?> Update(string maHV, string maLH)
        {
            try
            {
                var dangKy = await _context.DangKys.FirstOrDefaultAsync(dk => dk.MaHocVien == maHV && dk.MaLopHoc == maLH);
                if (dangKy != null)
                {
                    dangKy.DaDongHocPhi = true;
                    await _context.SaveChangesAsync();
                    return new DangKyResponse(dangKy);
                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<DangKyResponse?> Delete(string maHV, string maLH)
        {
            try
            {
                var dangKy = await _context.DangKys.FirstOrDefaultAsync(dk => dk.MaHocVien == maHV && dk.MaLopHoc == maLH);
                if (dangKy != null)
                {
                    _context.DangKys.Remove(dangKy);
                    await _context.SaveChangesAsync();
                    return new DangKyResponse(dangKy);
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
