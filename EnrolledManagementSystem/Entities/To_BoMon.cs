﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("To_BoMon")]
    public class To_BoMon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //thiết lập tự động tăng
        public int MaToBoMon { get; set; }
        [StringLength(100)]
        public string TenToBoMon { get; set; }
        public ICollection<MonHoc> monHocs { get; set; }
    }
}
