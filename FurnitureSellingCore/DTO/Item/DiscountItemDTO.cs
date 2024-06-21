using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.DTO.Item
{
    public class DiscountItemDTO
    {
        public int ItemId { get; set; } 
        public bool? isHaveDiscount { get; set; }
        // value of discount
        public float? DisacountAmount { get; set; }
        // Percentage or fixed value
        public DisacountType? DiscountType { get; set; }
        public DateTime? EndDateOfDiscount { get; set; }

    }
}
