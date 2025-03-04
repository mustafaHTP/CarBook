using CarBook.Application.Features.CarFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Queries
{
    public class GetCarDescriptionsByCarIdQuery : IRequest<IEnumerable<GetCarDescriptionsByCarIdQueryResult>>
    {
        public int CarId { get; set; }
    }
}
