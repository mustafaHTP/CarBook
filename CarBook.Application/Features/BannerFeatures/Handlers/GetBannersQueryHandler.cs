using CarBook.Application.Features.BannerFeatures.Queries;
using CarBook.Application.Features.BannerFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BannerFeatures.Handlers
{
    public class GetBannersQueryHandler : IRequestHandler<GetBannersQuery, List<GetBannersQueryResult>>
    {
        private readonly IRepository<Banner> _repository;

        public GetBannersQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBannersQueryResult>> Handle(GetBannersQuery request, CancellationToken cancellationToken)
        {
            var banners = await _repository.GetAllAsync();
            var result = banners.Select(b => new GetBannersQueryResult()
            {
                Id = b.Id,
                Description = b.Description,
                Title = b.Title,
                VideoDescription = b.VideoDescription,
                VideoUrl = b.VideoUrl,
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
