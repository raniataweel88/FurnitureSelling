using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }    
        public string Code { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpireDate { get; set; }

        public float?  Blane { get; set; }


    }
}
