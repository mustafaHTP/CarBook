﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarReservationPricing : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int ReservationPricingId { get; set; }
        public ReservationPricing ReservationPricing { get; set; }
        public decimal Price { get; set; }

    }
}
