using MediatR;

namespace CarBook.Application.Features.TestimonialFeatures.Commands
{
    public class CreateTestimonialCommand : IRequest
    {
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
