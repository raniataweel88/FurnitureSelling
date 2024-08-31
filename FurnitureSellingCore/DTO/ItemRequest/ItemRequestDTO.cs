namespace FurnitureSellingCore.DTO.ItemRequest
{
    public class ItemRequestDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? UserId { get; set; }
        public string? Note { get; set; }
        public float? price { get; set; }


    }
}