using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.DTO.ProductWarranty
{
    public class CreateProductWarrantyDTO
    {
        public int ItemId { get; set; }
        public string WarrantyCode { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
    }
}
