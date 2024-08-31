namespace FurnitureSellingCore.DTO.Item
{
    public class CreateItemDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public float   Price { get; set; }
        public int?   CategoryId { get; set; }
        public int? Quantity { get; set; }

        public List<string> Colors { get; set; }

        public List<string> Sizes { get; set; }
    }
}