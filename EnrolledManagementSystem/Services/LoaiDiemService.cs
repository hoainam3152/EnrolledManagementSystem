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

        public async Task<LoaiDiem> Add(LoaiDiem loaiDiem)
        {
            _context.Add(loaiDiem);
            await _context.SaveChangesAsync();
            return loaiDiem;
        }
    }
}
