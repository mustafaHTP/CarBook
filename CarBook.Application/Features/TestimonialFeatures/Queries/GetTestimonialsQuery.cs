using CarBook.Application.Features.TestimonialFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.TestimonialFeatures.Queries
{
    public class GetTestimonialsQuery : IRequest<List<GetTestimonialsQueryResult>>
    {
    }
}
