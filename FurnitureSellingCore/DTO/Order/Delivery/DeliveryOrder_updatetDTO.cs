using Microsoft.EntityFrameworkCore.Migrations;

namespace FurnitureSellingCore.DTO.Order.Delivery
{
    public class DeliveryOrder_updatetDTO
    {
        public int OrderId { get; set; }

        public bool? StatusDelivery { get; set; }
        public DateTime? RecivingDate { get; set; }
        public string? DeliveryNote { get; set; }
        public bool? Preparingrequest { get; set; }

    }
}