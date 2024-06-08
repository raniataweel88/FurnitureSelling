using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.DTO.Cart
{
    public class CardCartDTO
    {
        public int CartId { get; set; }

        public int? UserId { get; set; }
        public int? OrderId { get; set; }
        public bool IsActiveId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public float? TotalPrice { get; set; }
        public float? Fee { get; set; }



    }
}
