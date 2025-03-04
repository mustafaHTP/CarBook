using MediatR;

namespace CarBook.Application.Features.CarReviewFeatures.Commands
{
    public class DeleteCarReviewCommand : IRequest
    {
        public int Id { get; set; }
    }
}
