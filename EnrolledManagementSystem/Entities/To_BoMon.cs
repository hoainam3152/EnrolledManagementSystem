using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("To_BoMon")]
    public class To_BoMon
    {
        [Key]
        public string TenToBoMon { get; set; }
    }
}
