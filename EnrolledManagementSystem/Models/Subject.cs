using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Models
{
    public class Subject
    {

        [Key]
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string SubjectGroupName { get; set; }
        public string DepartmentID { get; set; }
    }
}
