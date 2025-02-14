using CarBook.Application.Features.CarFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Queries
{
    public class GetCarByIdQuery : IRequest<GetCarByIdQueryResult>
    {
        public int Id { get; set; }
        public bool IncludeModel { get; set; }
        public bool IncludeBrand { get; set; }
    }
}
