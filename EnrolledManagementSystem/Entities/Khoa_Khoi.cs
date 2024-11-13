using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("Khoa_Khoi")]
    public class Khoa_Khoi
    {
        [Key]
        [StringLength(20)]
        public string MaKhoaKhoi { get; set; }
        [StringLength(100)]
        public string TenKhoaKhoi { get; set; }

        public ICollection<LopHoc> LopHocs { get; set; }
        public ICollection<MonHoc> MonHocs { get; set; }
    }
}
