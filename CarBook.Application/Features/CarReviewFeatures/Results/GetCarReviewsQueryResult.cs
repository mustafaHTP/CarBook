using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarReviewFeatures.Results
{
    public class GetCarReviewsQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string Review { get; set; } = null!;
        public DateTime ReviewDate { get; set; }
        public int RatingStarCount { get; set; }
    }
}
