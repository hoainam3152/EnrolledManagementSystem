using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("MarkType")]
    public class MarkType
    {
        [Key]
        public string TypeID { get; set; }
        public string TypeName { get; set; }
        public int Coefficient { get; set; }
    }
}
