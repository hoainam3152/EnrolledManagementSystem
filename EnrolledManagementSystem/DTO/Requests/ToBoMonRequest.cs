﻿using System.ComponentModel.DataAnnotations;

namespace EnrolledManagementSystem.DTO.Requests
{
    public class ToBoMonRequest
    {
        [Required]
        public string TenToBoMon { get; set; }
    }
}
