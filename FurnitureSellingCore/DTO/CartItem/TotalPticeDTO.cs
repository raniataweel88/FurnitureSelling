﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.DTO.CartItem
{
    public class TotalPticeDTO
    {
        public int Id {  get; set; }
        public float price { get; set; }
        public float  TotalPrice { get; set; }

        public int Quintity  { get; set; }
    }
}
