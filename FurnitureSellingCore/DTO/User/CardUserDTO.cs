using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.DTO.User
{
    public class CardUserDTO
    {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        
        public int UserId { get; set; }

       
        
    }
}
