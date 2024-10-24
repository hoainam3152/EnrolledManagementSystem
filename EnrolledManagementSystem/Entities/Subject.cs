using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("Subject")]
    public class Subject
    {

        [Key]
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string GroupID { get; set; }
        public string DepartmentID { get; set; }

        [ForeignKey("GroupID")]
        public SubjectGroup SubjectGroup { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
    }
}
