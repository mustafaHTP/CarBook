using CarBook.Application.Features.BrandFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BrandFeatures.Queries
{
    public class GetBrandsQuery : IRequest<List<GetBrandsQueryResult>>
    {
        public bool IncludeModels { get; set; }
    }
}
