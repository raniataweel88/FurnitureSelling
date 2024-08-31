using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models
{
    public class ProductWarranty
    {
        public int ProductWarrantyId { get; set; }
        public int ItemId { get; set; }

        public string WarrantyCode { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
    }
}
