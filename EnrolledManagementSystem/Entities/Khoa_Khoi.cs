using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("Khoa_Khoi")]
    public class Khoa_Khoi
    {
        [Key]
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
    }
}
