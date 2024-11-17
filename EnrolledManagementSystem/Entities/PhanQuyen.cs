using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    public class PhanQuyen
    {
        public int MaVaiTro { get; set; }
        public int MaQuyen { get; set; }

        [ForeignKey("MaVaiTro")]
        public VaiTro VaiTro { get; set; }
        [ForeignKey("MaQuyen")]
        public QuyenNguoiDung QuyenNguoiDung { get; set; }
    }
}
