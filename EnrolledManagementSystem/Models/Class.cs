using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Models
{
    public class Class
    {
        [Key]
        public string ClassID { get; set; }
        public string ClassName { get; set; }
        public string AcademicYearID { get; set; }
        public string DepartmentID { get; set; }
        public int StudentNumber { get; set; }
        public string TuitionFee { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
