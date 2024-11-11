using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class ToBoMonService
    {
        private readonly ManagementDbContext _context;

        public ToBoMonService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToBoMonResponse>> GetAll()
        {
            return await _context.To_BoMons
                .Select(bm => new ToBoMonResponse
                {
                    MaToBoMon = bm.MaToBoMon,
                    TenToBoMon = bm.TenToBoMon
                })
                .ToListAsync();
        }

        public async Task<ToBoMonResponse?> GetById(int id)
        {
            return await _context.To_BoMons
                .Select(bm => new ToBoMonResponse
                {
                    MaToBoMon = bm.MaToBoMon,
                    TenToBoMon = bm.TenToBoMon
                })
                .FirstOrDefaultAsync(bm => bm.MaToBoMon == id);
        }

        public async Task<ToBoMonResponse?> Add(ToBoMonRequest request)
        {
            _context.To_BoMons.Add(new To_BoMon()
            {
                TenToBoMon = request.TenToBoMon
            });
            await _context.SaveChangesAsync();
            return await _context.To_BoMons
                .OrderBy(bm => bm.MaToBoMon)
                .Select(bm => new ToBoMonResponse
                {
                    MaToBoMon = bm.MaToBoMon,
                    TenToBoMon = bm.TenToBoMon
                })
                .LastAsync();
        }

        public async Task<ToBoMonResponse?> Update(int id, ToBoMonRequest request)
        {
            var toBoMon = await _context.To_BoMons.FirstOrDefaultAsync(bm => bm.MaToBoMon == id);
            if (toBoMon != null)
            {
                toBoMon.TenToBoMon = request.TenToBoMon;
                await _context.SaveChangesAsync();
                return new ToBoMonResponse(toBoMon.MaToBoMon, toBoMon.TenToBoMon);
            }
            return null;
        }

        public async Task<ToBoMonResponse?> Delete(int id)
        {
            var toBoMon = await _context.To_BoMons.FirstOrDefaultAsync(bm => bm.MaToBoMon == id);
            if (toBoMon != null)
            {
                _context.To_BoMons.Remove(toBoMon);
                await _context.SaveChangesAsync();
                return new ToBoMonResponse(toBoMon.MaToBoMon, toBoMon.TenToBoMon);
            }
            else
                return null;
        }
    }
}
