using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("BlockMarkType")]
    public class BlockMarkType
    {
        [Key]
        public string BlockID { get; set; }
        public string CourseID { get; set; }
        public string SubjectID { get; set; }
        public string TypeID { get; set; }
        public int ColumnNumber { get; set; }
        public int ColumnRequired { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }
        [ForeignKey("SubjectID")]
        public Subject Subject { get; set; }
        [ForeignKey("TypeID")]
        public MarkType MarkType { get; set; }
    }
}
