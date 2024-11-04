using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("To_BoMon")]
    public class To_BoMon
    {
        [Key]
        public int MaToBoMon { get; set; }

        [Required]
        [StringLength(100)]
        public string TenToBoMon { get; set; }
    }
}
