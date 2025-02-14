using CarBook.Application.Features.TestimonialFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.TestimonialFeatures.Queries
{
    public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
