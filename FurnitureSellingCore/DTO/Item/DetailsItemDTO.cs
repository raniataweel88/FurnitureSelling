namespace FurnitureSellingCore.DTO.Item
{
    public class DetailsItemDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public bool isHaveDiscount { get; set; }
        // value of discount
        public float? DisacountAmount { get; set; }
        // Percentage or fixed value
        public string? DiscountType { get; set; }
        public int? CategoryId { get; set; }
    }
}