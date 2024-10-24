using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("Result")]
    public class Result
    {
        [Key]
        public string ResultID { get; set; }

        public string SubjectID { get; set; }
        public string TraineeID { get; set; }
        public string TypeID { get; set; }
        public double Mark { get; set; }

        [ForeignKey("SubjectID")]
        public Subject Subject { get; set; }
        [ForeignKey("TraineeID")]
        public Trainee Trainee { get; set; }
        [ForeignKey("TypeID")]
        public MarkType MarkType { get; set; }
    }
}
