using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Responses
{
    public class KhoaKhoiResponse
    {
        public string MaKhoaKhoi { get; set; }
        public string TenKhoaKhoi { get; set; }

        public KhoaKhoiResponse()
        {
            
        }

        public KhoaKhoiResponse(string maKhoaKhoi, string tenKhoaKhoi)
        {
            this.MaKhoaKhoi = maKhoaKhoi;
            this.TenKhoaKhoi = tenKhoaKhoi;
        }
    }
}
