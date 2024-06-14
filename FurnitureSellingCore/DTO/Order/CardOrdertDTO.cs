namespace FurnitureSellingCore.DTO.Order
{
    public class CardOrdertDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public float? TotalPrice { get; set; }
        public DateTime? Date { get; set; }

    }
}