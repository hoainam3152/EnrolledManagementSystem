using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EnrolledManagementSystem.Models
{
    public class Trainee
    {
        [Key]
        public string TraineeID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ParentName { get; set; }
        public string Password { get; set; }
        public string ClassID { get; set; }
        public string Image { get; set; }
    }
}
