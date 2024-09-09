namespace FurnitureSellingCore.DTO.Order
{
    public class CardOrdertDTO
    {
        public int OrderId { get; set; }

        public string Title { get; set; }
        public float? TotalPrice { get; set; }
        public DateTime? Date { get; set; }
        public bool? Preparingrequest { get; set; }

        public bool? StatusDelivery { get; set; }

    }
}