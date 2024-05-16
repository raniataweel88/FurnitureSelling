using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models
{
    public class Login   {
        public int LoginId { get; set; } 
 
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginTime { get; set; }
       public bool IsLoggedIn { get; set; }
}
}
