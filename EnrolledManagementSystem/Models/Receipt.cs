using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Models
{
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
    }
}
