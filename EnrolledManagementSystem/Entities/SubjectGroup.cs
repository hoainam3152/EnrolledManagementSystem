using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("SubjectGroup")]
    public class SubjectGroup
    {
        [Key]
        public string SubjectGroupName { get; set; }
    }
}
