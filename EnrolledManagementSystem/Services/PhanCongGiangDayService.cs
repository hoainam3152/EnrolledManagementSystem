using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnrolledManagementSystem.Services
{
    public class PhanCongGiangDayService
    {
        private readonly ManagementDbContext _context;

        public PhanCongGiangDayService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhanCongGiangDayResponse>> GetAll()
        {
            return await _context.PhanCongGiangDays
                .Select(pcgd => new PhanCongGiangDayResponse
                {
                    MaLopHoc = pcgd.MaLopHoc,
                    MaMonHoc = pcgd.MaMonHoc,
                    PhongHoc = pcgd.PhongHoc,
                    Thu = pcgd.Thu,
                    NgayBatDau = pcgd.NgayBatDau,
                    NgayKetThuc = pcgd.NgayKetThuc,
                    GioBatDau = pcgd.GioBatDau,
                    GioKetThuc = pcgd.GioKetThuc,
                    MaGiangVien = pcgd.MaGiangVien
                })
                .ToListAsync();
        }

        public async Task<PhanCongGiangDayResponse?> GetById(string maLH, string maMH, string maGV)
        {
            return await _context.PhanCongGiangDays
                .Select(pcgd => new PhanCongGiangDayResponse
                {
                    MaLopHoc = pcgd.MaLopHoc,
                    MaMonHoc = pcgd.MaMonHoc,
                    PhongHoc = pcgd.PhongHoc,
                    Thu = pcgd.Thu,
                    NgayBatDau = pcgd.NgayBatDau,
                    NgayKetThuc = pcgd.NgayKetThuc,
                    GioBatDau = pcgd.GioBatDau,
                    GioKetThuc = pcgd.GioKetThuc,
                    MaGiangVien = pcgd.MaGiangVien
                })
                .FirstOrDefaultAsync(pcgd => 
                    pcgd.MaLopHoc == maLH &&
                    pcgd.MaMonHoc == maMH &&
                    pcgd.MaGiangVien == maGV
                );
        }

        public async Task<PhanCongGiangDayResponse?> Add(PhanCongGiangDayCreate request)
        {
            try
            {
                var phanCong = await _context.PhanCongGiangDays
                    .Select(pcgd => new PhanCongGiangDayResponse
                    {
                        MaLopHoc = pcgd.MaLopHoc,
                        MaMonHoc = pcgd.MaMonHoc,
                        MaGiangVien = pcgd.MaGiangVien,
                        PhongHoc = pcgd.PhongHoc,
                        Thu = pcgd.Thu,
                        NgayBatDau = pcgd.NgayBatDau,
                        NgayKetThuc = pcgd.NgayKetThuc,
                        GioBatDau = pcgd.GioBatDau,
                        GioKetThuc = pcgd.GioKetThuc
                    })
                    .FirstOrDefaultAsync(pcgd =>
                        pcgd.MaLopHoc == request.MaLopHoc &&
                        pcgd.MaMonHoc == request.MaMonHoc &&
                        pcgd.MaGiangVien == request.MaGiangVien
                    );
                if (phanCong == null)
                {
                    _context.PhanCongGiangDays.Add(new PhanCongGiangDay()
                    {
                        MaLopHoc = request.MaLopHoc,
                        MaMonHoc = request.MaMonHoc,
                        MaGiangVien = request.MaGiangVien,
                        PhongHoc = request.PhongHoc,
                        Thu = request.Thu,
                        NgayBatDau = request.NgayBatDau,
                        NgayKetThuc = request.NgayKetThuc,
                        GioBatDau = request.GioBatDau,
                        GioKetThuc = request.GioKetThuc
                    });
                    await _context.SaveChangesAsync();
                }
                return phanCong;
            }
            catch (DbUpdateException db)
            {
                throw new DbUpdateException(db.Message);
            }
        }

        public async Task<PhanCongGiangDayResponse?> Update(string maLH, string maMH, string maGV, PhanCongGiangDayUpdate request)
        {
            try
            {
                var phanCong = await _context.PhanCongGiangDays
                    .FirstOrDefaultAsync(pcgd =>
                        pcgd.MaLopHoc == maLH &&
                        pcgd.MaMonHoc == maMH &&
                        pcgd.MaGiangVien == maGV
                    );
                if (phanCong != null)
                {
                    phanCong.PhongHoc = request.PhongHoc;
                    phanCong.Thu = request.Thu;
                    phanCong.NgayBatDau = request.NgayBatDau;
                    phanCong.NgayKetThuc = request.NgayKetThuc;
                    phanCong.GioBatDau = request.GioBatDau;
                    phanCong.GioKetThuc = request.GioKetThuc;
                    await _context.SaveChangesAsync();
                    return new PhanCongGiangDayResponse(phanCong);
                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<PhanCongGiangDayResponse?> Delete(string maLH, string maMH, string maGV)
        {
            try
            {
                var phanCong = await _context.PhanCongGiangDays
                    .FirstOrDefaultAsync(pcgd =>
                        pcgd.MaLopHoc == maLH &&
                        pcgd.MaMonHoc == maMH &&
                        pcgd.MaGiangVien == maGV
                    );
                if (phanCong != null)
                {
                    _context.PhanCongGiangDays.Remove(phanCong);
                    await _context.SaveChangesAsync();
                    return new PhanCongGiangDayResponse(phanCong);
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
