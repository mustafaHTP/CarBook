using CarBook.Application.Features.LocationFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.LocationFeatures.Queries
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
