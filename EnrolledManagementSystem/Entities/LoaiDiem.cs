using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("LoaiDiem")]
    public class LoaiDiem
    {
        [Key]
        public string MaLoaiDiem { get; set; }
        public string TenLoaiDiem { get; set; }
        public int HeSo { get; set; }
    }
}
