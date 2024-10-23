using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Models
{
    public class MarkType
    {
        [Key]
        public string TypeID { get; set; }
        public string TypeName { get; set; }
        public int Coefficient { get; set; }
    }
}
