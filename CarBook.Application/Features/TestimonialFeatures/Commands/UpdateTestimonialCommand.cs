using MediatR;

namespace CarBook.Application.Features.TestimonialFeatures.Commands
{
    public class UpdateTestimonialCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
