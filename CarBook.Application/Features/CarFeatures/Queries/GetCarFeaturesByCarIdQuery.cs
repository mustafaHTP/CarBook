using CarBook.Application.Features.CarFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Queries
{
    public class GetCarFeaturesByCarIdQuery : IRequest<IEnumerable<GetCarFeaturesByCarIdQueryResult>>
    {
        public int CarId { get; set; }
    }
}
