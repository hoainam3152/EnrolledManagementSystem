using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("NienKhoa")]
    public class NienKhoa
    {
        [Key]
        public string MaNienKhoa { get; set; }
        public string TenNiemKhoa { get; set; }
    }
}
