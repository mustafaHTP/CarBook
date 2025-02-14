using CarBook.Application.Features.BrandFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BrandFeatures.Queries
{
    public class GetBrandByIdQuery : IRequest<GetBrandByIdQueryResult>
    {
        public GetBrandByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
