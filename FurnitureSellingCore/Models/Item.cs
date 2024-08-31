using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.Models
{
    public class Item
    {

        public int ItemId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateAdd { get; set; }
        public int RestQuantity { get; set; }
        public float PriceAfterDiscount { get; set; }

        public bool? isHaveDiscount { get; set; }
        // value of discount
        public float? DisacountAmount { get; set; }
        // Percentage or fixed value
        public DisacountType? DiscountType { get; set; }
        public DateTime? EndDate { get; set; }

        public int? CategoryId { get; set; }
        public virtual List<string> Colors { get; set; } 
          public virtual List<string> Sizes{ get; set; }


    }
}
