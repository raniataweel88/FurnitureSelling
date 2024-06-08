using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.DTO.CartItem
{
    public class CreateCartItemDTO
    {
        public int? CartId { get; set; }
        public int? ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
