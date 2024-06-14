namespace FurnitureSellingCore.DTO.Order.Delivery
{
    public class DeliveryOrdertDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public float? TotalPrice { get; set; }
        public bool StatusDelivery { get; set; }


    }
}