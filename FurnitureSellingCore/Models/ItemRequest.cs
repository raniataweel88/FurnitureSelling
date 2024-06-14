using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models
{// for Item custom to request
    public class ItemRequest

    {  public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? CategoryId { get; set; }
        public float? Price { get; set; }
        public string? NoteStor { get; set; }



    }
}
