using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models
{
    public class WishList
    {
        public int WishListId { get; set; }
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
        public int? itemId { get; set; }
    }
}
