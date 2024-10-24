using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public string CourseID { get; set; }
        public string CourseName { get; set; }
    }
}
