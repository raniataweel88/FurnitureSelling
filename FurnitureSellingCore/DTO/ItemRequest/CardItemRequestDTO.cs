namespace FurnitureSellingCore.DTO.ItemRequest
{
    public class CardItemRequestDTO
    {
        public int ItemRequestId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Note { get; set; }
        public float? price { get; set; }
        public int? UserId { get; set; }

    }
}