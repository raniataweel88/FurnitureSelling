﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string   Title { get; set; }
        public float TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public float Fee { get; set; }
        public string CustomerNote { get; set; }
        public int? ItemId { get; set; }
     
    }
}