using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("DangKy")]
    public class DangKy
    {
        [StringLength(20)]
        public string MaHocVien { get; set; }
        [StringLength(20)]
        public string MaLopHoc { get; set; }
        public bool DaDongHocPhi { get; set; }

        [ForeignKey("MaHocVien")]
        public HocVien HocVien { get; set; }
        [ForeignKey("MaLopHoc")]
        public LopHoc LopHoc { get; set; }
    }
}
