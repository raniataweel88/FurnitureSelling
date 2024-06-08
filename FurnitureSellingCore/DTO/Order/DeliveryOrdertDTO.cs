namespace FurnitureSellingCore.DTO.Order
{
    public class DeliveryOrdertDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public float? TotalPrice { get; set; }
        public bool StatusDelivery { get; set; }

   public string?  Phone      { get; set; }
   public string?  FirstName  { get; set; }
   public string?  LastName   { get; set; }
   public string? Address { get; set; }

    }
}