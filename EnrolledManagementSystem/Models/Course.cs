using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Models
{
    public class Course
    {
        [Key]
        public string CourseID { get; set; }
        public string CourseName { get; set; }
    }
}
