using MediatR;

namespace CarBook.Application.Features.CarReviewFeatures.Commands
{
    public class CreateCarReviewCommand : IRequest
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string Review { get; set; } = null!;
        public DateTime ReviewDate { get; set; }
        public int RatingStarCount { get; set; }
    }
}
