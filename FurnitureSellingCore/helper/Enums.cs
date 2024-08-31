﻿using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.helper
{
    public static class Enums
    {
        public enum UserType
        {
            Customer,
            Employee,
            Admain,
            driver
        }
        public enum DisacountType
        {
            Percentage,
            FixedValue,
        }
        public enum Paymentmethod
        {
            cash,
            CreditCard,
        }
    }
}
