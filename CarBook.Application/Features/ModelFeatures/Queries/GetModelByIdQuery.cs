using CarBook.Application.Features.ModelFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.ModelFeatures.Queries
{
    public class GetModelByIdQuery : IRequest<GetModelByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
