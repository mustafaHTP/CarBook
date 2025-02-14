using CarBook.Application.Features.ServiceFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.ServiceFeatures.Queries
{
    public class GetServiceByIdQuery : IRequest<GetServiceByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
