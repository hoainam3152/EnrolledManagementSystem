﻿using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class KhoaKhoiCreate
    {
        [Required]
        public string MaKhoaKhoi { get; set; }
        [Required]
        public string TenKhoaKhoi { get; set; }
    }
}
