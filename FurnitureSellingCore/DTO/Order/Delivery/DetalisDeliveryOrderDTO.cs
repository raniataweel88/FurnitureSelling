using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.DTO.Order.Delivery
{
    public class DetalisDeliveryOrderDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public float? TotalPrice { get; set; }
        public bool StatusDelivery { get; set; }
        public DateTime? RecivingDate { get; set; }
        public string? DeliveryNote { get; set; }
        public string? Phone { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public int Paymentmethod { get; set; }

    }
}
