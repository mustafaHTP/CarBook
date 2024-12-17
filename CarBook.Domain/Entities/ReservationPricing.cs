using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class ReservationPricing : BaseEntity
    {
        public string Name { get; set; }
        public List<CarReservationPricing> CarReservationPricings { get; set; }
    }
}
