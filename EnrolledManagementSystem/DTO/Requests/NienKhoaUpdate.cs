﻿using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class NienKhoaUpdate
    {
        [Required]
        public string TenNienKhoa { get; set; }
    }
}
