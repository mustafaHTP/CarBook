using MediatR;

namespace CarBook.Application.Features.CarReviewFeatures.Commands
{
    public class UpdateCarReviewCommand : IRequest
    {
        public int Id { get; set; }
        public string Review { get; set; } = null!;
        public DateTime ReviewDate { get; set; }
        public int RatingStarCount { get; set; }
    }
}
