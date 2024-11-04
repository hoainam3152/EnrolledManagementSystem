﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.Entities
{
    [Table("Khoa_Khoi")]
    public class Khoa_Khoi
    {
        [Key]
        [StringLength(20)]
        public string MaKhoa { get; set; }
        [Required]
        [StringLength(100)]
        public string TenKhoa { get; set; }

        public ICollection<LopHoc> LopHocs { get; set; }
    }
}