﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int? OrderId { get; set; }

    }
}
