using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int? CartId { get; set; }
        public int? ItemId { get; set; }
        public int Quantity { get; set; }
        public string? Size { get; set; }

        public string? Color { get; set; }

    }
}
