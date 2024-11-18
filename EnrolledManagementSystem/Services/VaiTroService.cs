using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class VaiTroService
    {
        private readonly ManagementDbContext _context;

        public VaiTroService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VaiTroResponse>> GetAll()
        {
            return await _context.VaiTros
                .Select(vt => new VaiTroResponse
                {
                    MaVaiTro = vt.MaVaiTro,
                    TenVaiTro = vt.TenVaiTro
                })
                .ToListAsync();
        }

        public async Task<VaiTroResponse?> GetById(int id)
        {
            return await _context.VaiTros
                .Select(vt => new VaiTroResponse
                {
                    MaVaiTro = vt.MaVaiTro,
                    TenVaiTro = vt.TenVaiTro
                })
                .FirstOrDefaultAsync(vt => vt.MaVaiTro == id);
        }

        public async Task<VaiTroResponse?> Add(VaiTroRequest request)
        {
            _context.VaiTros.Add(new VaiTro()
            {
                TenVaiTro = request.TenVaiTro
            });
            await _context.SaveChangesAsync();
            return await _context.VaiTros
                .OrderBy(vt => vt.MaVaiTro)
                .Select(vt => new VaiTroResponse
                {
                    MaVaiTro = vt.MaVaiTro,
                    TenVaiTro = vt.TenVaiTro
                })
                .LastAsync();
        }

        public async Task<VaiTroResponse?> Update(int id, VaiTroRequest request)
        {
            var vaiTro = await _context.VaiTros.FirstOrDefaultAsync(vt => vt.MaVaiTro == id);
            if (vaiTro != null)
            {
                vaiTro.TenVaiTro = request.TenVaiTro;
                await _context.SaveChangesAsync();
                return new VaiTroResponse(vaiTro);
            }
            return null;
        }

        public async Task<VaiTroResponse?> Delete(int id)
        {
            var vaiTro = await _context.VaiTros.FirstOrDefaultAsync(vt => vt.MaVaiTro == id);
            if (vaiTro != null)
            {
                _context.VaiTros.Remove(vaiTro);
                await _context.SaveChangesAsync();
                return new VaiTroResponse(vaiTro);
            }
            else
                return null;
        }
    }
}
