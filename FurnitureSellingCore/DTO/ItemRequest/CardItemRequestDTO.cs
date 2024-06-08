namespace FurnitureSellingCore.DTO.ItemRequest
{
    public class CardItemRequestDTO
    {
        public int ItemRequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }
    }
}