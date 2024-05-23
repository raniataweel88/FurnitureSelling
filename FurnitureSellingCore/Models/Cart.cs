using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public bool IsActiveId { get; set; }

    }
}
