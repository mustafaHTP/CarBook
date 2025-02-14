using MediatR;

namespace CarBook.Application.Features.TestimonialFeatures.Commands
{
    public class UpdateTestimonialCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
