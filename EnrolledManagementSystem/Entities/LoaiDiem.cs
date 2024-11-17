using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("LoaiDiem")]
    public class LoaiDiem
    {
        [Key]
        [StringLength(20)]
        public string MaLoaiDiem { get; set; }
        [Required]
        [StringLength(50)]
        public string TenLoaiDiem { get; set; }
        public int HeSo { get; set; }

        public ICollection<LoaiDiemMon> loaiDiemMons { get; set; }
        public ICollection<Diem> Diems { get; set; }

        public LoaiDiem() { }

        public LoaiDiem(Models.LoaiDiemCreate ldModel)
        {
            this.MaLoaiDiem = ldModel.MaLoaiDiem;
            this.TenLoaiDiem = ldModel.TenLoaiDiem;
            this.HeSo = ldModel.HeSo;
        }
    }
}
