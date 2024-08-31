namespace FurnitureSellingCore.DTO.Item
{
    public class CardItemDTO
    {
        public int ItemId { get; set; }

        public string? Name { get; set; }
        public string? Image { get; set; }
        public float Price { get; set; }
     
    public int? catogeryId   { get; set; }
        public int? PriceAfterDiscount { get; set; }

    }
}