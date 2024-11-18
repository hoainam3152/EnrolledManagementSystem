using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class PhanQuyenService
    {
        private readonly ManagementDbContext _context;

        public PhanQuyenService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhanQuyenResponse>> GetAll()
        {
            return await _context.PhanQuyens
                .Select(pq => new PhanQuyenResponse
                {
                    MaVaiTro = pq.MaVaiTro,
                    MaQuyen = pq.MaQuyen   
                })
                .ToListAsync();
        }

        public async Task<PhanQuyenResponse?> GetById(int maVT, int maQ)
        {
            return await _context.PhanQuyens
                .Select(pq => new PhanQuyenResponse
                {
                    MaVaiTro = pq.MaVaiTro,
                    MaQuyen = pq.MaQuyen
                })
                .FirstOrDefaultAsync(pq => pq.MaVaiTro == maVT && pq.MaQuyen == maQ);
        }

        public async Task<PhanQuyenResponse?> Add(PhanQuyenRequest request)
        {
            try
            {
                var phanQuyen = await _context.PhanQuyens
                    .Select(pq => new PhanQuyenResponse
                    {
                        MaVaiTro = pq.MaVaiTro,
                        MaQuyen = pq.MaQuyen
                    })
                    .FirstOrDefaultAsync(pq => pq.MaVaiTro == request.MaVaiTro && pq.MaQuyen == request.MaQuyen);
                if (phanQuyen == null)
                {
                    _context.PhanQuyens.Add(new PhanQuyen()
                    {
                        MaVaiTro = request.MaVaiTro,
                        MaQuyen = request.MaQuyen
                    });
                    await _context.SaveChangesAsync();
                }
                return phanQuyen;
            }
            catch (DbUpdateException db)
            {
                throw new DbUpdateException(db.Message);
            }
        }

        public async Task<PhanQuyenResponse?> Delete(int maVT, int maQ)
        {
            try
            {
                var phanQuyen = await _context.PhanQuyens.FirstOrDefaultAsync(pq => pq.MaVaiTro == maVT && pq.MaQuyen == maQ);
                if (phanQuyen != null)
                {
                    _context.PhanQuyens.Remove(phanQuyen);
                    await _context.SaveChangesAsync();
                    return new PhanQuyenResponse(phanQuyen);
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
