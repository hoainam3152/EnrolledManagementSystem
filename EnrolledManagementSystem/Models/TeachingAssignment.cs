namespace EnrolledManagementSystem.Models
{
    public class TeachingAssignment
    {
        public string ClassID { get; set; }
        public string SubjectID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ClassRoomID { get; set; }
        public DateTime Day { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public string LecturerID { get; set; }
    }
}
