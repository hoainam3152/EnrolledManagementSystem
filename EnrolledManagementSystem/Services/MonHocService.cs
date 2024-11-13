using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class MonHocService
    {
        private readonly ManagementDbContext _context;

        public MonHocService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MonHocResponse>> GetAll()
        {
            return await _context.MonHocs
                .Select(mh => new MonHocResponse
                {
                    MaMonHoc = mh.MaMonHoc,
                    TenMonHoc = mh.TenMonHoc,
                    MaToBoMon = mh.MaToBoMon,
                    MaKhoaKhoi = mh.MaKhoaKhoi
                })
                .ToListAsync();
        }

        public async Task<MonHocResponse?> GetById(string id)
        {
            return await _context.MonHocs
                .Select(mh => new MonHocResponse
                {
                    MaMonHoc = mh.MaMonHoc,
                    TenMonHoc = mh.TenMonHoc,
                    MaToBoMon = mh.MaToBoMon,
                    MaKhoaKhoi = mh.MaKhoaKhoi
                })
                .FirstOrDefaultAsync(mh => mh.MaMonHoc == id);
        }

        public async Task<MonHocResponse?> Add(MonHocCreate request)
        {
            try
            {
                var monHoc = await _context.MonHocs
                    .Select(mh => new MonHocResponse
                    {
                        MaMonHoc = mh.MaMonHoc,
                        TenMonHoc = mh.TenMonHoc,
                        MaToBoMon = mh.MaToBoMon,
                        MaKhoaKhoi = mh.MaKhoaKhoi
                    })
                    .FirstOrDefaultAsync(k => k.MaMonHoc == request.MaMonHoc);
                if (monHoc == null)
                {
                    _context.MonHocs.Add(new MonHoc()
                    {
                        MaMonHoc = request.MaMonHoc,
                        TenMonHoc = request.TenMonHoc,
                        MaToBoMon = request.MaToBoMon,
                        MaKhoaKhoi = request.MaKhoaKhoi
                    });
                    await _context.SaveChangesAsync();
                }
                return monHoc;
            } 
            catch
            {
                throw new DbUpdateException();
            }
        }

        public async Task<MonHocResponse?> Update(string id, MonHocUpdate request)
        {
            try
            {
                var monHoc = await _context.MonHocs.FirstOrDefaultAsync(mh => mh.MaMonHoc == id);
                if (monHoc != null)
                {
                    monHoc.TenMonHoc = request.TenMonHoc;
                    monHoc.MaToBoMon = request.MaToBoMon;
                    monHoc.MaKhoaKhoi = request.MaKhoaKhoi;
                    await _context.SaveChangesAsync();
                    return new MonHocResponse(monHoc);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public async Task<MonHocResponse?> Delete(string id)
        {
            try
            {
                var monhoc = await _context.MonHocs.FirstOrDefaultAsync(mh => mh.MaMonHoc == id);
                if (monhoc != null)
                {
                    _context.MonHocs.Remove(monhoc);
                    await _context.SaveChangesAsync();
                    return new MonHocResponse(monhoc);
                }
                else
                    return null;
            }
            catch
            {
                throw new DbUpdateException("DELETE FAILED");
            }
        }
    }
}
