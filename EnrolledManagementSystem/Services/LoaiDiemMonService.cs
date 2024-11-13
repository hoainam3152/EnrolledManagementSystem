using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace EnrolledManagementSystem.Services
{
    public class LoaiDiemMonService
    {
        private readonly ManagementDbContext _context;

        public LoaiDiemMonService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoaiDiemMonResponse>> GetAll()
        {
            return await _context.LoaiDiemMons
                .Select(ldm => new LoaiDiemMonResponse
                {
                    MaKhoa = ldm.MaKhoa,
                    MaMon = ldm.MaMon,
                    MaLoai = ldm.MaLoai,
                    SoCotDiem = ldm.SoCotDiem,
                    SoCotDiemBatBuoc = ldm.SoCotDiemBatBuoc
                })
                .ToListAsync();
        }

        public async Task<LoaiDiemMonResponse?> GetById(string maKhoa, string maMon, string maLoai)
        {
            return await _context.LoaiDiemMons
                .Select(ldm => new LoaiDiemMonResponse
                {
                    MaKhoa = ldm.MaKhoa,
                    MaMon = ldm.MaMon,
                    MaLoai = ldm.MaLoai,
                    SoCotDiem = ldm.SoCotDiem,
                    SoCotDiemBatBuoc = ldm.SoCotDiemBatBuoc
                })
                .FirstOrDefaultAsync(ldm =>
                    ldm.MaKhoa == maKhoa &&
                    ldm.MaMon == maMon &&
                    ldm.MaLoai == maLoai);
        }

        public async Task<LoaiDiemMonResponse?> Add(LoaiDiemMonCreate request)
        {
            try
            {
                var monHoc = await _context.LoaiDiemMons
                    .Select(ldm => new LoaiDiemMonResponse
                    {
                        MaKhoa = ldm.MaKhoa,
                        MaMon = ldm.MaMon,
                        MaLoai = ldm.MaLoai,
                        SoCotDiem = ldm.SoCotDiem,
                        SoCotDiemBatBuoc = ldm.SoCotDiemBatBuoc
                    })
                    .FirstOrDefaultAsync(ldm =>
                    ldm.MaKhoa == request.MaKhoa &&
                    ldm.MaMon == request.MaMon &&
                    ldm.MaLoai == request.MaLoai);
                if (monHoc == null)
                {
                    _context.LoaiDiemMons.Add(new LoaiDiemMon()
                    {
                        MaKhoa = request.MaKhoa,
                        MaMon = request.MaMon,
                        MaLoai = request.MaLoai,
                        SoCotDiem = request.SoCotDiem,
                        SoCotDiemBatBuoc = request.SoCotDiemBatBuoc
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

        public async Task<LoaiDiemMonResponse?> Update(string maKhoa, string maMon, string maLoai, LoaiDiemMonUpdate request)
        {
            try
            {
                var monHoc = await _context.LoaiDiemMons.FirstOrDefaultAsync(ldm => 
                    ldm.MaKhoa == maKhoa &&
                    ldm.MaMon == maMon &&
                    ldm.MaLoai == maLoai);
                if (monHoc != null)
                {
                    monHoc.SoCotDiem = request.SoCotDiem;
                    monHoc.SoCotDiemBatBuoc = request.SoCotDiemBatBuoc;
                    await _context.SaveChangesAsync();
                    return new LoaiDiemMonResponse(monHoc);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public async Task<LoaiDiemMonResponse?> Delete(string maKhoa, string maMon, string maLoai)
        {
            try
            {
                var monhoc = await _context.LoaiDiemMons.FirstOrDefaultAsync(ldm =>
                    ldm.MaKhoa == maKhoa &&
                    ldm.MaMon == maMon &&
                    ldm.MaLoai == maLoai);
                if (monhoc != null)
                {
                    _context.LoaiDiemMons.Remove(monhoc);
                    await _context.SaveChangesAsync();
                    return new LoaiDiemMonResponse(monhoc);
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
