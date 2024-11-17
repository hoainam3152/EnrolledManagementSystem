using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class DiemService
    {
        private readonly ManagementDbContext _context;

        public DiemService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiemResponse>> GetAll()
        {
            return await _context.Diems
                .Select(dd => new DiemResponse
                {
                    MaMonHoc = dd.MaMonHoc,
                    MaLoaiDiem = dd.MaLoaiDiem,
                    MaHocVien = dd.MaHocVien,
                    DiemMon = dd.DiemMon,
                    DaChot = dd.DaChot
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<DiemResponse?>> GetById(string maMH, string maLD, string maHV)
        {
            return await _context.Diems
                .Where(dd =>
                    dd.MaMonHoc == maMH &&
                    dd.MaLoaiDiem == maLD &&
                    dd.MaHocVien == maHV)
                .Select(dd => new DiemResponse
                {
                    MaMonHoc = dd.MaMonHoc,
                    MaLoaiDiem = dd.MaLoaiDiem,
                    MaHocVien = dd.MaHocVien,
                    DiemMon = dd.DiemMon,
                    DaChot = dd.DaChot
                })
                .ToListAsync();
        }

        public async Task<DiemResponse?> Add(DiemCreate request)
        {
            try
            {
                _context.Diems.Add(new Diem()
                {
                    MaMonHoc = request.MaMonHoc,
                    MaLoaiDiem = request.MaLoaiDiem,
                    MaHocVien = request.MaHocVien,
                    DiemMon = request.DiemMon,
                    DaChot = false
                });
                await _context.SaveChangesAsync();
                return await _context.Diems
                    .OrderBy(dd => dd.MaDiem)
                    .Select(dd => new DiemResponse()
                    {
                        MaMonHoc = dd.MaMonHoc,
                        MaLoaiDiem = dd.MaLoaiDiem,
                        MaHocVien = dd.MaHocVien,
                        DiemMon = dd.DiemMon,
                        DaChot = dd.DaChot
                    })
                    .LastAsync();
            }
            catch (DbUpdateException db)
            {
                throw new DbUpdateException(db.Message);
            }
        }

        public async Task<DiemResponse?> Update(string maMH, string maLD, string maHV, DiemUpdate request)
        {
            try
            {
                var diem = await _context.Diems
                    .FirstOrDefaultAsync(dd =>
                        dd.MaMonHoc == maMH &&
                        dd.MaMonHoc == maLD &&
                        dd.MaHocVien == maHV
                    );
                if (diem != null)
                {
                    diem.DiemMon = request.DiemMon;
                    //await _context.SaveChangesAsync();
                    return new DiemResponse(diem);
                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<IEnumerable<Diem?>> Delete(string maMH, string maLD, string maHV)
        {
            try
            {
                var diem = await _context.Diems
                    .Where(dd =>
                        dd.MaMonHoc == maMH &&
                        dd.MaLoaiDiem == maLD &&
                        dd.MaHocVien == maHV
                    ).ToListAsync();
                if (diem.Count > 0)
                {
                    _context.Diems.RemoveRange(diem);
                    await _context.SaveChangesAsync();
                }
                return diem;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }
    }
}
