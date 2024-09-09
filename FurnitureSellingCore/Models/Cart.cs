using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int? UserId { get; set; }
        public int?  OrderId { get; set; } 
        public Paymentmethod? Paymentmetod {  get; set; }
        public bool? IsActiveId { get; set; }
    }

}
