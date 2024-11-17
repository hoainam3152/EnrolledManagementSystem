using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class LoaiHocPhiService
    {
        private readonly ManagementDbContext _context;

        public LoaiHocPhiService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoaiHocPhiResponse>> GetAll()
        {
            return await _context.LoaiHocPhis
                .Select(lhp => new LoaiHocPhiResponse
                {
                    MaLoaiHocPhi = lhp.MaLoaiHocPhi,
                    TenLoaiHocPhi = lhp.TenLoaiHocPhi
                })
                .ToListAsync();
        }

        public async Task<LoaiHocPhiResponse?> GetById(int id)
        {
            return await _context.LoaiHocPhis
                .Select(lhp => new LoaiHocPhiResponse
                {
                    MaLoaiHocPhi = lhp.MaLoaiHocPhi,
                    TenLoaiHocPhi = lhp.TenLoaiHocPhi
                })
                .FirstOrDefaultAsync(lhp => lhp.MaLoaiHocPhi == id);
        }

        public async Task<LoaiHocPhiResponse?> Add(LoaiHocPhiRequest request)
        {
            _context.LoaiHocPhis.Add(new LoaiHocPhi()
            {
                TenLoaiHocPhi = request.TenHocPhi
            });
            await _context.SaveChangesAsync();
            return await _context.LoaiHocPhis
                .OrderBy(hp => hp.MaLoaiHocPhi)
                .Select(hp => new LoaiHocPhiResponse
                {
                    MaLoaiHocPhi = hp.MaLoaiHocPhi,
                    TenLoaiHocPhi = hp.TenLoaiHocPhi
                })
                .LastAsync();
        }

        public async Task<LoaiHocPhiResponse?> Update(int id, LoaiHocPhiRequest request)
        {
            try
            {
                var hocPhi = await _context.LoaiHocPhis.FirstOrDefaultAsync(lhp => lhp.MaLoaiHocPhi == id);
                if (hocPhi != null)
                {
                    hocPhi.TenLoaiHocPhi = request.TenHocPhi;
                    await _context.SaveChangesAsync();
                    return new LoaiHocPhiResponse(hocPhi);
                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task<LoaiHocPhiResponse?> Delete(int id)
        {
            try
            {
                var hocPhi = await _context.LoaiHocPhis.FirstOrDefaultAsync(lhp => lhp.MaLoaiHocPhi == id);
                if (hocPhi != null)
                {
                    _context.LoaiHocPhis.Remove(hocPhi);
                    await _context.SaveChangesAsync();
                    return new LoaiHocPhiResponse(hocPhi);
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
