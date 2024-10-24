using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("Deparment")]
    public class Department
    {
        [Key]
        public string DepartmentID { get; set; }
        public string Name { get; set; }
    }
}
