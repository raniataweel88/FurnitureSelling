using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.DTO.User
{
    public class DetailsUserDTO
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int? UserType { get; set; }

        public string? Address { get; set; }
        public string? Salary { get; set; }
        public string? PlateNumber { get; set; }
    }
}
