using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Models
{
    public class BlockMarkType
    {
        [Key]
        public string BlockID { get; set; }
        public string CourseID { get; set; }
        public string SubjectID { get; set; }
        public string TypeID { get; set; }
        public int ColumnNumber { get; set; }
        public int ColumnRequired { get; set; }
    }
}
