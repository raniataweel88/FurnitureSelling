using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models
{
    public class Raview
    {
        public int Id { get; set; }
        public int RatingNumber { get; set; }
        public string? Review { get; set; }
        public DateTime RatingDate { get; set; }
        public int UserId{get; set;}
        public int ItemId { get; set; }

    }
}
