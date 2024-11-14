using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("NienKhoa")]
    public class NienKhoa
    {
        [Key]
        [StringLength(20)]
        public string MaNienKhoa { get; set; }
        [StringLength(20)]
        public string TenNienKhoa { get; set; }

        public ICollection<LopHoc> lopHocs { get; set; }
    }
}
