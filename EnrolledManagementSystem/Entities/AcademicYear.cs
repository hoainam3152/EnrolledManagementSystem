using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("AcademicYear")]
    public class AcademicYear
    {
        [Key]
        public string AcademicYearID { get; set; }
        public string Name { get; set; }
    }
}
