using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Services
{
    public class QuyenNguoiDungService
    {
        private readonly ManagementDbContext _context;

        public QuyenNguoiDungService(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuyenNguoiDungResponse>> GetAll()
        {
            return await _context.QuyenNguoiDungs
                .Select(qnd => new QuyenNguoiDungResponse
                {
                    MaQuyen = qnd.MaQuyen,
                    TenQuyen = qnd.TenQuyen
                })
                .ToListAsync();
        }

        public async Task<QuyenNguoiDungResponse?> GetById(int id)
        {
            return await _context.QuyenNguoiDungs
                .Select(qnd => new QuyenNguoiDungResponse
                {
                    MaQuyen = qnd.MaQuyen,
                    TenQuyen = qnd.TenQuyen
                })
                .FirstOrDefaultAsync(qnd => qnd.MaQuyen == id);
        }

        public async Task<QuyenNguoiDungResponse?> Add(QuyenNguoiDungRequest request)
        {
            _context.QuyenNguoiDungs.Add(new QuyenNguoiDung()
            {
                TenQuyen = request.TenQuyen
            });
            await _context.SaveChangesAsync();
            return await _context.QuyenNguoiDungs
                .OrderBy(qnd => qnd.MaQuyen)
                .Select(qnd => new QuyenNguoiDungResponse
                {
                    MaQuyen = qnd.MaQuyen,
                    TenQuyen = qnd.TenQuyen
                })
                .LastAsync();
        }

        public async Task<QuyenNguoiDungResponse?> Update(int id, QuyenNguoiDungRequest request)
        {
            var toBoMon = await _context.QuyenNguoiDungs.FirstOrDefaultAsync(qnd => qnd.MaQuyen == id);
            if (toBoMon != null)
            {
                toBoMon.TenQuyen = request.TenQuyen;
                await _context.SaveChangesAsync();
                return new QuyenNguoiDungResponse(toBoMon);
            }
            return null;
        }

        public async Task<QuyenNguoiDungResponse?> Delete(int id)
        {
            var toBoMon = await _context.QuyenNguoiDungs.FirstOrDefaultAsync(qnd => qnd.MaQuyen == id);
            if (toBoMon != null)
            {
                _context.QuyenNguoiDungs.Remove(toBoMon);
                await _context.SaveChangesAsync();
                return new QuyenNguoiDungResponse(toBoMon);
            }
            else
                return null;
        }
    }
}
