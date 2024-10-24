using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("TeachingAssignment")]
    public class TeachingAssignment
    {
        [Key]
        public string AssignmentID { get; set; }
        public string ClassID { get; set; }
        public string SubjectID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ClassRoom { get; set; }
        public DateTime Day { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public string LecturerID { get; set; }


        [ForeignKey("ClassID")]
        public Class Class { get; set; }

        //[ForeignKey("SubjectID")]
        //public Subject Subject { get; set; }

        //[ForeignKey("LecturerID")]
        //public Lecturer Lecturer { get; set; }
    }
}
