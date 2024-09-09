using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.DTO.Order
{
    public class DetailsOrdertDTO
    {
        
        public int OrderId { get; set; }

        public string? Title { get; set; }
        public float? TotalPrice { get; set; }
        public DateTime? Date { get; set; }
        public float? Fee { get; set; }
        public string? CustomerNote { get; set; }
        public string? CardNumber { get; set; }
        public string? Code { get; set; }
        public string? CardHolder { get; set; }
        public bool? statusDelivery { get; set; }
        public int? Paymentmethod { get; set; }
        public bool? Preparingrequest { get; set; }


    }
}