﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.Models
{
    public class User
    {
        public int  UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string? Email { get; set; } 
        public string? Phone{ get; set; }
        public DateTime? BirthDate { get; set; }
        public string? UserType {get; set;}
        public string? Address { get; set; }
        public float? Salary { get; set; }
        public string? PlateNumber { get; set; }
        public string? Key { get; set; }
        public string? IV { get; set; }

    }
}
