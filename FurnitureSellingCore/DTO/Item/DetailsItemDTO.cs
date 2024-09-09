using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.DTO.Item
{
    public class DetailsItemDTO
    {
        public int ItemId { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public float? Price { get; set; }
        public int? Quantity { get; set; }
        public int? RestQuantity { get; set; }
        public bool? isHaveDiscount { get; set; }
        // value of discount
        public float? DisacountAmount { get; set; }

        // Percentage or fixed value
        public string? DiscountType { get; set; }
        public int? CategoryId { get; set; }
       public List<string>? Colors { get; set; }
      
        public List<string>? Sizes{ get; set; }

        public float? PriceAfterDiscount { get; set; }
        public DateTime? EndDate { get; set; }

    }
}