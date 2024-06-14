using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.DTO.ItemRequest
{
    public class ItemRequestFromAdmain
    {
        public int? Id { get; set; }

        public float? Price { get; set; }
        public string? Note { get; set; }
    }
}
