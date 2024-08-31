namespace FurnitureSellingCore.DTO.CartItem
{
    public class CartItemDTO
    {
      public int CartItemId {  get; set; }

        public int? CartId { get; set; }
        public int? ItemId { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public float? Price { get; set; }
        public string? Image { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
    }
}