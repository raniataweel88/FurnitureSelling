using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.DTO.Item
{
    public class ProductFilterDto
    {
        public string? SortBy { get; set; }  // يمكن أن يكون "Default", "pice : high to low", إلخ
        public float? MinPrice { get; set; }
        public float? MaxPrice { get; set; }
        public string? Color { get; set; }
        public string? price  { get; set; }
        public bool? HasDiscount { get; set; }
    }
}
