using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class LoaiDiemService
    {
        private readonly ManagementDbContext _context;

        public LoaiDiemService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoaiDiem>> GetAll()
        {
            return await _context.LoaiDiems.ToListAsync();
        }

        public async Task<LoaiDiem?> GetByID(string id)
        {
            return await _context.LoaiDiems.FirstOrDefaultAsync(ld => ld.MaLoaiDiem == id);
        }

        public async Task<LoaiDiem?> Add(LoaiDiem loaiDiem)
        {
            var ld = await _context.LoaiDiems.FindAsync(loaiDiem.MaLoaiDiem);
            if (ld == null)
            {
                _context.Add(loaiDiem);
                await _context.SaveChangesAsync();
            }
            return ld;
        }

        public async Task<LoaiDiem?> Update(string id, LoaiDiem loaiDiem)
        {
            var ld = await _context.LoaiDiems.FindAsync(id);
            if (ld != null)
            {
                ld.TenLoaiDiem = loaiDiem.TenLoaiDiem;
                ld.HeSo = loaiDiem.HeSo;
                await _context.SaveChangesAsync();
            }
            return ld;
        }

        public async Task<LoaiDiem?> Delete(string id)
        {
            var ld = await _context.LoaiDiems.FindAsync(id);
            if (ld != null)
            {
                _context.LoaiDiems.Remove(ld);
                await _context.SaveChangesAsync();
            }
            return ld;
        }
    }
}
