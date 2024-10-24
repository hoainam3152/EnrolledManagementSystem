using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("Lecturer")]
    public class Lecturer
    {
        [Key]
        public string ID { get; set; }
        public string TaxCode { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string MainSubjectID { get; set; }
        public string MinorSubjectName { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }

        [ForeignKey("MainSubjectID")]
        public Subject Subject { get; set; }
    }
}
