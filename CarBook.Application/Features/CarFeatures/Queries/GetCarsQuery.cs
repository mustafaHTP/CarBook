using CarBook.Application.Features.CarFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Queries
{
    public class GetCarsQuery : IRequest<List<GetCarsQueryResult>>
    {
        public bool IncludeModel { get; set; }
        public bool IncludeBrand { get; set; }
    }
}
