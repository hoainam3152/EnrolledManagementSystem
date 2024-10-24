using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrolledManagementSystem.Entities
{
    [Table("Receipt")]
    public class Receipt    //Biên lai
    {
        [Key]
        public string ReceiptID { get; set; }
        public string TraineeID { get; set; }
        public string ClassID { get; set; }
        public string Address { get; set; }
        public int Content { get; set; }
        public double TuitionFee { get; set; }      //Học phí
        public double Receive { get; set; }
        public double Surcharge { get; set; }       //Phụ thu
        public double ActualRevenue { get; set; }   //Số tiền thực thu 

        [ForeignKey("TraineeID")]
        public Trainee Trainee { get; set; }
        [ForeignKey("ClassID")]
        public Class Class { get; set; }
    }
}
