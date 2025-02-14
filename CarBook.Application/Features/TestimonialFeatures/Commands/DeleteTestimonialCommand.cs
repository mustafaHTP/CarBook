using MediatR;

namespace CarBook.Application.Features.TestimonialFeatures.Commands
{
    public class DeleteTestimonialCommand : IRequest
    {
        public int Id { get; set; }
    }
}
