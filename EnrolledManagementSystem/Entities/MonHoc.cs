using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("MonHoc")]
    public class MonHoc
    {
        [Key]
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public string MaToBoMon { get; set; }
        public string MaKhoaKhoi { get; set; }

        [ForeignKey("MaToBoMon")]
        public To_BoMon To_BoMon { get; set; }

        [ForeignKey("MaKhoaKhoi")]
        public Khoa_Khoi Khoa_Khoi { get; set; }
    }
}
