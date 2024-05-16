using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string Phone{ get; set; }
        public DateTime BirthDate { get; set; }
        public int? LoginId { get; set; }
        public int? OrderId { get; set;}
    }
}
