using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.CarReviewDtos
{
    public class GetCarReviewByCarIdDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string Review { get; set; } = null!;
        public DateTime ReviewDate { get; set; }
        public int RatingStarCount { get; set; }
    }
}
