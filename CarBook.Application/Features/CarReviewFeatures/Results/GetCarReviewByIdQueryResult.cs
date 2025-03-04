using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CarReviewFeatures.Results
{
    public class GetCarReviewByIdQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; } = null!;
        public string Review { get; set; } = null!;
        public DateTime ReviewDate { get; set; }
        public int RatingStarCount { get; set; }
    }
}
