using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.DTO.Rating
{
    public class CradRaviewDTO
    {
        public int Id { get; set; }
        public int RatingNumber { get; set; }
        public string? Review { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string ItemName { get; set; }
        public DateTime ratingDate { get; set; }

    }
}
