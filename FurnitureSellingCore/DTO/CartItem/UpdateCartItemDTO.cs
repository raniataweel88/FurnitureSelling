﻿namespace FurnitureSellingInfra.Repos
{
    public class UpdateCartItemDTO
    {
        public int CartItemId { get; set; }

        public int? CartId { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
    }
}