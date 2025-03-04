using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.ReservationDtos
{
    public class CreateReservationDto
    {
        public int CarId { get; set; }
        public string CustomerFirstName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
    }
}
