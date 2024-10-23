using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Models
{
    public class Result
    {
        [Key]
        public string SubjectID { get; set; }
        [Key]
        public string TraineeID { get; set; }
        public string TypeID { get; set; }
        public double Mark { get; set; }
    }
}
