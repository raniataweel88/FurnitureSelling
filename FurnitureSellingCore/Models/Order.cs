﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string? Title { get; set; }
        public float? TotalPrice { get; set; }
        public DateTime? Date { get; set; }
        public float? Fee { get; set; }
        public string? CustomerNote { get; set; }
        public bool? StatusDelivery {  get; set; }
        public DateTime? RecivingDate { get; set; }
        public string?   DeliveryNote { get; set; }
        public Paymentmethod? Paymentmethod { get; set; }

        public bool? Preparingrequest { get; set; }

    }
}
