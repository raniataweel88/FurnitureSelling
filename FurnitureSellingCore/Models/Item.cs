using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.Models
{
    public class Item
    {
      
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public bool? isHaveDiscount { get; set; }
        // value of discount
        public float? DisacountAmount { get; set; }
        // Percentage or fixed value
        public DisacountType? DiscountType { get; set; }
     public DateTime? EndDate { get; set; }

        public int? CategoryId {  get; set; }
    public List<string>? Color { get; set; }= new List<string>();
   public List<float>?  Size { get; set; }= new List<float>();

    } 
}
