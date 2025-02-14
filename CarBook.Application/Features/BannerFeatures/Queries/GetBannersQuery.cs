using CarBook.Application.Features.BannerFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BannerFeatures.Queries
{
    public class GetBannersQuery : IRequest<List<GetBannersQueryResult>>
    {
    }
}
